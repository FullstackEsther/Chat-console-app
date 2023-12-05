using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Profile : BaseClass
    {
        public int Age {get; set;}
        public string FirstName {get; set;}
        public string LastName {get; set;}
        public string Address{get; set;}
        public string PhoneNumber{get; set;}
        public string UserEmail{get;set;}


        public Profile(int id, int age, string firstname,string userEmail, string lastname, string address, string phonenumber, bool isdeleted) : base(id, isdeleted)
        {
            Age = age;
            FirstName = firstname;
            LastName = lastname;
            Address =address;
            PhoneNumber = phonenumber;
            UserEmail = userEmail;
        }
    }
}