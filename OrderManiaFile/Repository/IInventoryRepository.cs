using System;
using System.Collections.Generic;

namespace OrderMania
{
    public interface IInventoryRepository
    {
        void RefreshFile();

        void ReadFromFile();

        void WriteToFile(MenuItem item);

        List<MenuItem> GetAll();

        MenuItem GetByCode(string code);

        int CheckQuantity(string code);

        bool IsItemAvailable(string code);
    }
}