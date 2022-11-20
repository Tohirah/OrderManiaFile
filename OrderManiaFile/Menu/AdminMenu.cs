using System;

namespace OrderMania
{
    public class AdminMenu
    {
        private readonly ICustomerService _customerService;
        private readonly IAttendantService _attendantService;
        private readonly IAdminService _adminService;
        private readonly IOrderService _orderService;
        private readonly IInventoryService _inventoryService;

        public AdminMenu()
        {
            _customerService = new CustomerService();
            _attendantService = new AttendantService();
            _adminService = new AdminService();
            _orderService = new OrderService();
            _inventoryService = new InventoryService();
        }
        public void Menu()
        {
            Console.WriteLine("Kindly Login to continue");
            Console.WriteLine("Enter your Email:");
            string email =  Console.ReadLine();
            Console.WriteLine("Enter your Password:");
            string password = Console.ReadLine();
            var admin = _adminService.Login(email, password);
            if (admin != null) AfterLogInOperation(admin);
            else Menu();
        }
        public void AfterLogInOperation(Admin admin)
        {
            Console.WriteLine("Kindly select one of the following options:");
            Console.WriteLine("1. View Profile");
            Console.WriteLine("2. Update profile");
            Console.WriteLine("3. Register New Admin");
            Console.WriteLine("4. Change Password");
            Console.WriteLine("5. Add New Customers");
            Console.WriteLine("6. View Customers");
            Console.WriteLine("7. View all Attendants on Shift");
            Console.WriteLine("8. Add New Attendants");  
            Console.WriteLine("9. View all Attendants");  
            Console.WriteLine("10. Perform inventory operations");
            Console.WriteLine("11. Recall Order");
            Console.WriteLine("12. View Order History");
            // Console.WriteLine("13 Log Out");
            Console.WriteLine("0. Exit/ Log out");
            // Console.WriteLine("0. View all Attendants");

            int response;
            while(int.TryParse(Console.ReadLine(), out response))
            switch (response)
            {
                case 1:
                ViewProfile(admin);
                break;
                case 2:
                UpdateProfile(admin);
                Continue(admin);
                break;
                case 3:
                CreateNewAdmin(admin);
                break;
                case 4:
                _adminService.ChangePassword(admin);
                Continue(admin);
                break;
                case 5:
                _customerService.CreateCustomer();
                Continue(admin);
                break;
                case 6:
                ViewCustomer(admin);
                Continue(admin);
                break;
                case 7:
                _attendantService.PrintAllAttedantOnShift();
                Continue(admin);
                break;
                case 8:
                RegisterAttendant();
                Continue(admin);
                break;
                case 9:
                _attendantService.PrintAllAttedant();
                Continue(admin);
                break;
                case 10:
                InventoryOperations(admin);
                break;
                case 11:
                RecallOrder(admin);
                break;
                case 12:
                GetAll(admin);
                break;
                // case 13:
                // Menu();
                // break;
                case 0:
                Console.WriteLine("Thank you for using the Order Mania App");
                break;
                default:
                Console.WriteLine("Invalid operation. Try again");
                AfterLogInOperation(admin);
                break;
            }
        }

        
        public void CreateNewAdmin(Admin admin)
        {
            Console.WriteLine("Enter Admin Email");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Admin Last Name");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Admin First Name");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Admin Gender");
            Gender gender = Enum.Parse<Gender>(Console.ReadLine());
            Console.WriteLine("Enter Admin Password");
            string password = Console.ReadLine();
            Console.WriteLine("Confirm Password");
            string cPassword = Console.ReadLine();
            Console.WriteLine("Enter Admin Phone Number");
            string phoneNo = Console.ReadLine();

            var newAdmin = _adminService.CreateAdmin(email, lastName, firstName,  gender,  password, cPassword,  phoneNo);
            if (newAdmin == null)
            {
                Console.WriteLine("Admin Sign up not successful. Try again");
                CreateNewAdmin(admin);
            }
            else Console.WriteLine("Sign up Succesful for Admin Number " + newAdmin.AdminNumber);
            Continue(admin);
        }

        public void PrintCustomer(Admin admin)
        {
            
                var customers = _customerService.PrintAllCustomer();
                if(customers != null)
            {
                for(int i = 0; i < customers.Count; i++)
                {
                    Console.WriteLine($" {i + 1} - {customers[i].ToString()}");
                }
                Continue(admin);
            }
        }

        public void RecallOrder(Admin admin)
        {
            Console.WriteLine("Enter Order Id");
            int id = int.Parse(Console.ReadLine());
            _orderService.RecallOrder(id);
            Continue(admin);
        }
        public void ViewProfile(Admin admin)
        {
            _adminService.ViewProfile(admin.Id);
            AfterLogInOperation(admin);
        }

        public void Continue(Admin admin)
        {
            Console.WriteLine("Do you want to perform another operation?");
            string response = Console.ReadLine().ToLower();
            if(response == "yes")
            AfterLogInOperation(admin);
            else if (response == "no") Console.WriteLine("Thanks for using the Order Mania App");
            else 
            {
                Console.WriteLine("Invalid input. Try again");
                Continue(admin);
            }
        }

        public void InventoryOperations(Admin admin)
        {
             Console.WriteLine("Kindly select one of the following options:");
            Console.WriteLine("1. Add Inventory");
            Console.WriteLine("2. Deactivate Inventory");
            Console.WriteLine("0. Go back to previous menu");

            int option;
            if(int.TryParse(Console.ReadLine(), out option))
            {
                switch (option)
                {
                    case 1:
                    AddInventory(admin);
                    break;
                    case 2:
                    DeactivateItem(admin);
                    break;
                    case 0:
                    AfterLogInOperation(admin);
                    break;
                    default:
                    Console.WriteLine("Invalid Input");
                    break;
                }
            }
        }
        public Admin UpdateProfile(Admin admin)
        {
                _adminService.UpdateProfile(admin);
                Console.WriteLine("Profile update successful");
                return admin;
        }
        public void DeactivateItem(Admin admin)
        {
            Console.WriteLine("Enter item code");
            string itemCode = Console.ReadLine();
            _inventoryService.DeactivateItem(itemCode);
            Continue(admin);
        }
        public void AddInventory(Admin admin)
        {
            
            var item =  _inventoryService.CreateItem();
            if(item != null)
            {
                Console.WriteLine("Inventory item " + item.ItemName + " has been added \t . 1. Add more inventory \t 2. Go back to previous menu");
                string input = Console.ReadLine();

                if(input=="1")
                {
                    AddInventory(admin);
                }
                else if( input == "2")
                {
                    InventoryOperations(admin);
                }
                else 
                {
                    Console.WriteLine("Invlid Input.");
                    Continue(admin);
                }
            }
            else
            {
                Console.WriteLine("Inventory item not added.");
                Console.WriteLine("1. Try again");
                Console.WriteLine("2. Go back to previous menu");
                string input = Console.ReadLine();

                if(input=="1")
                {
                    AddInventory(admin);
                }
                else if( input == "2")
                {
                    AfterLogInOperation(admin);
                }
                else 
                {
                    Console.WriteLine("Invlid Input.");
                    Continue(admin);
                }
            }
        }

        public void GetAll(Admin admin)
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
                AfterLogInOperation(admin);
                break;
                default:
                Console.WriteLine("Invalid input");
                break;

            }
            Continue(admin);
        }

        public void ViewCustomer(Admin admin)
        {
            Console.WriteLine("Do you want to:");
            Console.WriteLine("1. View all Customers");
            Console.WriteLine("2. View all Loyal Customers");

            int response = int.Parse(Console.ReadLine());

            switch(response)
            {
                case 1:
                PrintCustomers(admin);
                break;
                case 2:
                _customerService.PrintAllLoyalCustomer();
                Continue(admin);
                break;
            }   
        }

        public void PrintCustomers(Admin admin)
        {
            
                var customers = _customerService.PrintAllCustomer();
                if(customers != null)
            {
                foreach(var cust in customers)
                {
                   Console.WriteLine("View Profile Details for admin with Id " + cust.Id);
                    Console.WriteLine("Customer Code: " + cust.CustomerCode);
                    Console.WriteLine("First Name: " + cust.FirstName);
                    Console.WriteLine("Last Name: " + cust.LastName);
                    Console.WriteLine("Email: " + cust.Email);
                    Console.WriteLine("Phone Number: " + cust.PhoneNumber);
                    Console.WriteLine("Gender: " + cust.Gender);
                }
                Continue(admin);
            }
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