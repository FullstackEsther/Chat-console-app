using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Interface;
using Newtonsoft.Json;

namespace MyProject.Repository.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        public CategoryRepository(){
            AddToList();
        }
        static string path =  @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\category.txt";
        public void Create(Category obj)
        {
           ListContext.CategoriesDb.Add(obj);
           using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString = JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }

        public Category Get(string name)
        {
            foreach (var item in ListContext.CategoriesDb)
            {
                if (item.Name.ToUpper() == name.ToUpper() && item.IsDeleted == false)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Category> GetAll()
        {
            return ListContext.CategoriesDb;
        }

        public static void AddToList()
        {
            if ( ListContext.CategoriesDb.Count == 0)
            {
                using(StreamReader streamReader = new StreamReader(path))
                {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    Category category = JsonConvert.DeserializeObject<Category>(jsonLine);
                    ListContext.CategoriesDb.Add(category);
                }
                } 
            }
           
        }
    }
}