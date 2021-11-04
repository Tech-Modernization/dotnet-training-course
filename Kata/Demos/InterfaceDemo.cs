using System;
using System.Collections.Generic;
using System.Text;


namespace Kata.Demos
{
    public class InterfaceDemo : IDemo
    {
        public void Run()
        {
            // let's say I wanna create a "database" of album chart history.
            //
            // i need a list of positions and a list of dates when the chart was published
            // i also need a list of albums.
            // i then need to associate each of those data items with each other to represent
            // the historical state of the chart.
            //
            // in order to build and interrogate the database I'll need a few methods:
            //
            // - add to the list of entries
            // - search the list by position, date and album
            //
            // see IChartHistorian below.
            //
            // ISP (Interface Segregation Principle - the I in SOLID) means that we have to split this 
            // interface into its component parts so that implementers do not have to provide code for 
            // bits they don't need.
            //
            // E.g.  If I am a developer writing a website that looks up chart positions for albums, 
            //       I don't need to create those albums or the chart data.  See InternetMusicDude class below
            //
            //       you can see that implementing IChartHistorian requires the class to provide a means of
            //       adding to the lists, which is not that class's responsibility.  so it can be seen how 
            //       breaking ISP can also break SRP (Single Responsibility Principle).
            //
            // There is a clear distinction between building the datasbase and interrogating it so we divide 
            // this interface into 2 separate ones.
            //
            // See IChartBuilder and IChartInterrogater below
            //
            // So now InternetMusicDude can stop worrying about having dead code in his app.  See InternetMusicDudeISP.
            // By implementing only the interrogater, the app guy can achieve his objective.
            //
            // 


        }

        public interface IChartBuilder
        {
            void AddAlbum(string album);
            void AddChartUpdate(DateTime publicationDate, int position, string album);

        }

        public interface IChartInterrogater
        {
            bool SearchByPosition(int position);
            bool SearchByAlbum(string album);
            bool SearchByDate(DateTime dt);
        }

        public interface IChartHistorian
        {
            void AddAlbum(string album);
            void AddChartUpdate(DateTime publicationDate, int position, string album);
            bool SearchByPosition(int position);
            bool SearchByAlbum(string album);
            bool SearchByDate(DateTime dt);
        }

        public class InternetMusicDude : IChartHistorian
        {
            public void AddAlbum(string album)
            {
                throw new NotImplementedException();
            }

            public void AddChartUpdate(DateTime publicationDate, int position, string album)
            {
                throw new NotImplementedException();
            }

            public bool SearchByAlbum(string album)
            {
                throw new NotImplementedException();
            }

            public bool SearchByDate(DateTime dt)
            {
                throw new NotImplementedException();
            }

            public bool SearchByPosition(int position)
            {
                throw new NotImplementedException();
            }
        }

        public class InternetMusicDudeISP : IChartInterrogater
        {
            public bool SearchByAlbum(string album)
            {
                throw new NotImplementedException();
            }

            public bool SearchByDate(DateTime dt)
            {
                throw new NotImplementedException();
            }

            public bool SearchByPosition(int position)
            {
                throw new NotImplementedException();
            }
        }
    }
}
