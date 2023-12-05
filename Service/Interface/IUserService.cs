using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface IUserService
    {
      public bool Create(User obj);
       public User Get(string email);  
       public User Login(string email, string password) ;
        public void Update(string email, string password); 
       public void Delete(string email);
    }
}