using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Repository.Interface;
using MyProject.Service.Interface;

namespace MyProject.Service.Implementation
{
    public class CategoryService : ICategoryService
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        public bool Create(Category obj)
        {
            var check = categoryRepository.Get(obj.Name);
            if (check != null)
            {
                System.Console.WriteLine("Category already exists");
                return false;
            }
            else
            {
                var id = ListContext.CategoriesDb.Count + 1;
                Category category = new Category(id, obj.Name, obj.IsDeleted);
                categoryRepository.Create(category);
                return true;
            }

        }

        public Category Get(string name)
        {
            var getCategory = categoryRepository.Get(name);
            if (getCategory == null)
            {
                System.Console.WriteLine("The category doesn't exist");
                return null;
            }
            return getCategory;
        }

        public List<Category> GetAll()
        {
            var getall = categoryRepository.GetAll();
            foreach (var item in getall)
            {
                System.Console.WriteLine($"Category Name : {item.Name}");
            }
            return getall;
        }
    }
}