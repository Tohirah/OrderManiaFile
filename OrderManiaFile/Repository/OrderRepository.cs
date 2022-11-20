using System;
using System.Collections.Generic;
using System.IO;

namespace OrderMania
{
    public class OrderRepository : IOrderRepository
    {
        public static List<Order> orderHistory;
        string path = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files\order";

        public OrderRepository()
        {
            orderHistory = new List<Order>();
            ReadFromFile();
        }
        public List<Order> ReadOrderHistory()
        {
            return orderHistory;
        }

        public void AddToHistory(Order neworder)
        {
            try
            {
                 using(StreamWriter write = new StreamWriter(path, true))
                 {
                    write.WriteLine(neworder.ToString());
                 }
            }
            catch (System.Exception)
            {
                
                throw;
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
                        var order = Order.ToOrder(line);
                        orderHistory.Add(order);
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
        
         public void RefreshFile()
        {
            try
            {
                 using (StreamWriter write = new StreamWriter(path))
                 {
                    foreach (var item in orderHistory)
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


        public List<Order> GetAll()
        {
            return orderHistory;
        }

        public Order GetByCode(int code)
        {
            return orderHistory.Find(i => i.OrderNumber == code);
        }

        public List<Order> GetByDate(DateTime date)
        {
            var listOfOrder =  orderHistory.FindAll(i => i.OrderDate == date);
            return listOfOrder;
        }

        public List<Order> GetByAttedant(string attendantCode)
        {
            var listOfOrder =  orderHistory.FindAll(i => i.AttendantId == attendantCode);
            return listOfOrder;
        }

        public List<Order> GetByCustomer(string customerCode)
        {
            var listOfOrder =  orderHistory.FindAll(i => i.CustomerId == customerCode);
            return listOfOrder;
        }

    }
}