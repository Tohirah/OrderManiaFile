using System;

namespace OrderMania
{
    public class MainMenu
    {
        private readonly CustomerService _customerService;
        private readonly AttendantService _attendantService;
        private readonly AdminService _adminService;
        private readonly OrderService _orderService;
        private readonly InventoryService _inventoryService;
        private readonly AdminMenu _adminMenu;
        private readonly AttendantMenu _attendantMenu;

        public MainMenu()
        {
         _adminMenu = new AdminMenu();
         _attendantMenu = new AttendantMenu();
        }
        public void Welcome()
        {
        Console.WriteLine("***WELCOME TO ORDER MANIA PORTAL***");
        Console.WriteLine("Kindly select one of the following options:");
        Console.WriteLine("1. Admin\n 2. Attendant");
        int input = int.Parse(Console.ReadLine());

        switch (input)
        {
         case 1:
         _adminMenu.Menu();
         break;
         case 2:
         _attendantMenu.Menu();  
         break;      
            default:
            break;
        }
         // if(Input=="1"){
         //    adminMenu.Menu();
         // }
         // else{
         //    attendantMenu.Menu();
         // }
      }
    }
}