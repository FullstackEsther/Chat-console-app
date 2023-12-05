using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Repository.Interface;
using MyProject.Service.Interface;

namespace MyProject.Service.Implementation
{
    public class UserService : IUserService
    {
        IUserRepository userRepository = new UserRepository();
        public bool Create(User obj)
        {
            var check = userRepository.Check(obj.Email);
            if (check)
            {
                System.Console.WriteLine($"{obj.Email} already exists");
                return false;
            }
            
               var id = ListContext.UserDb.Count+1;
                User user = new User(id,obj.Email,obj.Password,obj.Role,obj.IsDeleted);
                userRepository.Create(user);
                return true;
    
        }

        public User Get(string email)
        {
            var get = userRepository.Get(email);
            if(get == null)
            {
                System.Console.WriteLine($"{email} does not exist");
                return null;
            }
            return get;
        }

        public User Login(string email, string password)
        {
            var check = userRepository.GetbyEmailAndPin(email, password);
            if(check == null)
            {
                System.Console.WriteLine($"{email} or {password} does not exist");
                return null;
            }
            return check;
        }
         public void Delete(string email)
        {
            userRepository.Delete(email);
        }

        public void Update(string email, string password)
        {
           userRepository.Update(email, password);
        }
    }
}