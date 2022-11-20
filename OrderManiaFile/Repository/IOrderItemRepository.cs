using System;
using System.Collections.Generic;

namespace OrderMania
{
    public interface IOrderItemRepository
    {
        List<OrderMenuItem> GetByOrderId(int orderId);
        public List<OrderMenuItem> GetAll();
        void RefreshFile();

        void ReadFromFile();

        void WriteToFile(OrderMenuItem menuItem);

    }
}