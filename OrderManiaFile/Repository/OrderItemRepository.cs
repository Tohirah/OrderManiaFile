using System;
using System.Collections.Generic;
using System.IO;

namespace OrderMania
{
    public class OrderItemRepository : IOrderItemRepository
    {
        public static List<OrderMenuItem> OrderItems;
        string path = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files\order item";

        public OrderItemRepository()
        {
            OrderItems = new List<OrderMenuItem>();
            ReadFromFile();
        }
        public void WriteToFile(OrderMenuItem orderItem)
        {
            try
            {
                 using(StreamWriter write = new StreamWriter(path, true))
                 {
                    write.WriteLine(orderItem.ToString());
                 }
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public void RefreshFile()
        {
            try
            {
                 using (StreamWriter write = new StreamWriter(path))
                 {
                    foreach (var item in OrderItems)
                    {
                    Console.WriteLine(item.ToString());
                    }
                 }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }

        public void ReadFromFile()
        {
            try
            {
                 if(File.Exists(path))
                 {
                    var lines = File.ReadAllLines(path);

                    foreach(var line in lines)
                    {
                        var orderItem = OrderMenuItem.ToOrderMenuItem(line);
                        OrderItems.Add(orderItem);
                    }
                 }
                 else
                 {
                    using (File.Create(path))
                    {
                    }
                 }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }

        public List<OrderMenuItem> GetAll()
        {
            return OrderItems;
        }

        public List<OrderMenuItem> GetByOrderId(int id)
        {
            var orderMenu = OrderItems.FindAll(i => i.OrderId == id);
            return orderMenu;
        }

        
    }
}

    