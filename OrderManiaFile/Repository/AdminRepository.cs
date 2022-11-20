using System;
using System.Collections.Generic;
using System.IO;

namespace OrderMania
{
    public class AdminRepository : IAdminRepository
    {
        public static List<Admin> admins;
        public string path = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files\admin";

        public AdminRepository()
        {
            admins = new List<Admin>();
            ReadFromFile();
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
                        var admin = Admin.ToAdmin(line);
                        admins.Add(admin);
                    }
                }
                else
                {
                    
                    using (File.Create(path))
                    {}

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WriteToFile(Admin admin)
        {
            // try
            // {
                using (StreamWriter write = new StreamWriter(path, true))
                {
                    write.WriteLine(admin.ToString());
                }
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine(ex.Message);
            // }
        }

        public void RefreshFile(List<Admin> admins)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(path))
                foreach(var item in admins)
                {
                    write.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Admin GetById(int id)
        {
            return admins.Find(i => i.Id == id);
        }

        public List<Admin> GetAll()
        {
            return admins;
        }
        
        public Admin GetByEmailAndPassword(string email, string password)
        {
            var Admin =  admins.Find(i => i.Email == email);
        
            if(Admin != null && Admin.Password == password)      return Admin;
            
            else return null;
        }
    }
}