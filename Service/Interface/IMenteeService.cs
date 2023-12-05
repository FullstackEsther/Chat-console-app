using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface IMenteeService
    {
         public void Create(Mentee obj);

       public Mentee Get(string email);
        public List<Mentee> GetAll();
        
        // public void AssignMentee(string mentorRefNum, Mentee obj);
        
        public void Assign(string category);
        public void ToStrings(Mentee obj);
        public List<Mentee> GetMenteesByMentorRef(string RefNum);
        public void Delete(string email);

    
    }
}