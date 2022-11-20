using System;
using System.Collections.Generic;

namespace OrderMania
{
    public class CustomerService : ICustomerService
    {              
        private readonly ICustomerRepository customerRepo;
        public CustomerService()
        {
            customerRepo = new CustomerRepository();
        }
        public Customer CreateCustomer()
        {
            int id = 0;
             var customers = customerRepo.GetAll();
            if(customers.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = customers[customers.Count - 1].Id +1;
            }

            
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Gender");
            var gender = Enum.Parse<Gender>(Console.ReadLine());

            Console.WriteLine("Enter Phone Number");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string eMail = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password");
            string Cpassword = Console.ReadLine();

            string code = Guid.NewGuid().ToString();
            string customerCode = $"{firstName}/{code}";

            
            int orderCount;
            bool loyal;
            var checkCustomer = customerRepo.GetByEmail(eMail);
            
            if(checkCustomer == null)
            {
                orderCount = 0;
                loyal = false;
            }
            else
            {
                Console.WriteLine("Customer already exists in the system");
                return null;
            }

            if(password != Cpassword) 
            {
                Console.WriteLine("Passwords do not match");
                return null;
            }   
            else
            {
                 Customer customer= new Customer(id, customerCode, firstName, lastName, gender, phoneNumber, eMail, password, orderCount, loyal);
                 customerRepo.WriteToFile(customer);
                 Console.WriteLine("Customer Created succesfully");
                 return customer;
            }


        }
        public Customer UpdateCustomer(Customer customer)
        {
            Console.WriteLine("What information do you wan to update?");
            string update = Console.ReadLine().Trim().ToLower();

            switch(update)

            {
                case "firstname":
                Console.WriteLine("Enter new First Name");
                string firstName = Console.ReadLine();
                customer.FirstName = firstName;
                break;
                case "lastname":
                Console.WriteLine("Enter new Last Name");
                string lastName = Console.ReadLine();
                customer.LastName = lastName;
                break;
                case "email":
                Console.WriteLine("Enter new Email");
                string email = Console.ReadLine();
                customer.Email = email;
                break;
                case "phonenumber":
                Console.WriteLine("Enter new Phone Number");
                string phone = Console.ReadLine();
                customer.PhoneNumber = phone;
                break;
                default:
                Console.WriteLine("Invalid input");
                break;
            }
            customerRepo.RefreshFile();
            return customer;
        }

        public void ViewProfile(string code)
        {
            var customer = customerRepo.GetByCode(code);
            if(customer != null)
            {
                Console.WriteLine("First Name: " + customer.FirstName);
                Console.WriteLine("Last Name: " + customer.LastName);
                Console.WriteLine("Email: " + customer.Email);
                Console.WriteLine("Phone Nummber: " + customer.PhoneNumber);
                Console.WriteLine("Gender: " + customer.Gender);
            }
            else
            {
                Console.WriteLine("Customer does not exist");
            }
        }

        // public void DeleteCustomer(string customerCode)
        // {
        //     var delCustomer = customerRepo.GetByCode(customerCode);

        //     if(delCustomer == null)
        //     {
        //         Console.WriteLine("Customer does not exist");
        //     }
        //     else
        //     {
        //         var allCust = customerRepo.GetAll();
        //         // var delCust = allCust.Find(i => i.CustomerCode == customerCode);
        //         allCust.Remove(delCustomer);
        //         customerRepo.RefreshFile(allCust);
        //     }
        // }

        public bool CheckLoyalCustomer(string code)
        {
            var loyalCust = customerRepo.GetByCode(code);
            bool isLoyal = loyalCust.IsLoyalCustomer;
            if(isLoyal == true) return true;
            else return false;
        }

        public  List<Customer> PrintAllCustomer()
        {
            var customers = customerRepo.GetAll();
            // foreach(var item in customers)
            // {
            //     Console.WriteLine("Customer Id: " + item.CustomerCode + "\t" + "Full Name: " + item.FirstName + "  " + item.LastName + "\t" + "Gender: " + item.Gender + "\t" + "Email: " + item.Email + "\t" + "Phone Number: " + item.PhoneNumber + "\t" + "Loyal Customer: " +  item.IsLoyalCustomer);
            // }
            return customers;
        }

        public void PrintAllLoyalCustomer()
        {
            var customers = customerRepo.GetAllLoyalCustomer();
            foreach(var item in customers)
            {
                Console.WriteLine("Customer Id: " + item.CustomerCode + "\t" + "Full Name: " + item.FirstName + "  " + item.LastName + "\t" + "Gender: " + item.Gender + "\t" + "Email: " + item.Email + "\t" + "Phone Number: " + item.PhoneNumber + "\t" + "Loyal Customer: " +  item.IsLoyalCustomer);
            }
        }

        public Customer ChangePassword(Customer customer)
        {
            throw new NotImplementedException();
        }

        public bool CheckCustomerLoyalty(string code)
        {
            throw new NotImplementedException();
        }
    } 
}