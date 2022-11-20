using System;

namespace OrderMania
{
    interface IAdminService
    {
        Admin CreateAdmin(string email,string lastName,string firstName, Gender Gender, string password,string CPassword, string phoneNo);
        Admin Login(string email, string Password);
        Admin UpdateProfile(Admin admin);
        void ViewProfile(int id);
        void ChangePassword(Admin admin);
    } 
}