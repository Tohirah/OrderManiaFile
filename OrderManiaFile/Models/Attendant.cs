using System;

namespace OrderMania
{
    public class Attendant : Person
    {
        public string AttendantCode {get; set;}
        public bool IsOnShift {get; set;}
        public Attendant(int id, string attendantCode, string firstName, string lastName, Gender gender, string phoneNumber, string email, string password): base(id, firstName, lastName, gender, phoneNumber, email, password)
        {
            AttendantCode = attendantCode;
            IsOnShift = false;
        }

        public override string ToString()
        {
            return $"{Id}\t{AttendantCode}\t{FirstName}\t{LastName}\t{Gender}\t{PhoneNumber}\t{Email}\t{Password}";
        }

        public static Attendant ToAttendant(string str)
        {
            var currentAttendant = str.Split("\t");
            var attendant = new Attendant(int.Parse(currentAttendant[0]), currentAttendant[1], currentAttendant[2], currentAttendant[3], Enum.Parse<Gender>(currentAttendant[4]), currentAttendant[5], currentAttendant[6], currentAttendant[7]);

            return attendant;
            
        }
    }
}