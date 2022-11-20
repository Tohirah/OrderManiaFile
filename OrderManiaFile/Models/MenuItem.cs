using System;

namespace OrderMania
{
    public class MenuItem
    {
        public int Id{get; set;}
        public string ItemCode{get; set;}
        public string ItemName{get; set;}
        public int QuantityInStore{get; set;}
        public int UnitPrice {get; set;}

        public bool Active{get; set;}

        public MenuItem(int id, string itemCode, string itemName, int quantityInStore, int unitPrice, bool active)
        {
            Id = id;
            ItemCode = itemCode;
            ItemName = itemName;
            QuantityInStore = quantityInStore;
            UnitPrice = unitPrice;
            Active= active;
        }

        public override string ToString()
        {
            return $"{Id}\t{ItemCode}\t{ItemName}\t{QuantityInStore}\t{UnitPrice}\t{Active}";
        }

        public static MenuItem ToMenuItem(string menu)
        {
            var currentItem = menu.Split("\t");

            MenuItem item = new MenuItem(int.Parse(currentItem[0]), currentItem[1], currentItem[2], int.Parse(currentItem[3]), int.Parse(currentItem[4]), bool.Parse(currentItem[5]));
            return item;
        }
        
    }
}