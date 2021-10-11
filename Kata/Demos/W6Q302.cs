using System;
using System.Collections.Generic;
using System.Text;

namespace Demos
{
    public abstract class RecyclingBin
    {
        private List<WasteItem> items = new List<WasteItem>();
        public List<WasteItem> Items { get { return items; } }
        public RecyclingBin()
        {
            CreateItems();
        }
        protected abstract void CreateItems();
    }
    public abstract class WasteItem { }
    public class GlassRecyclingBin : RecyclingBin
    {
        protected override void CreateItems()
        {
            Items.Add(new Bottle("Wine"));
            Items.Add(new Bottle("Beer"));
            Items.Add(new Bottle("Milk"));
        }
    }
    public class CarboardRecyclingBin : RecyclingBin
    {
        protected override void CreateItems()
        {
            Items.Add(new Newspaper());
            Items.Add(new Box());
            Items.Add(new Carton());
        }
    }
    public class Bottle : WasteItem { private string name; public Bottle(string name) { this.name = name; } }
    public class Box : WasteItem { }
    public class Carton : WasteItem { }
    public class Newspaper : WasteItem { }



}
