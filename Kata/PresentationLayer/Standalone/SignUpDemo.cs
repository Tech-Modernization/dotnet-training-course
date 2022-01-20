using BusinessObjectLayer.Soshal;
using System;
using System.Collections.Generic;
using System.Text;

namespace PresentationLayer.Standalone
{
    public class SignUpDemo : DemoBase
    {
        public override void Run()
        {
            var jsonService = new JsonDataService();
            var memberService = new SoshalMemberService(jsonService);
            var soshal = new SoshalContainer(memberService);
            soshal.Run();
        }
    }
}
