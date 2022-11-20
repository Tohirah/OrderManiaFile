using System;
using System.Collections.Generic;

namespace OrderMania
{
    interface ICustomerService
    {
        Customer CreateCustomer();

        Customer UpdateCustomer(Customer customer);
        Customer ChangePassword(Customer customer);
        bool CheckCustomerLoyalty(string code);

        // void DeleteCustomer(string CustomerCode);

        void ViewProfile (string code);
        List<Customer> PrintAllCustomer();
        void PrintAllLoyalCustomer();
    } 
}