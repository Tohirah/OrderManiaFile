using System;
using System.Collections.Generic;

namespace OrderMania
{
    public interface IAdminRepository
    {
        List<Admin> GetAll();

        Admin GetById(int Id);
        void WriteToFile(Admin admin);
        void ReadFromFile();
        void RefreshFile(List<Admin> admin);
        Admin GetByEmailAndPassword(string email, string password);
    }
}