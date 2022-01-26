using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationLayer.Complete
{

    public enum Colours
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    [Flags]
    public enum ColourFlags
    {
        Red,
        Orange,
        Yellow,
        Green,
        Blue,
        Indigo,
        Violet
    }

    [Flags]
    public enum ColourMask
    {
        None = 0,
        Red = 1,
        Orange = 2,
        Yellow = 4,
        Green = 8,
        Blue = 16,
        Indigo = 32,
        Violet = 64
    }
    public class FlagsAttributeDemo : DemoBase
    {
        private Random rand = new Random();
        Action<Action<Colours>> loopColours = act => { for (var c = Colours.Red; c <= Colours.Violet; c++) act(c); };
        Action<Action<ColourFlags>> loopColourFlags = act => { for (var c = ColourFlags.Red; c <= ColourFlags.Violet; c++) act(c); };
        Action<Action<ColourMask>> loopColourMasks = act => { foreach (ColourMask c in Enum.GetValues(typeof(ColourMask))) act(c); };

        public override void Run()
        {
            AddPart(Part1, "Lists of booleans");
            AddPart(Part2, "Intro to Flags");
            AddPart(Part3, "Setting the correct enum values - a look at binary formatting");
            AddPart(Part4, "Setting and checking flags and combinations without [Flags]");
            AddPart(Part5, "A brief detour about indexers");
            AddPart(Part6, "Setting and checking flag combinations with BITWISE operations");
            base.Run();
        }
        public void Part1()
        {
            // Flags are a means of grouping booleans together.  
            //
            // Say you have a series of coloured lights and you're lighting a stage for different moods
            // or scenes.  You'd probably have a system like:
            // 
            // Scene                  Red     Orange    Yellow     Green      Blue    Indigo    Violet
            // -------------------------------------------------------------------------------------------
            // "Act I: Scene i"   -   off     off       on         off        off     off       on
            // "Act I: Scene ii"  -   on      off       on         off        on     off        off
            // "Act I: Scene iii" -   off     off       off        off        on      off       on
            // 
            // And so on...
            //
            // in code you could represent that with something like the Colours enum at the top coordinating 
            // access to a collection of booleans indicating the state of each light and then tie that together
            // with a scene name.

            var lightScenes = new Dictionary<string, List<bool>>();

            loopColours(c =>
            {
                var scene = $"Scene {c}";
                lightScenes.TryAdd(scene, new List<bool>());
                loopColours(c =>
                {
                    // just a different way of assigning something at random
                    var lightOn = DateTime.Now.Ticks % 2 == 0;
                    lightScenes[scene].Add(lightOn);
                });
            });

            // then to display the settings...
            foreach (var scene in lightScenes)
            {
                Console.Write($"{scene.Key}: ");
                loopColours(c => Console.Write($"{c} = {(scene.Value[(int)c] ? "on" : "off")}, "));
                Console.WriteLine();
            }

            // this is quite cumbersome for what is actually needed to store the information.
            // thankfully, enums can be made into "Flags" to make this easier.  in part 2, we'll
            // see how.
        }
        public void Part2()
        {
            // see the ColourFlags enum
            // at the top and notice the [Flags] above it.
            //
            // in .NET this syntax is called an Attribute.
            //
            // Attributes can be used for wide variety of things and you'll see them a lot in Entity Framework 
            // and ASP.NET MVC.  The Flags attribute supplied by .NET is just one implementation that allows 
            // an enumerated type to express *multiple* values at the same time.
            //
            // so instead of a List<bool>, we can make the dictionary with ColourFlags.
            // 
            // but it's not that sample.  look what happens when we run the same code using ColourFlags instead.

            var lightScenes = new Dictionary<string, ColourFlags>();

            loopColourFlags(c =>
            {
                var scene = $"Scene {c}";
                lightScenes.TryAdd(scene, (ColourFlags)0);  // casting needed
                loopColourFlags(c =>
                {
                    // just a different way of assigning something at random
                    var lightOn = DateTime.Now.Ticks % 2 == 0;
                    if (lightOn)
                    {
                        Console.WriteLine($"{c} light should be on in {scene}");
                        // set the flag if true
                        lightScenes[scene] |= c;
                    }
                });
            });

            // much easier to display, but are they right?
            foreach (var scene in lightScenes)
            {
                Console.WriteLine($"{scene.Key}: {scene.Value}");
            }

            // we can see from the results that it always seems to be Red, Orange, Yellow, Green
            // and/or Violet that are shown regardless of what the settings should be.  we'll see why in Part3.
        }

        public void Part3()
        {
            // so why can you never seem to get Blue or Indigo?
            //
            // it's because when you use the Flags attribute, it doesn't store the enum in the way you might think.
            //
            // it's not just a list of bool.  trying to implement that would quickly become complicated and
            // unweildy as you tried to reproduce the convenient syntax of enumerations:
            //
            // i.e. Colours.Red is very clear, whereas to get the same thing without using an enum, you'd need something
            // like the NamedEnum class below and that example is just the tip of the iceberg!
            //
            // it's unlikely that's the *reason* .NET does it the way it does but it certainly goes some way to
            // realising that as apparently complicated as .NET's way is, it is still a *lot* simpler than the alternatives.
            //
            // so here's why ColourFlags isn't working.  (this uses a new extension method to break the binary digits up
            // and make them easier to read) 
            loopColourFlags(c => Console.WriteLine($"{c,-10}: {((int)c).BinaryString(32)}"));

            // notice the binary values are expressed in "base 2", so every column to the left represent that multiple of the 
            // figures to its right.
            // 
            // so the decimal number 33 really means 3 multiples of 10 and 3 individual units.
            // the decimal number 33 in base 5 would be 3 multuples 5 plus 3 individual units, giving a decimal total of 18.
            // in base 3 and below, "33" cannot be expressed cuz '3' is too high a value for a column to have.
            // in base 2, the maximum number is 1, which is why binary numbers can only be 1 or 0.
            //
            // an enum is stored in an int and the maximum decimal value an int can store is: 2147483647
            //
            // this is shown below.
            //
            Console.WriteLine(int.MaxValue);

            // why is that the number and not something else?  cuz an int is 32 bits long.  i.e. there are 32 binary column values
            // in ascending order of magnitude from right to left.   each of those columns is called a bit and when it has a 1 in it
            // that bit is said to be "set".  when it has a zero, the bit is said to be "clear".
            //
            // therefore, when every column has a 1 in it, the value it represents cannot _physically_ be increased.  when computers 
            // detect that the maximum value for a particular area of storage has been exceeded, that is when they report "arithmetic
            // overflow" errors.  
            // 
            // so when we format int.MaxValue as binary, we'll see that all the bits are set and 21.4 billion is the decimal representation 
            // of that number.
            Console.WriteLine(int.MaxValue.BinaryString(32));

            // why is the left-most bit still 0?  an int can also store negative numbers.  this is possible cuz the type uses one of the 32
            // bits as an indicator of whether it's positive or negative.  when it is clear, it's a positive number.  that bit is called
            // "the sign bit".   to use all 32 bits for the number, we need to specify the "uint" type, which means the integer is "unsigned"
            // and therefore *always* a positive number.  this means that a uint can store a value twice as big as an int.
            Console.WriteLine(uint.MaxValue);
            Console.WriteLine(uint.MaxValue.BinaryString(32));

            // that's why i've formatted the colour values as 32 bit binary strings: to illustrate the total binary columns in use.
            // 
            // it is this fundamental use of binary states by computers in general that .NET is actually using to represent the flags.
            // each flag occupies a single bit in the int.  this means that by default, we can only store 31 unique flags in a [Flags] enum.
            // the 32nd bit is reserved as the sign bit.
            // 
            // so what does that mean in terms of our colour values?  it means that when _only_ one flag is set, the value of the enum is 
            // the value assigned (explicitly by us or implicitly by C#).  that's no different from how it works without the [Flags] attribute
            // but the crucial consideration here is that the flags attribute makes it possible to express multiple values simultaneously.
            //
            // so the value for each member of the enumation *must* be representable by a single bit, otherwise the setting of one flag might
            // imply the setting of another, which is unlikely to be your intention and would be a bad design decision, if it was.
            //
            // in decimal, given a number of columns, we can quickly deduce the maximum number we can store by mentally filling those columns
            // with 0s and adding a sixth column to the left to a put a one in, cuz it's easier to say "100 thousand" than it is to say
            // "ninety nine thousand nine hundred and ninety nine" :-) 
            //
            // e.g. 5 columns - remembering the headings we used in our school maths lessons...
            //
            //          HT       TT       TH       H        T        U 
            //          100000   10000    1000     100      10       1
            //          Col 6    Col 5    Col 4    Col 3    Col 2    Col 1
            //          1        0        0        0        0        0
            //
            // in binary we perform the same calculation but using 2 as the multiplier.
            //
            //          32       16       8        4        2        1    
            //          Col 6    Col 5    Col 4    Col 3    Col 2    Col 1
            //          1        0        0        0        0        0
            // 
            // So, let's look what's happening with the existing values
            // 
            loopColourFlags(c => Console.WriteLine($"{c,-10}: {((int)c).BinaryString(32)}"));

            // Red:    0 - we can see now there isn't a column dedicated to representing 0.  the lowest value we can give a flag is therefore 1.
            // Orange: 1 - this can be represented by column 1 (or bit 0).  this is why the orange light is never mistakenly shown as off.
            // Yellow: 2 - this can be represented by column 2 (or bit 1).  so the yellow light is never mistakenly shown as off.
            // Green:  3 - as you can see, 2 bits need to be set to store this number cuz 3 isn't one of the binary indices.  both those bits are
            //             already in use this can NOT be represented in a single column.  setting bit 3 would make the value = 4, and setting bit 2 would make it
            //             too low.  so 3 need 2 bit positions to be expressed - bit 1 (2) and bit 0 (1);  2 + 1 = 3.
            // 
            // we don't need to go any further to understand that setting the Green flag will now give the mistaken impression the Orange and Yellow flags have been set.
            // it only due to the way enum's ToString() works that setting it explicitly to Green alone gives the right output.
            // 
            // so look now at ColourMasks.  when you run this next chunk of code, you'll see the scene requirements now match the results cuz each value's representation
            // is contained in a single bit.
            //
            // in the next part, we'll see how to check specific flags and combinations.

            var lightScenes = new Dictionary<string, ColourMask>();
            loopColourMasks(c =>
            {
                var scene = $"Scene {c}";
                lightScenes.TryAdd(scene, 0);
                loopColourMasks(c =>
                {
                    // just a different way of assigning something at random
                    var lightOn = DateTime.Now.Ticks % 2 == 0;
                    if (lightOn)
                    {
                        Console.WriteLine($"{c} light should be on in {scene}");
                        // set the flag if true
                        lightScenes[scene] |= c;
                    }
                });
            });

            // and take a look at the binary values for each light
            foreach (var scene in lightScenes)
            {
                Console.WriteLine($"{scene.Key}: {scene.Value} [{((int)scene.Value).BinaryString(32)}]");
            }
            // let's take a look at the enum ColourFlags
        }

        public void Part4()
        {
            // without [Flags], checking whether a particular combination of lights was active would look something like this.
            var theatreLights = new List<bool>();
            Action<List<bool>> setScene = combo =>
            {
                // clear the existing set
                theatreLights.Clear();
                // set the lights for the scene
                theatreLights.AddRange(combo);
                // simulate a possible failure
                var randomLight = rand.Next(0, 10);
                // allow number out of range to let scene avoid failure
                if (randomLight >= theatreLights.Count) return;
                // if we got a number matching a light index, knock that light out
                theatreLights[randomLight] = false;
            };

            var lightScenes = new Dictionary<string, List<bool>>();
            loopColours(c =>
            {
                var scene = $"Scene {c}";
                lightScenes.TryAdd(scene, new List<bool>());
                loopColours(c =>
                {
                    // just a different way of assigning something at random
                    var lightOn = DateTime.Now.Ticks % 2 == 0;
                    lightScenes[scene].Add(lightOn);
                });
            });

            // then to display the settings...
            foreach (var scene in lightScenes)
            {
                Console.Write($"{scene.Key}: ");
                loopColours(c => Console.Write($"{c} = {(scene.Value[(int)c] ? "on" : "off")}, "));
                Console.WriteLine();
            }

            // now go thru the show, loading the lighting set into the rig
            foreach (var kvp in lightScenes)
            {
                var scene = kvp.Key;
                var sceneSet = kvp.Value;
                Console.WriteLine($"- - - - - - - - - -\nSetting {scene}");
                // deliberately not using scene name, here...
                setScene(sceneSet);
                loopColours(c =>
                {
                    var actualLightState = $"is {(theatreLights[(int)c] ? "on" : "off")}";
                    var expectedLightState = sceneSet[(int)c] ? "on" : "off";
                    var statement = sceneSet[(int)c] == theatreLights[(int)c]
                        ? $"is working ({actualLightState})"
                        : $"{actualLightState} but should be {expectedLightState}";

                    Console.WriteLine($"{c} light {statement}");
                });

                loopColours(c =>
                {
                    if (!theatreLights[(int)c].Equals(sceneSet[(int)c]))
                    {
                        Console.WriteLine($"- - - - - - - - - -\nProblem in {lightScenes.Single(kvp => kvp.Value == sceneSet).Key}");
                    }
                });
            }
        }

        private bool lightAsDefined(List<bool> sceneConfig, Colours colour, bool state)
        {
            return sceneConfig[(int)colour] == state;
        }

        public void Part5()
        {
            // it's difficult to find a critical reason to use indexers.  they are by popular admission, syntactic sugar.  to wit: a nicety.
            // but nowhere is that nicety more appreciated than when you want to index a collection by an enumerated type.
            // 
            // look at the code in Part4 and see how many hard casts were necessary to look up those boolean values!  
            //
            // the code below is unchanged from part 4, except for 2 things.
            //
            // -1- the List<bool> have been replaced with EnumList<bool>
            // -2- all the casts have been removed.
            //
            // without [Flags], checking whether a particular combination of lights was active would look something like this.
            var theatreLights = new EnumList<bool, Colours>();
            Action<List<bool>> setScene = combo =>
            {
                // clear the existing set
                theatreLights.Clear();
                // set the lights for the scene
                theatreLights.AddRange(combo);
                // simulate a possible failure
                var randomLight = rand.Next(0, 10);
                // allow number out of range to let scene avoid failure
                if (randomLight >= theatreLights.Count) return;
                // if we got a number matching a light index, knock that light out
                theatreLights[randomLight] = false;
            };

            var lightScenes = new Dictionary<string, EnumList<bool, Colours>>();
            loopColours(c =>
            {
                var scene = $"Scene {c}";
                lightScenes.TryAdd(scene, new EnumList<bool, Colours>());
                loopColours(c =>
                {
                    // just a different way of assigning something at random
                    var lightOn = DateTime.Now.Ticks % 2 == 0;
                    lightScenes[scene].Add(lightOn);
                });
            });

            // then to display the settings...
            foreach (var scene in lightScenes)
            {
                Console.Write($"{scene.Key}: ");
                loopColours(c => Console.Write($"{c} = {(scene.Value[c] ? "on" : "off")}, "));
                Console.WriteLine();
            }

            // now go thru the show, loading the lighting set into the rig
            foreach (var kvp in lightScenes)
            {
                var scene = kvp.Key;
                var sceneSet = kvp.Value;
                Console.WriteLine($"- - - - - - - - - -\nSetting {scene}");
                // deliberately not using scene name, here...
                setScene(sceneSet);
                loopColours(c =>
                {
                    var actualLightState = $"is {(theatreLights[c] ? "on" : "off")}";
                    var expectedLightState = sceneSet[c] ? "on" : "off";
                    var statement = sceneSet[c] == theatreLights[c]
                        ? $"is working ({actualLightState})"
                        : $"{actualLightState} but should be {expectedLightState}";

                    Console.WriteLine($"{c} light {statement}");
                });

                loopColours(c =>
                {
                    if (!theatreLights[c].Equals(sceneSet[c]))
                    {
                        Console.WriteLine($"- - - - - - - - - -\nProblem in {lightScenes.Single(kvp => kvp.Value == sceneSet).Key}");
                    }
                });

            }
        }
        public void Part6()
        {
            // now that we have our flags set up correctly, it is a lot easier to achieve the same thing
            // as parts 4 and 5.
            //
            var theatreLights = ColourMask.None;
            Action<ColourMask> setScene = combo =>
            {
                theatreLights = combo;
                // simulate a possible failure
                var randomLight = 1 << rand.Next(0, 10);
                if (Enum.IsDefined(typeof(ColourMask), randomLight))
                {
                    var randomLightMask = (ColourMask)randomLight;
                    if (theatreLights.HasFlag((ColourMask) randomLightMask))
                    {
                        // light is on; turn it off.  do this by using a "bitwise complement" operation.
                        // you do this using a special operator "~"
                        //
                        // basically this means flip all the bits in a mask.
                        //
                        // e.g. var colourMask = 5.
                        //
                        //      as binary, that's 0101
                        //
                        //      in terms of our Colours enum that would be the Orange and Blue lights.
                        //      to turn off the Blue light we need to clear bit 2 (zero-based index remember)
                        //      
                        //      bit 2's mask value is 4 so...
                        //
                        //      var flipped = ~4 would give us 1011
                        //
                        //      alternatively, to save having to calculate the mask value, we can use a bit shift
                        //      operation to do that for us.  simply take the bit index and use the bit shift operator
                        //      on 1.
                        //
                        //      var flipped = ~(1 << 2);   // this also gives us 1011
                        // 
                        //      if we then work out all the bits that remain in common between that and the original colour mask...
                        //
                        //      var newMask = flipped & colourMask;   // only use a single & (bitwise AND) | (bitwise OR) for bitwise operations.
                        //
                        //      newMask is then == 0001;   // bit 2 is now clear.
                        //
                        //      below we're doing exactly the same thing, but choosing a light at random and bitshifting it straighaway (above)
                        //      then combining the ones complement (~) the bitwise ANDing (&) and the assignment (=) in a single statement.
                        //
                        //      it looks complicated.  but everybody writes this kinda thing this way so practice a lot so you can get used to it :-)
                        //      
                        theatreLights &= ~randomLightMask;
                    }
                    else
                    {
                        // light is off; turn it on.
                        //
                        // this way round is a lot simpler :-)   all we have to do is a bitwise OR of the randomly chosen light's mask value with the existing
                        // mask and if it's not already set, it will be set.

                        theatreLights |= randomLightMask;
                    }
                }
            };

            var lightScenes = new Dictionary<string, ColourMask>();
            loopColourMasks(c =>
            {
                var scene = $"Scene {c}";
                lightScenes.TryAdd(scene, 0);
                loopColourMasks(c =>
                {
                    // just a different way of assigning something at random
                    var lightOn = DateTime.Now.Ticks % 2 == 0;
                    if (lightOn) lightScenes[scene] |= c;
                });
            });

            // then to display the settings...
            foreach (var scene in lightScenes)
            {
                Console.Write($"{scene.Key}: ");
                loopColourMasks(c => Console.Write($"{c} = {(scene.Value.HasFlag(c) ? "on" : "off")}, "));
                Console.WriteLine();
            }

            // now go thru the show, loading the lighting set into the rig
            foreach (var kvp in lightScenes)
            {
                var scene = kvp.Key;
                var sceneSet = kvp.Value;
                Console.WriteLine($"- - - - - - - - - -\nSetting {scene}");
                // deliberately not using scene name, here...
                setScene(sceneSet);
                loopColourMasks(c =>
                {
                    var actualLightState = $"is {(theatreLights.HasFlag(c) ? "on" : "off")}";
                    var expectedLightState = sceneSet.HasFlag(c) ? "on" : "off";
                    var statement = sceneSet.HasFlag(c) == theatreLights.HasFlag(c)
                        ? $"is working ({actualLightState})"
                        : $"{actualLightState} but should be {expectedLightState}";

                    Console.WriteLine($"{c} light {statement}");
                });

                loopColourMasks(c =>
                {
                    if (!theatreLights.HasFlag(c).Equals(sceneSet.HasFlag(c)))
                    {
                        Console.WriteLine($"- - - - - - - - - -\nProblem in {lightScenes.FirstOrDefault(kvp => kvp.Value == sceneSet).Key}");
                    }
                });
            }

            // so you can see how much easier that and how much easier it is to read...?

            // finally let's look at combinations.   say our theatre director has asked for a particular combination of colours
            // and the production designer goes, "again?!  most of these scenes are just blue and orange!"
            // so the director gets in a huff and goes " no they're not!"
            // to save time settling the dispute, they ask you to search your lighting settings to see many scenes are just blue and orange.
            // 
            // so...let's create a shed load more scenes to check thru...

            for (var i = 0; i < 100; i++)
            {
                var scene = $"Scene {i}";
                lightScenes.TryAdd(scene, 0);
                var picker = rand.Next(0, 7);
                var m = ColourMask.None;
                m |= (picker % 2 == 0) ? ColourMask.Red : ColourMask.Orange;
                m |= (picker % 3 == 0) ? ColourMask.Blue : ColourMask.Indigo;
                m |= (picker % 4 == 0) ? ColourMask.Violet : ColourMask.None;
                m |= (picker != 6) ? (ColourMask)(1 << picker) : ColourMask.None;

                lightScenes[scene] |= m;

            }

            var blueOrangeMask = ColourMask.Blue | ColourMask.Orange;
            Console.WriteLine($"---- Just {blueOrangeMask} ----");
            Console.WriteLine(string.Join("", lightScenes.Where(scene => scene.Value == blueOrangeMask).Select(scene => $"\n    {scene.Key}: {scene.Value}")));

            // so then the production designer says, "well not on they're own obviously but I bet there's load with blue and orange and lot a lot else!".
            // okay, so you go figure that out tooo....
            Console.WriteLine($"---- At least {blueOrangeMask} ----");
            Console.WriteLine(string.Join("", lightScenes.Where(scene => scene.Value.HasFlag(blueOrangeMask)).Select(scene => $"\n    {scene.Key}: {scene.Value}")));

            // but he's still not happy cuz there a scenes coming back with more than 1 extra colour so they refine their requirements
            // to be scenes with blue + orange + 0 or 1 other colour only.
            Console.WriteLine($"---- {blueOrangeMask} + at most 1 other colour ----");
            var maskValues = new List<ColourMask>((ColourMask[])Enum.GetValues(typeof(ColourMask)));
            Console.WriteLine(string.Join("",
                    lightScenes.Where(scene =>
                    {
                        var hasBlueAndOrange = scene.Value.HasFlag(blueOrangeMask);
                        var otherColoursInScene = scene.Value & ~blueOrangeMask;
                        var otherColourCount = maskValues.Count(mask => otherColoursInScene.HasFlag(mask) &&  !blueOrangeMask.HasFlag(mask) && mask != ColourMask.None);
                        return hasBlueAndOrange && otherColourCount <= 1;
                    })
                    .Select(scene => $"\n    {scene.Key}: {scene.Value}")));

        }
    }

    public class SceneLights
    {
        public ColourMask Wash { get; }
        public ColourMask Spots { get; }
        public bool FollowSpot { get; }
    }

    public class EnumList<TListType, TEnumIndexerType> : List<TListType>
    {
        public TListType this[TEnumIndexerType enumIndex] => this[Convert.ToInt32(enumIndex)];
    }

    public class NamedFlags
    {
        private Dictionary<string, NamedBool> data;
        public bool Red => data["Red"].IsTrue;
        public bool Blue => data["Blue"].IsTrue;

        // and so on.  and you've still got to maintain and police the dictionary...
    }
    public class NamedBool
    {
        public NamedBool(string name, bool isTrue)
        {
            Name = name;
            IsTrue = isTrue;
        }

        public string Name { get; }
        public bool IsTrue { get; set; }
    }
    public static class FlagX
    {
        public static string BinaryString(this int source, int numBits)
        {
            return string.Join(" ", Convert.ToString(source, 2).PadLeft(numBits, '0').SplitEvery(4));
        }
        public static string BinaryString(this uint source, int numBits)
        {
            return string.Join(" ", Convert.ToString(source, 2).PadLeft(numBits, '0').SplitEvery(4));
        }
        public static List<string> SplitEvery(this string source, int tokenSize)
        {
            var tokens = new List<string>();
            var pos = 0;
            while (pos < source.Length)
            {
                tokens.Add(pos + tokenSize <= source.Length ? source.Substring(pos, tokenSize) : source.Substring(pos));
                pos += tokenSize;
            }
            return tokens;
        }
    }
}