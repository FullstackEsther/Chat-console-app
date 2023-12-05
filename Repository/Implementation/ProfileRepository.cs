using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Interface;
using Newtonsoft.Json;

namespace MyProject.Repository.Implementation
{
    public class ProfileRepository : IProfileRepository
    {
        public ProfileRepository()
        {
            AddToList();
        }
        static string path =  @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\profile.txt";


        public void Create(Profile obj)
        {
            ListContext.ProfileDb.Add(obj);

            using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString = JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }

        public Profile Get(string email)
        {
            foreach (var item in ListContext.ProfileDb)
            {
                if(item.UserEmail == email && item.IsDeleted == false)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Profile> GetAll()
        {
            return ListContext.ProfileDb;
        }

        public bool Update(Profile obj)
        {
            var check = ListContext.ProfileDb.FirstOrDefault( c => c.UserEmail == obj.UserEmail);
            if (check == null)
            {
                    return false;
            }
            check.PhoneNumber = obj.PhoneNumber;
            check.FirstName = obj.FirstName;
            check.LastName = obj.LastName;
            check.Age = obj.Age;
            
            RefreshFile(ListContext.ProfileDb);
            return true;
        }

        private void RefreshFile(List<Profile> profiles)
        {
            using(StreamWriter str = new StreamWriter(path))
            {
                foreach (var item in profiles)
                {
                    var converted = JsonConvert.SerializeObject(item);
                    str.WriteLine(converted);
                }
                
            }
        }
        public static void AddToList()
        {
            if (ListContext.ProfileDb.Count == 1)
            {
                 using(StreamReader streamReader = new StreamReader(path))
            {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    Profile profile = JsonConvert.DeserializeObject<Profile>(jsonLine);
                    ListContext.ProfileDb.Add(profile);
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