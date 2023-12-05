using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface IMentorService
    {
      public void Create(Mentor obj);

       public Mentor GetbyRefNum(string RefNum);
       public Mentor Get(string email);
       
        // public List<Mentor> GetAll();
        public List<Mentor> GetAllMentors();
        public void ToStrings(Mentor obj);
        
        public void Update( string categoryname,MentorStatus mentorStatus , int yearsofExperience, string userEmail, List<Mentee> Mentees); 

        public void Delete(string email);
    }
}