using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessObjectLayer.GoodsInAbstractFactory
{
    public abstract class OperationsFactory
    {
        protected abstract ShiftBase CreateShift();
        protected abstract VisitorBase CreateVisitor();
    }
    public class BauShiftOperation : OperationsFactory
    {
        protected override ShiftBase CreateShift()
        {
            throw new NotImplementedException();
        }

        protected override VisitorBase CreateVisitor()
        {
            throw new NotImplementedException();
        }
    }
    public class OohShiftOperation : OperationsFactory
    {
        protected override ShiftBase CreateShift()
        {
            throw new NotImplementedException();
        }

        protected override VisitorBase CreateVisitor()
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

    public class DeliveryDictionary : Dictionary<DepartmentBase, List<ItemBase>>
    {

    }

    public interface IGoodsInManager
    {

    }

    public interface ISecurityManager
    {
        bool VerifyVisitorId(VisitorBase visitor);
        bool VisitorSecurityScan(VisitorBase visitor);
        OfficeLocation DirectVisitor(VisitorBase visitor);
    }

    public interface IScheduler
    {
        ScheduleBase ScheduleInternalDelivery(List<ItemBase> item, OfficeLocation destination);
        ScheduleBase ScheduleExternalDelivery(List<ItemBase> item, List<VisitorBase> visitors);
    }

    public interface IDeliveryProcessor
    {
        OfficeLocation RouteDelivery(ItemBase item, OfficeLocation receiptLocation);
        DeliveryDictionary SortPost(List<ItemBase> items);
        TrackingReceipt DeliverItem(ItemBase item, OfficeLocation destination);
        void DeliverPost(DeliveryDictionary postItems);
    }

    public interface IShiftManager
    {
        List<Handover> ShiftChange(ShiftBase incomingShift, ShiftBase outgoingShift);
        bool ValidateShift(ShiftBase shift);
        bool MakeUpShift(ShiftBase shift, OnCallShift onCallShift);
        ShiftBase GetNextShift();
        ShiftBase GetCurrentShift();
    }

    public abstract class ShiftBase { }
    public class OnCallShift : ShiftBase {}
    public abstract class DepartmentBase { }
    public abstract class VisitorBase { }
    public abstract class ItemBase { }
    public abstract class ScheduleBase { }
    public abstract class Handover { }
    public abstract class TrackingReceipt { }
    public abstract class StaffBase { }

}
