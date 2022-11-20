using System;

namespace OrderMania
{
    public class Admin : Person
    {
        public string AdminNumber{get; set;}

        public Admin(string adminNumber, int id, string firstName, string lastName, Gender gender, string phoneNumber, string email, string password) : base(id, firstName, lastName, gender, phoneNumber,email, password)
        {
            AdminNumber = adminNumber;
        }

        public override string ToString()
        {
            return $"{AdminNumber}\t{Id}\t{FirstName}\t{LastName}\t{Gender}\t{PhoneNumber}\t{Email}\t{Password}";
        }

        public static Admin ToAdmin(string str)
        {
            var currentAdmin = str.Split("\t");
            var admin = new Admin(currentAdmin[0], int.Parse(currentAdmin[1]), currentAdmin[2], currentAdmin[3], Enum.Parse<Gender>(currentAdmin[4]), currentAdmin[5], currentAdmin[6], currentAdmin[7]);

            return admin;
            
        }
    }
}