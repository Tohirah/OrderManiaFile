using System;

namespace OrderMania
{
    public class Customer : Person
    {
        public string CustomerCode {get; set;}
        public int CustomerOrderCount{get; set;}
        public bool IsLoyalCustomer{get; set;}

        public Customer(int id, string customerCode, string firstName, string lastName, Gender gender, string phoneNumber, string email, string password, int orderCount, bool isLoyalCustomer): base(id, firstName, lastName, gender, phoneNumber,email, password)
        {
            CustomerCode = customerCode;
            IsLoyalCustomer = isLoyalCustomer;
            CustomerOrderCount = orderCount;
        }

        public override string ToString()
        {
            return $"{Id}\t{CustomerCode}\t{FirstName}\t{LastName}\t{Gender}\t{PhoneNumber}\t{Email}\t{Password}\t{CustomerOrderCount}\t{IsLoyalCustomer}";
        }

        public static Customer ToCustomer(string str)
        {
            var currentCustomer = str.Split("\t");

            var customer = new Customer(int.Parse(currentCustomer[0]), currentCustomer[1], currentCustomer[2], currentCustomer[3],  Enum.Parse<Gender>(currentCustomer[4]), currentCustomer[5], currentCustomer[6], currentCustomer[7], int.Parse(currentCustomer[8]), bool.Parse(currentCustomer[9]));

            return customer;
        }
        
    }
}