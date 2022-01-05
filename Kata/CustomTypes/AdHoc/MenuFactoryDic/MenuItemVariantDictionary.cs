using System;
using System.Collections.Generic;
using System.Text;

namespace Kata.CustomTypes.MenuFactoryDic
{
    public class MenuItemVariantDictionary : MenuItemVariantDictionary<DefaultVariant, DefaultVariant> { }
    public class MenuItemVariantDictionary<T1, T2> : Dictionary<MenuItemVariant<T1, T2>, decimal>
    {
        public bool SuppressWarnings = true;
        public bool UpdateOnKeyExists = false;

        public void AddVariant(T1 firstVar, T2 secondVar, decimal price)
        {
            var destKey = new MenuItemVariant<T1, T2>(firstVar, secondVar);
            if (ContainsKey(destKey))
            {
                if (UpdateOnKeyExists)
                {
                    if (!SuppressWarnings)
                    {
                        Console.WriteLine($"Updated duplicate key {destKey} in {GetType().Name}: {this[destKey]:C} => {price:C}");
                    }
                    this[destKey] = price;
                    return;
                }

                if (SuppressWarnings)
                {
                    throw new Exception("Duplicate key encountered");
                }
                else
                {
                    Console.WriteLine($"Duplicate key {destKey} encountered in {GetType().Name}:"
                        + $" existing/new values = {this[destKey]:C} / {price:C}");
                }
            }
            else
            {
                Add(destKey, price);
            }
        }
    }
}
