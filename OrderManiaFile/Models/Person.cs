using System;

namespace OrderMania
{
    public abstract class Person
    {
        public int Id {get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public Gender Gender {get; set;}
        public string PhoneNumber {get; set;}
        public string Email {get; set;}
        public string Password {get; set;}
        public Person (int id, string firstName, string lastName, Gender gender, string phoneNumber, string email, string password)
        {
            FirstName = firstName;
            LastName = lastName;
            Id = id;
            Gender = gender;
            PhoneNumber = phoneNumber;
            Email = email;
            Password = password;
        }
    }
}