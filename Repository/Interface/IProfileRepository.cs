using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface IProfileRepository
    {
        public void Create(Profile obj);
        public Profile Get(string email);
   
        public List<Profile> GetAll();
        public bool Update(Profile obj);
        public void Delete(string email);

    }
}