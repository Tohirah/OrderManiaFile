using System;
using System.Collections.Generic;

namespace OrderMania
{
    public interface IOrderRepository
    {
        List<Order> ReadOrderHistory();
        void AddToHistory(Order neworder);
        // void ReadFromFile();
        public List<Order> GetAll();
        Order GetByCode(int code);
        public List<Order> GetByDate(DateTime date);
        public List<Order> GetByAttedant(string attendantCode);
        public List<Order> GetByCustomer(string customerCode);
        void RefreshFile();

    }
}