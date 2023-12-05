using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class User : BaseClass
    {
        public string Email {get; set;}
        public string Password{get; set;}
        public string Role{get; set;}


        public User(int id , string email , string password, string role, bool isdeleted) : base(id, isdeleted )
        {
            Email = email;
            Password = password;
            Role = role;
            
        }
    }
}