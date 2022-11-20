using System;
using System.Collections.Generic;

namespace OrderMania
{
    public interface ICustomerRepository
    {
        void RefreshFile();

        List<Customer> GetAll();
        List<Customer> GetAllLoyalCustomer();

        Customer GetByCode(string code);

        Customer GetByEmail(string email);

        void WriteToFile(Customer customer);
    }
}