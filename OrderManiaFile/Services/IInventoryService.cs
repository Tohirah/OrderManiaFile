using System;

namespace OrderMania
{
    interface IInventoryService
    {
        MenuItem CreateItem();
        public void DeactivateItem(string itemCode);
       
    } 
}