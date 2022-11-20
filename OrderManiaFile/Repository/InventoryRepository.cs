using System;
using System.Collections.Generic;
using System.IO;

namespace OrderMania
{
    public class InventoryRepository : IInventoryRepository
    {
        public static List<MenuItem> items;
        string path = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files\inventory";

        public InventoryRepository()
        {
            items = new List<MenuItem>();
            ReadFromFile();
        }
        public void RefreshFile()
        {
            try
            {
                 using (StreamWriter write = new StreamWriter(path))
                 {
                    foreach (var item in items)
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
                        var item = MenuItem.ToMenuItem(line);
                        items.Add(item);
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

        public void WriteToFile(MenuItem item)
        {
            try
            {
                 using(StreamWriter write = new StreamWriter(path, true))
                 {
                    write.WriteLine(item.ToString());
                 }
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
            }
        }

        public List<MenuItem> GetAll()
        {
            return items;
        }

        public MenuItem GetByCode(string code)
        {
            return items.Find(i => i.ItemCode == code);
        }

        public bool IsItemAvailable(string code)
        {
            var item = GetByCode(code);
            return item.Active;
        }

        public int CheckQuantity(string code)
        {
            var item = items.Find(i => i.ItemCode == code);
            return item.QuantityInStore;
        }
    }
}