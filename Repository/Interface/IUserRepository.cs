using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface IUserRepository
    {
        public void Create(User obj);
        public User Get(string email);
        public List<User> GetAll();
        public User GetbyEmailAndPin(string email, string password);
        public void Update(string email, string password);
         public bool Check (string email);
         public void Delete(string email);

    }
}