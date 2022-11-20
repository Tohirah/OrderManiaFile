using System;
using System.Collections.Generic;
using System.IO;

namespace OrderMania
{
    public class AttendantRepository : IAttendantRepository
    {
        public static List<Attendant> attendants;
        public string path = @"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files\attendant";

        public AttendantRepository()
        {
            attendants = new List<Attendant>();
            ReadFromFile();
        }

        public void WriteToFile(Attendant attendant)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(path, true))
                {
                    write.WriteLine(attendant.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RefreshFile(List<Attendant> attendants)
        {
            try
            {
                using (StreamWriter write = new StreamWriter(path))
                foreach(var item in attendants)
                {
                    write.WriteLine(item.ToString());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public Attendant GetByCode(string code)
        {
            return attendants.Find(i => i.AttendantCode == code);
        }

        public Attendant GetByEmail(string email)
        {
            return attendants.Find(i => i.Email == email);
        }

        public Attendant GetById(int id)
        {
            return attendants.Find(i => i.Id == id);
        }

        public List<Attendant> GetAll()
        {
            return attendants;
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
                        var attendant = Attendant.ToAttendant(line);
                        attendants.Add(attendant);
                    }
                }
                else
                {
                    // var dir =@"C:\Users\Owner\Desktop\CLH\Second Class\OrderMania Files";
                    // Directory.CreateDirectory(dir);
                    using (File.Create(path))
                    {}

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Attendant> GetAllAttedantOnShift()
        {
            var AttedantonShift = attendants.FindAll(i => i.IsOnShift == true);
            return AttedantonShift;
        }
    }
}