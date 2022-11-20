using System;
using System.Collections.Generic;
using System.IO;

namespace OrderMania
{
    public class CustomerRepository : ICustomerRepository
    
    {  
        public static List<Customer> customers;
        public string path = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files\customer";

        public CustomerRepository()
        {
            customers = new List<Customer>();
            ReadFromFile();
        }

        public void WriteToFile(Customer customer)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(path, true))
                {
                    write.WriteLine(customer.ToString());
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
                foreach(var item in customers)
                {
                    write.WriteLine(item.ToString());
                }
            }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Customer> GetAll()
        {
            return customers;
        }

        public Customer GetByCode(string code)
        {
            return customers.Find(i => i.CustomerCode == code);
        }

        public Customer GetByEmail(string email)
        {
            return customers.Find(i => i.Email == email);
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
                        var customer = Customer.ToCustomer(line);
                        customers.Add(customer);
                    }
                }
                else
                {
                    // var dir = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files";
                    // Directory.CreateDirectory(dir);
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

        public List<Customer> GetAllLoyalCustomer()
        {
            var loyalCust = customers.FindAll(i => i.IsLoyalCustomer == true);
            return loyalCust;
        }
    }
}