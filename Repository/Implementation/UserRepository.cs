using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Interface;
using Newtonsoft.Json;

namespace MyProject.Repository.Implementation
{
    public class UserRepository : IUserRepository

    {
        public UserRepository()
        {
            AddToList();
        }
        static string path = @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\user.txt";
        
        public void Create(User obj)
        {
            ListContext.UserDb.Add(obj);

            using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString =JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }
        public bool Check(string email)
        {
           return ListContext.UserDb.Any(x => x.Email == email);
        }


        public User Get(string email)
        {
            foreach (var item in ListContext.UserDb)
            {
                if(email == item.Email && item.IsDeleted == false)
                {
                    return item;
                }
            }
            return null;
        }

        public List<User> GetAll()
        {
           return ListContext.UserDb;
        }

        public User GetbyEmailAndPin(string email, string password)
        {
           return ListContext.UserDb.FirstOrDefault(x => x.Email.ToUpper() == email.ToUpper() && x.Password.ToUpper() == password.ToUpper() && x.IsDeleted == false);
           
        }

        public void Update(string email, string password)
        {
            //var get = GetAll().Where(x=> x.Email == email);
            foreach (var item in GetAll())
            {
                if(item.Email == email)
                {
                    item.Password = password;
                }
            }
            RefreshFile(GetAll());
        }


        private void RefreshFile(List<User> users)
        {
            using(StreamWriter str = new StreamWriter(path))
            {
                foreach (var item in users)
                {
                    var converted = JsonConvert.SerializeObject(item);
                    str.WriteLine(converted);
                }
            }
        }

        public static void AddToList()
        {
            if (ListContext.UserDb.Count==1)
            {
                using(StreamReader streamReader = new StreamReader(path))
                {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    User user = JsonConvert.DeserializeObject<User>(jsonLine);
                    ListContext.UserDb.Add(user);
                }
                }
            }
          
        } 

         public void Delete(string email)
        {
            var get = Get(email);
            get.IsDeleted = true;

            RefreshFile(GetAll());
        } 
    }
}