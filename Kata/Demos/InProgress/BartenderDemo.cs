using Kata.CustomTypes.Bartender;

using System;
using System.Collections.Generic;
using System.Text;

/*
 * objectives:
 * 
 * - the bartender must serve customers in order they arrive at the bar
 * - the bartender must total up the round
 * - the customer can pay with card, notes or right change
 * - customers can buy each other drinks
 * - the bartender may need to change the barrel/optic, go for a wee etc.
 * - customers will continue to arrive while the bartender is unavailable
 * - some customers might be barred
 * - some customers might be "over served" and need ot be cut off
 * - some customers might be underage - bartender needs to ID them
 * - bartender can run a tab
 * - (bartender can be challenged on the order of service)
 * - bartender must call last orders and time
 */

// Part A - Analysis
//
// 1. think about each concept in turn and tell its story
// 2. identify abstract ideas to combine details 
// 3. assess impact of events in story (always ask "what if")
// 4. evaluate ideas in ascending order of complexity
// 5. identify all the possible implications of each objective 
//
// Part B - Enrichment
// 
// 6. identify the data items for each concept
// 7. identify the process for resolving the unknowns
// 


namespace Kata.Demos.Kata
{
    public class Bartender : IPaymentProcessor
    {
        public PaymentMethod GetPaymentMethod(Customer cust)
        {
            return PaymentMethod.Cash;
        }

        public PaymentResult TakePayment(Payment payment, Customer cust)
        {
            // customer will need method to "decide" what to tender
            payment.AmountTendered = 20.00M;
            var change = payment.CalculateChange();
            Console.WriteLine($"Change was calculated {(change ? "successfully" : "unsuccessfully")} ({payment.ChangeDue:C})");
            OfferChange(payment, cust);
            Console.WriteLine($"Customer {(payment.ChangeAccepted ? "accepted change" : "did not accept change")}");
            return (payment.ChangeAccepted) ? PaymentResult.ChangeAccepted : PaymentResult.ChangeChallenged;
        }

        private void OfferChange(Payment payment, Customer cust)
        {
            payment.ChangeAccepted = true;
        }
    }
    public class BartenderDemo : DemoBase
    {
        private Menu menu = new Menu();

        public override void Run()
        {
            AddPart(Part1, "Set up the drinks");
            AddPart(Part2, "Set up the order (payment)");
            base.Run();
        }

        public void Part1()
        {
            menu.Display();
        }

        public void Part2()
        {
            var barkeep = new Bartender();
            var payment = new Payment(12.75M);
            Console.WriteLine($"The total due is {payment.AmountDue:C}");
            var cust = new Customer();
            payment.Method = barkeep.GetPaymentMethod(cust);
            Console.WriteLine($"Customer wants to pay with {payment.Method}");

            var payResult = barkeep.TakePayment(payment, cust);

            Console.WriteLine($"Order totalling {payment.AmountDue:C} payment result: {payResult}");

        }
        // 1. think about each concept in turn and tell its story
        //   a. identify the most fundamental thing about the problem.
        //      e.g. in this case, drinking is secondary and pouring drinks is secondary
        //           cuz what connects the customer and the bartender is money.  so the
        //           first story we tell is about money.
        // e.g.
        // from the bartender's pov:
        //     - asking for payment
        //     - receiving payment
        //         - possibly giving change
        // 
        // from the customer's pov:
        //     - how much you've got
        //     - how much you intend to drink (school night etc),
        //     - conserving funds for taxi, kebab (post-pub-actions) 
        //     - preferred payment method 
        //     - who's round is it
        // 
        // 2. identify abstract ideas to combine details 
        //    e.g. the taxi and the kebab are post-pub-actions and 
        //      as soon as the taxi idea came to us, the kebab followed
        //      cuz our brains were rememembering what we do after the pub.
        //      and that's abstract thinking!
        //
        // 3. assess impact of events in story (always ask "what if")
        //    e.g. what to do if the customer is underage or appears that way.
        //
        // 4. evaluate ideas in ascending order of complexity
        //   e.g.  before dealing with receiving payment,
        //   we must solve the problem of asking for payment
        //
        // 5. identify all the possible implications of each objective 
        //  
        // possible requirements:
        // - the concept of a bar to encapsulate the activity
        // - a customer thing
        // - a drink thing
        // - menu thing
        // - payment method, amount, tab, till 
        // - a bartender
        // - a queue thing
        // - an order thing
        // - stock levels (barrel change, optics...)
        // 
        /*
         * Problem order: (identify the smallest, most fundamental aspect)
         * 
         * - menu
         *   - drink(s)
         *   * price
         *     * name
         *   * measure
         * - order 
         *   - payment
         *     - method
         *     - amount due 
         *     - amount tendered
         *     - change
         *   - items
         *   - customer 
         * - customer 
         * - queue
         * - bartender
         * - bar itself
         */
    }
}