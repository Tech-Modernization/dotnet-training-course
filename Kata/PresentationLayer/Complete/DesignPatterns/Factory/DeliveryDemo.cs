using System;
using System.Collections.Generic;
using System.Text;

/*
 * "Define as many interfaces as ISP (Interface Segregation Principle) dictates to represent the operational components of  goods-in department at a large company.   Over the course of a week the following take place:

- deliveries arrive by lorry, van and courier.  
- van and lorry deliveries are ID checked at the rear security gate.
- courier deliveries are made to reception, which are then passed on to goods-in for processing.  courier id is not checked but a full airport-style scan is required.
- lorry and van deliveries are made to goods-in and the items security scanned before entering the premises.
- food and beverage items are taken to the kitchen, a tracking receipt is obtained with a contact name and employee ID.
- stationery is taken to the office manager to be signed for.
- out of hours (mon-fri 8-4.30) kitchen and office supplies are placed in a holding cage to be delivered on the next working day.
- letters and parcels with department or individual addresses are sorted by department and floor.
- department deliveries are carried out at 11am and 4pm.
- shift changes occur at 7am and 3.30pm.
- a handover of ongoing tasks is done between shifts.
- the night shift begins at 23:30.   a security guard is also on this shift.
- weekend shift is 7-19 and 1900-0700 with security present from night-shift Friday to morning shift Monday - Tuesday for Bank Holidays.
- out of hours deliveries are permitted with prior arrangement and authentication.  
- ooh shifts must be full staffed.  on-call team members are available to fill shifts at short notice.
*/
namespace Kata.Demos
{
    public class DeliveryDemo : DemoBase
    {
        public void Run()
        {
            throw new NotImplementedException();
        }
    }

    public enum OfficeLocation
    {
        Reception,
        Security,
        HoldingCage,
        Kitchen,
        Facilities
    }

    public enum DeliveryMode
    {
        Courier, Van, Lorry
    }

    public class DepartmentBase { }
    public class ItemBase { }

    public class DeliveryDictionary : Dictionary<DepartmentBase, List<ItemBase>>
    {

    }

    public interface IGoodsInManager
    {

    }

    public class VisitorBase { }

    public interface ISecurityManager
    {
        bool VerifyVisitorId(VisitorBase visitor);
        bool VisitorSecurityScan(VisitorBase visitor);
        OfficeLocation DirectVisitor(VisitorBase visitor);
    }

    public class ScheduleBase { }
    public interface IScheduler
    {
        ScheduleBase ScheduleInternalDelivery(List<ItemBase> item, OfficeLocation destination);
        ScheduleBase ScheduleExternalDelivery(List<ItemBase> item, List<VisitorBase> visitors);
    }


    public class TrackingReceipt { }
    public interface IDeliveryProcessor
    {
        OfficeLocation RouteDelivery(ItemBase item, OfficeLocation receiptLocation);
        DeliveryDictionary SortPost(List<ItemBase> items);
        TrackingReceipt DeliverItem(ItemBase item, OfficeLocation destination);
        void DeliverPost(DeliveryDictionary postItems);
    }

    public class HandoverBase { }
    public class ShiftBase { }

    public class OnCallShift { }

    public interface IShiftManager
    {
        List<HandoverBase> ShiftChange(ShiftBase incomingShift, ShiftBase outgoingShift);
        bool ValidateShift(ShiftBase shift);
        bool MakeUpShift(ShiftBase shift, OnCallShift onCallShift);
        ShiftBase GetNextShift();
        ShiftBase GetCurrentShift();
    }
}
