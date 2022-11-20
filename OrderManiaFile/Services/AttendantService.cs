using System;

namespace OrderMania
{
    public class AttendantService : IAttendantService
    {
        private readonly IAttendantRepository _attendantRepo;
        public AttendantService()
        {
            _attendantRepo = new AttendantRepository();
        }
        public Attendant CreateAttendant()
        {
            int id = 0;
             var attendants = _attendantRepo.GetAll();
            if(attendants.Count == 0)
            {
                id = 1;
            }
            else
            {
                id = attendants[attendants.Count - 1].Id +1;
            }

            
            Console.WriteLine("Enter First Name");
            string firstName = Console.ReadLine();

            Console.WriteLine("Enter Last Name");
            string lastName = Console.ReadLine();

            Console.WriteLine("Enter Gender");
            var gender = Enum.Parse<Gender>(Console.ReadLine());

            Console.WriteLine("Enter Phone Number");
            string phoneNumber = Console.ReadLine();

            Console.WriteLine("Enter Email");
            string eMail = Console.ReadLine();

            Console.WriteLine("Enter Password");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password");
            string Cpassword = Console.ReadLine();

            string code = Guid.NewGuid().ToString();
            string attendantCode = $"{firstName}/" + code;

            var checkAttendant = _attendantRepo.GetByEmail(eMail);
            
            if(checkAttendant != null)
            {
                Console.WriteLine("Customer already exists in the system");
                return null;
            }

            if(password != Cpassword) 
            {
                Console.WriteLine("Passwords do not match");
                return null;
            }   
            else
            {
                 Attendant attendant= new Attendant(id, attendantCode, firstName, lastName, gender, phoneNumber, eMail, password);
                 _attendantRepo.WriteToFile(attendant);
                 return attendant;
            }
        }

        public void ViewProfile(int id)
            {
                var attendant = _attendantRepo.GetById(id);
                if(attendant != null)
                { 
                    Console.WriteLine("ViewProfile Details for" + id);
                    Console.WriteLine("Attendant Number: " + attendant.AttendantCode);
                    Console.WriteLine("First Name: " + attendant.FirstName);
                    Console.WriteLine("Last Name: " + attendant.LastName);
                    Console.WriteLine("Email: " + attendant.Email);
                    Console.WriteLine("Phone Number: " + attendant.PhoneNumber);
                    Console.WriteLine("Gender: " + attendant.Gender);
                }
                else 
                {
                    Console.WriteLine("Record does not exist");
                }
            }
        public void DeleteAttendant(string code)
        {
            var attendant  = _attendantRepo.GetByCode(code);
            if(attendant == null) Console.WriteLine("Attendant does not exist");
            else
            {
                var allAttendant = _attendantRepo.GetAll();
                allAttendant.Remove(attendant);
                _attendantRepo.RefreshFile(allAttendant);
                Console.WriteLine("Attendant with code " + code + "has been removed.");
            }
        }

        public Attendant LogIn(string email, string password)
        {
            if(email == "" || password == "")
            {
                Console.WriteLine("Invalid Credentials");
            }

            var attendant = _attendantRepo.GetByEmail(email);  //attendants.Find(s => s.Email == email);
            if(attendant != null && attendant.Password == password)
            {
                Console.WriteLine("Login Successful");
                return attendant;
            }

            Console.WriteLine("Email/Password is invalid");
            return null;
        }

        public Attendant LogOut()
        {
            throw new NotImplementedException();
        }

        public bool ShiftOn()
        {
            throw new NotImplementedException();
        }
        public void PrintAllAttedantOnShift()
        {
            var customers = _attendantRepo.GetAllAttedantOnShift();
            foreach(var item in customers)
            {
                Console.WriteLine("Attendant Id: " + item.AttendantCode + "\t" + "Full Name: " + item.FirstName + "  " + item.LastName + "\t" + "Gender: " + item.Gender + "\t" + "Email: " + item.Email + "\t" + "Phone Number: " + item.PhoneNumber + "\t" + "Shift Status: " +  item.IsOnShift);
            }
        }

        public void PrintAllAttedant()
        {
            var attendants = _attendantRepo.GetAll();
            foreach(var item in attendants)
            {
                Console.WriteLine("Attendant Id: " + item.AttendantCode + "\t" + "Full Name: " + item.FirstName + "  " + item.LastName + "\t" + "Gender: " + item.Gender + "\t" + "Email: " + item.Email + "\t" + "Phone Number: " + item.PhoneNumber + "\t" + "Shift Status: " +  item.IsOnShift);
            }
        }

        public Attendant UpdateProfile(Attendant attendant)
        {
            Console.WriteLine("Enter the updated ifnformation here");
            
                Console.WriteLine("Enter new First Name");
                string firstName = Console.ReadLine();
                attendant.FirstName = firstName;
                
                Console.WriteLine("Enter new Last Name");
                string lastName = Console.ReadLine();
                attendant.LastName = lastName;
                Console.WriteLine("Enter new Email");
                string email = Console.ReadLine();
                attendant.Email = email;
                Console.WriteLine("Enter new Phone Number");
                string phone = Console.ReadLine();
                attendant.PhoneNumber = phone;
                // Console.WriteLine("Invalid input");
                var updateAdmin = _attendantRepo.GetAll();
                _attendantRepo.RefreshFile(updateAdmin);
                return attendant;
        }

        public void ChangePassword(Attendant attendant)
        {
            Console.WriteLine("Enter new Password");
            string password = Console.ReadLine();

            Console.WriteLine("Confirm Password");
            string CPassword = Console.ReadLine();

            if(password != CPassword)
            {
                Console.WriteLine("Passwords do not match. Try again.");
                ChangePassword(attendant);
            }
            else
            {
                Console.WriteLine("Password change successful");
                attendant.Password = password;
            }
        }
    }
}