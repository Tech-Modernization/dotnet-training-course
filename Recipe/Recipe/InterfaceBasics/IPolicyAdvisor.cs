using System;
using System.Collections.Generic;
using System.Text;

namespace Recipe.InterfaceBasics
{
    // 1. an interface is like a job description in an HR dept.
    //    to define the role of a policy advisor, they need to draw up a list of the responsibilities
    //    it's the same for an interface.  
    //   
    //    say the company hires Kathryn to join the customer services operation, she will need her own means of 
    //    performing those functions.

    public interface IPolicyAdvisor
    {
        void AnswerPhone();
        void AddNewCustomer();
        void LookupPolicy();

    }
}
