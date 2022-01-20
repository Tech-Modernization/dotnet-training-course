using System;

namespace BusinessObjectLayer.Soshal
{
    public class SoshalContainer : ISoshalContainer
    {
        IMemberService memberService;

        public SoshalContainer(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        public void Run()
        {
            Console.Clear();
            var member = memberService.Login();
            if (member != null)
            {
                Console.WriteLine($"Hello {member.Name}!\nYour birthday is {member.Birthday:d}");
                return;
            }

            Console.WriteLine("See you soon to sign up for the most fun social network on earth!");
        }
    }
}