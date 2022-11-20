using System;

namespace OrderMania
{
    public class OrderMenuItem
    {
        public int OrderId{get; set;}
        public string MenuItemId {get; set;}

        public int Quantity{get; set;}

        public int UnitPrice{get;set;}

        public int TotalPrice(int qty, int uPrice)
        {
            return qty * uPrice;
        }
        public OrderMenuItem(int orderId, string menuItemId, int quantity, int unitPrice) // int totalPrice)
        {
            OrderId = orderId;
            MenuItemId = menuItemId;
            Quantity = quantity;
            UnitPrice = unitPrice;
            // TotalPrice = totalPrice;
        }

         public override string ToString()
        {
            return $"{OrderId}\t{MenuItemId}\t{Quantity}\t{UnitPrice}";
        }

        public static OrderMenuItem ToOrderMenuItem(string item)
        {
            var currentOrder = item.Split("\t");
            OrderMenuItem orderItem = new OrderMenuItem(int.Parse(currentOrder[0]), currentOrder[1], int.Parse(currentOrder[2]), int.Parse(currentOrder[3]));
            return orderItem;
        }

    }
}