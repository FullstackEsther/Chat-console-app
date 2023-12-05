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
    public class MenteeRepository : IMenteeRepository
    {
        public MenteeRepository()
        {
            AddToList();
        }
        static string path =  @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\mentee.txt";
        public void Create(Mentee obj)
        {
            ListContext.MenteeDb.Add(obj);

            using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString = JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }

        public Mentee Get(string email)
        {
            foreach (var item in ListContext.MenteeDb)
            {
                if(item.UserEmail.ToLower() == email.ToLower() && item.IsDeleted == false)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Mentee> GetAll()
        {
            return ListContext.MenteeDb;
        }

        public static void AddToList()
        {
            if (ListContext.MenteeDb.Count == 0)
            {
                using(StreamReader streamReader = new StreamReader(path))
            {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    Mentee mentee = JsonConvert.DeserializeObject<Mentee>(jsonLine);
                    ListContext.MenteeDb.Add(mentee);
                }
            }
            }
           
        }

        public void Update(string mentorRef, string email)
        {
           var get = GetAll().FirstOrDefault(c => c.UserEmail == email);
           get.MentorRefNum = mentorRef;
           RefreshFile(GetAll());
        }
        private void RefreshFile(List<Mentee> users)
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

        public void Delete(string email)
        {
            var get = Get(email);
            get.IsDeleted = true;

            RefreshFile(GetAll());
        } 
    }
}