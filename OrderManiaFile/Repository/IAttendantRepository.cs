using System;
using System.Collections.Generic;

namespace OrderMania
{
    public interface IAttendantRepository
    {
        List<Attendant> GetAll();
        Attendant GetByCode(string str);
        void WriteToFile(Attendant attendant);
        void RefreshFile(List<Attendant> attendant);
        public Attendant GetById(int id);
        public Attendant GetByEmail(string email);
        List<Attendant> GetAllAttedantOnShift();
    }
}