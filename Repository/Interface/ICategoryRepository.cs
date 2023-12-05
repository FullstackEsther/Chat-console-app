using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface ICategoryRepository
    {
        public void Create(Category obj);
        public Category Get(string email);
        public List<Category> GetAll();
    }
}