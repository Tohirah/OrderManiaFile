using System;
using System.Collections.Generic;

namespace OrderMania
{
    public class InventoryService : IInventoryService
    {
        private readonly IInventoryRepository _inventoryRepo;

        public InventoryService()
        {
            _inventoryRepo = new InventoryRepository();
        }



        public MenuItem CreateItem()
        {
            int id = 0;
             var inventories = _inventoryRepo.GetAll();
            if(inventories.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = inventories[inventories.Count - 1].Id +1;
            }

            // Console.WriteLine("Enter item Id");
            // int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter item Code");
            string itemCode = Console.ReadLine();

            Console.WriteLine("Enter item Name");
            string itemName = Console.ReadLine();

            Console.WriteLine("Enter item Quantity");
            int itemQty = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter item Price");
            int itemPrice = int.Parse(Console.ReadLine());

            bool active = true;

            MenuItem newItem  = new MenuItem(id, itemCode, itemName, itemQty, itemPrice, active);
            _inventoryRepo.WriteToFile(newItem);
            return newItem;
        }

        public void DeactivateItem(string itemCode)
        {
            var item = _inventoryRepo.GetByCode(itemCode);
            item.Active = false;
        }

    } 
}