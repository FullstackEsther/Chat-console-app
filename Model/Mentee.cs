using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Mentee : BaseClass
    {
        public string MentorRefNum{get;set;}
        public string ReferenceNo { get; set; }
        public string UserEmail{get;set;}
        
        public Mentee(int id,string mentorRefNum, string userEmail, string referenceNo, bool isDeleted) : base(id, isDeleted)
        {
            UserEmail = userEmail;
            MentorRefNum = mentorRefNum;
            ReferenceNo = referenceNo;
        }
    }
}