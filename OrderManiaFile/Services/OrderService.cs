using System;

namespace OrderMania
{
    public class OrderService : IOrderService
    {
        private readonly IInventoryRepository _inventoryRepo;
        private readonly IOrderRepository _orderRepo;
        public OrderService()
        {
            _orderRepo = new OrderRepository();
            _inventoryRepo = new InventoryRepository();
        }
        public Order PlaceOrder(Attendant attendant, Customer customer)
        {
                Console.WriteLine("Below is a list of inventory");
                var inventory = _inventoryRepo.GetAll();
                int i = 0;
                foreach (var inv in inventory)
                {
                    i++;
                    Console.WriteLine($"{i} : {inv.ItemName} - {inv.QuantityInStore}");
                }
                Console.WriteLine("Enter item serial number");
                int item = int.Parse(Console.ReadLine());
                var itemcode = inventory[item - 1].ItemCode;
                var unitPrice = inventory[item - 1].UnitPrice;
                var checkAvailable = _inventoryRepo.IsItemAvailable(itemcode);

                if(checkAvailable)
                {

                var OrderId = Order.Id; //Guid.NewGuid().ToString();

                Console.WriteLine("Enter the quantity");
                int qty = int.Parse(Console.ReadLine());

                // Console.WriteLine("How many units of the item?");
                // int unit = int.Parse(Console.ReadLine());

                OrderMenuItem newMenu = new OrderMenuItem(OrderId, itemcode, qty, unitPrice);
                string menu = newMenu.ToString();

                var totalPrice = qty * unitPrice;

                Order currentOrder = new Order(OrderId, 2, attendant.AttendantCode, customer.CustomerCode, menu, totalPrice, DateTime.Today);
                _orderRepo.AddToHistory(currentOrder); //  add to orderhistory
                // _orderRepo.ReadFromFile();
                return currentOrder;
                }
                else
                {
                    Console.WriteLine("The item is not Available for order");
                    return null;
                }

        
        }

        // void DeleteOrder();

        public void SetLoyalCustomer(Customer customer)
        {

            if(customer.CustomerOrderCount >= 10) customer.IsLoyalCustomer = true;
            else customer.IsLoyalCustomer = false;
            // orderRepo.ReadFromFile();
            
        }
        
        public Order RecallOrder(int code)
        {
            var order = _orderRepo.GetByCode(code);
            return order;

        }

        public void GetOrderHistoryByDate(DateTime orderDate)
        {

            var listOfOrder = _orderRepo.GetByDate(orderDate);
            foreach (var item in listOfOrder)
            {
                Console.WriteLine($"Order Number: {item.OrderNumber} - Attendant: {item.AttendantId} - Customer: {item.CustomerId} - Menu Item: {item.MenuItem} - Date: {item.OrderDate}");
            }
            
        }

       public void GetOrderHistoryByAttendant(string attendantId)
        {

            var listOfOrder = _orderRepo.GetByAttedant(attendantId);
            foreach (var item in listOfOrder)
            {
                Console.WriteLine($"Order Number: {item.OrderNumber} - Attendant: {item.AttendantId} - Customer: {item.CustomerId} - Menu Item: {item.MenuItem} - Date: {item.OrderDate}");
            }
        }
        public void GetOrderHistoryByCustomer(string customerCode)
        {

            var listOfOrder = _orderRepo.GetByCustomer(customerCode);
            foreach (var item in listOfOrder)
            {
                Console.WriteLine($"Order Number: {item.OrderNumber} - Attendant: {item.AttendantId} - Customer: {item.CustomerId} - Menu Item: {item.MenuItem} - Date: {item.OrderDate}");
            }
        }

        public void GetAllOrder()
        {
             var listOfOrder = _orderRepo.GetAll();
            foreach (var item in listOfOrder)
            {
                Console.WriteLine($"Order Number: {item.OrderNumber} - Attendant: {item.AttendantId} - Customer: {item.CustomerId} - Menu Item: {item.MenuItem} - Date: {item.OrderDate}");
            }
        }
        
    } 
}