using System;
using System.Collections.Generic;

namespace OrderMania
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepo;
        public AdminService()
        {
            _adminRepo = new AdminRepository();
        }
        public Admin CreateAdmin(string email,string lastName,string firstName, Gender gender, string password,string CPassword, string phoneNo)
        {

             int id = 0;
             var admins = _adminRepo.GetAll();
            if(admins.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = admins[admins.Count - 1].Id +1;
            }
            if(firstName == null)
            {
                Console.WriteLine("First Name cannot be empty");
                return null;
            }
                if(email ==  null)
            {
                Console.WriteLine("Email cannot be empty");
                return null;
            }
            if(password == null)
            {
                Console.WriteLine("Password cannot be empty");
                return null;
            }
            if(phoneNo == null)
            {
                Console.WriteLine("Phone number cannot be empty");
                return null;
            }
            if(password != CPassword)
            {
                Console.WriteLine("Passwords do not match");
                return null;
            }

            string code = Guid.NewGuid().ToString();
            string adminCode = $"{firstName}/{code}";

            Admin admin =new Admin(adminCode, id, firstName, lastName, gender, phoneNo, email, password);
                    // admins.Add(admin);
            _adminRepo.WriteToFile(admin);
            // _adminRepo.ReadFromFile();
            return admin;
            }


        public Admin Login(string email, string password)
        {

            var Admin = _adminRepo.GetByEmailAndPassword(email, password);
            if(Admin != null && Admin.Password == password)
            {
                Console.WriteLine("Login Successful");
                return Admin;
            }
            else
            {
                Console.WriteLine("Email/Password is invalid");
                return null;
            }
            
        }

        public Admin UpdateProfile(Admin admin)
        {
            Console.WriteLine("Enter the updated information here");
            
                Console.WriteLine("Enter new First Name");
                string firstName = Console.ReadLine();
                admin.FirstName = firstName;
                
                Console.WriteLine("Enter new Last Name");
                string lastName = Console.ReadLine();
                admin.LastName = lastName;
                Console.WriteLine("Enter new Email");
                string email = Console.ReadLine();
                admin.Email = email;
                Console.WriteLine("Enter new Phone Number");
                string phone = Console.ReadLine();
                admin.PhoneNumber = phone;
                // Console.WriteLine("Invalid input");
                var updateAdmin = _adminRepo.GetAll();
                _adminRepo.RefreshFile(updateAdmin);
                return admin;
            }

            public void ViewProfile(int id)
            {
                var admin = _adminRepo.GetById(id);
                if(admin != null)
                {
                    Console.WriteLine("ViewProfile Details for" + id);
                    Console.WriteLine("Admin Number: " + admin.AdminNumber);
                    Console.WriteLine("First Name: " + admin.FirstName);
                    Console.WriteLine("Last Name: " + admin.LastName);
                    Console.WriteLine("Email: " + admin.Email);
                    Console.WriteLine("Phone Number: " + admin.PhoneNumber);
                    Console.WriteLine("Gender: " + admin.Gender);
                }
                else 
                {
                    Console.WriteLine("Record does not exist");
                }
            }

            public void ChangePassword(Admin admin)
            {
                Console.WriteLine("Enter new Password");
                string password = Console.ReadLine();

                Console.WriteLine("Confirm Password");
                string CPassword = Console.ReadLine();

                if(password != CPassword)
                {
                    Console.WriteLine("Passwords do not match. Try again.");
                    ChangePassword(admin);
                }
                else
                {
                    Console.WriteLine("Password change successful");
                    admin.Password = password;
                }
            }
                // public Customer GetCustomerById(string id )
        // {
        //     return Customer;
        //     }
        // public Attendant GetAttendantById(string id )
        // {
        //     return Attendant;
        // }
    } 
}