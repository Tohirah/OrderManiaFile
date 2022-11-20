using System;

namespace OrderMania
{
    public interface IAttendantService
    {
        Attendant CreateAttendant();
        void ViewProfile(int id);
        Attendant LogIn(string email, string password);
        void DeleteAttendant(string code);
        bool ShiftOn();
        Attendant UpdateProfile(Attendant attendant);
        void ChangePassword(Attendant attendant);
        void PrintAllAttedantOnShift();
        void PrintAllAttedant();
    } 
}