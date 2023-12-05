using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Mentor: BaseClass
    {
        public string UserEmail{get; set;}
        public string CategoryName{get; set;}
        public int YearsOfExperience{get; set;}
        public string RefNum {get; set;}
        public List<Mentee> Mentees{get; set;} = new List<Mentee>();
        public MentorStatus MentorStatus {get; set;}


        public Mentor(int id, string userEmail, string categoryname,MentorStatus mentorStatus , int yearsofExperience, string refnum, List<Mentee> mentee, bool isdeleted) : base(id, isdeleted)
        {
        
            UserEmail = userEmail;
            CategoryName = categoryname;
            YearsOfExperience = yearsofExperience;
            RefNum = refnum;
            MentorStatus = mentorStatus;
            Mentees = mentee;

        }
    }
}