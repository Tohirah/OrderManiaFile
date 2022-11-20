using System;
using System.Collections.Generic;

namespace OrderMania
{
    interface IOrderService
    {
        Order PlaceOrder(Attendant attendant, Customer customer);
        // void DeleteOrder();

        void SetLoyalCustomer(Customer customer);
        
        Order RecallOrder(int code);

        void GetOrderHistoryByDate(DateTime orderDate);

        void GetOrderHistoryByAttendant(string AttendantId);

        void GetAllOrder();

        
    } 
}