using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface IMentorRepository
    {
        public void Create(Mentor obj);
        public Mentor Get(string email);
        public List<Mentor> GetAll();
        
        public void Update( string categoryname,MentorStatus mentorStatus,  int yearsofExperience, string userEmail, List<Mentee> mentees);
        
        public Mentor GetbyRefNum(string refNum);
         public void Delete(string email);
    }
}