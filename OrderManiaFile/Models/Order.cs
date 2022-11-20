using System;
using System.Collections.Generic;

namespace OrderMania
{
    public class Order
    {
        public static int Id{get; set;}
        public int OrderNumber{get; private set;}
        public string AttendantId{get; set;}
        public string CustomerId{get; set;}
        public List<OrderMenuItem> MenuItem{get; set;}
        public string MenuItemm {get; set;}
        public int Price{get; set;}
        public DateTime OrderDate{get; set;}



        public Order(int id, int orderNumber, string attendantId, string customerId, string menuItemm, int price, DateTime orderDate)
        {
            Id = id;
            OrderNumber = orderNumber;
            AttendantId = attendantId;
            CustomerId = customerId;
            Price = price;
            OrderDate = orderDate;
            MenuItemm = menuItemm;
            // OrderNumber++;
        }

        public override string ToString()
        {
            return $"{Id}\t{OrderNumber}\t{AttendantId}\t{CustomerId}\t{Price}\t{OrderDate}";
        }

        public static Order ToOrder(string order)
        {
            var stringOrder = order.Split("\t");
            var currentOrder = new Order (int.Parse(stringOrder[0]), int.Parse(stringOrder[1]), stringOrder[2], stringOrder[3],stringOrder[4], int.Parse(stringOrder[5]), DateTime.Parse(stringOrder[6]));
            return currentOrder;
        }
        
    }
}