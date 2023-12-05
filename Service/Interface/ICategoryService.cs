using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface ICategoryService
    {
        public bool Create(Category obj);

       public Category Get(string name);
        public List<Category> GetAll();
    }
}