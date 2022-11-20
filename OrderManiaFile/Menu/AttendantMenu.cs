using System;

namespace OrderMania
{
    public class AttendantMenu
    {
        private readonly ICustomerService _customerService;
        private readonly IAttendantService _attendantService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;

        public AttendantMenu()
        {
            _attendantService  = new AttendantService();
            _customerService = new CustomerService();
            _inventoryService = new InventoryService();
            _orderService = new OrderService();
            // Menu();
        }
         public void Menu()
        {
                    Console.WriteLine("Log in to continue");
                    Console.WriteLine("Enter your Email:");
                    string email =  Console.ReadLine();
                    Console.WriteLine("Enter your Password:");
                    string password = Console.ReadLine();
                    var attendant = _attendantService.LogIn(email, password);
                    if(attendant != null)
                    {
                        AfterLogInOperation(attendant);
                    }
                    else 
                    {
                        Console.WriteLine("Login not successful. Try again.");
                        Menu();
                    }
        }

        public void AfterLogInOperation(Attendant attendant)
        {
            Console.WriteLine("Kindly select one of the following options:");
            Console.WriteLine("1. Place Order");
            Console.WriteLine("2. Update profile");
            Console.WriteLine("3. Change Password");
            Console.WriteLine("4. View Profile"); 
            Console.WriteLine("5. Recall Order");
            Console.WriteLine("6. View Order History");
            Console.WriteLine("7. Log Out");
            // Console.WriteLine("0. View all Attendants");

           
            int response;
            while(int.TryParse(Console.ReadLine(), out response))
            switch (response)
            {
                case 1:
                PlaceOrder(attendant);
                break;
                case 2:
                _attendantService.UpdateProfile(attendant);
                Continue(attendant);
                break;
                case 3:
                _attendantService.ChangePassword(attendant);
                Continue(attendant);
                break;
                case 4:
                _attendantService.ViewProfile(attendant.Id);
                Continue(attendant);
                break;
                case 5:
                RecallOrder();
                Continue(attendant);
                break;
                case 6:
                GetAll(attendant);
                break;
                case 7:
                Menu();
                break;
                case 0:
                Console.WriteLine("Thank you for using the Order Mania App");
                break;
                default:
                Console.WriteLine("Invalid Input.");
                break;
            }
        }

        public void PlaceOrder(Attendant attendant)
        {
            var customers = _customerService.PrintAllCustomer();
            if(customers != null)
            {
                for(int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine($" {i + 1} - {customers[i].ToString()}");
                }

                Console.WriteLine("Enter Serial number of Customer");
                int cust  = int.Parse(Console.ReadLine());

                var order = _orderService.PlaceOrder(attendant, customers[cust - 1]);
                if(order != null)
                {
                    Console.WriteLine("Order succssful");
                    PrintReceipt(order, attendant, customers[cust - 1]);
                    Continue(attendant);
                }
                else
                {
                    Console.WriteLine("Order not successful");
                }
            }
        }
        public void PrintReceipt(Order order, Attendant attendant, Customer customer)
        {
            Console.WriteLine("Below is your Order Receipt/Details");
            Console.WriteLine("Order Number: " + order.OrderNumber);
            Console.WriteLine("Customer Name: " + customer.FirstName + " " + customer.LastName);
            Console.WriteLine("Total Price: " + order.Price);
            Console.WriteLine("Attendant Name: " + attendant.FirstName);
        }

            public void Continue(Attendant attendant)
        {
            Console.WriteLine("Do you want to perform another operation?");
            string response = Console.ReadLine().ToLower();
            if(response == "yes")
            AfterLogInOperation(attendant);
            else if (response == "no") Console.WriteLine("Thanks for using the Order Mania App");
            else 
            {
                Console.WriteLine("Invalid input. Try again");
                Continue(attendant);
            }
        }

        public void RecallOrder()
        {
            Console.WriteLine("Enter Order Id");
            int number = int.Parse(Console.ReadLine());
            var order = _orderService.RecallOrder(number);
            if(order != null)
            {
                Console.WriteLine("AttendantId: " + order.AttendantId);
                Console.WriteLine("Customer Id: " + order.CustomerId);
                Console.WriteLine("Order Number" + order.OrderNumber);
                Console.WriteLine("Order Date" + order.OrderDate);
                Console.WriteLine("AttendantId" + order.MenuItem);
                Console.WriteLine("Total Price" + order.Price);

            }
            else
            {
                Console.WriteLine("Order Not Found.");
            }
        }

        public void GetAll(Attendant attendant)
        {
            Console.WriteLine("Kindly select one of the following options:");
            Console.WriteLine("1. View All Orders");
            Console.WriteLine("2. View Orders by date");
            Console.WriteLine("3. View Orders by attendant");
            Console.WriteLine("0. Go back to previous menu");
            
            int response;
            while(int.TryParse(Console.ReadLine(), out response))
            switch (response)
            {
                case 1:
                _orderService.GetAllOrder();
                break;
                case 2:
                Console.WriteLine("Enter order date: YYYY-MM-DD");
                DateTime orderDate = DateTime.Parse(Console.ReadLine());
                _orderService.GetOrderHistoryByDate(orderDate);
                break;
                case 3:
                Console.WriteLine("Enter attedant to check");
                string attendantId = Console.ReadLine();
                _orderService.GetOrderHistoryByAttendant(attendantId);
                break;
                case 0:
                AfterLogInOperation(attendant);
                break;
                default:
                Console.WriteLine("Invalid input");
                break;

            }
            Continue(attendant);
        }

        public void RegisterAttendant()
        {
            var attendant = _attendantService.CreateAttendant();
                if(attendant != null) Console.WriteLine("New Attendant with Atendant Code " + attendant.AttendantCode + " has been created successfuly");
                else{
                    Console.WriteLine("Sign up not successful. Try again");
                    RegisterAttendant();
                }
        }
    }
}