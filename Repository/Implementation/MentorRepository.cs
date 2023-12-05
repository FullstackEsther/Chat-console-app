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
    public class MentorRepository : IMentorRepository
    {
        public MentorRepository()
        {
            AddToList();
        }
        static string path =  @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\mentor.txt";
        public void Create(Mentor obj)
        {
            ListContext.MentorDb.Add(obj);

            using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString = JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }

        public Mentor Get(string email)
        {
           foreach (var item in ListContext.MentorDb)
           {
                if(item.UserEmail == email && item.IsDeleted == false)
                {return item;}
           }
           return null;
        }

        public List<Mentor> GetAll()
        {
            return ListContext.MentorDb;
        }

        public void Update(string categoryname,MentorStatus mentorStatus , int yearsofExperience, string userEmail, List<Mentee> mentees  )
        {
            var item = Get(userEmail);

            if(item != null)
            {
                item.CategoryName = categoryname;
                item.MentorStatus = mentorStatus;
                item.YearsOfExperience = yearsofExperience;
                item.Mentees = mentees;
            }
            else
            {
                System.Console.WriteLine("Email doesnot exist");
            }
            
            RefreshFile(GetAll());
        }
        private void RefreshFile(List<Mentor> mentors)
        {
            using(StreamWriter str = new StreamWriter(path, false))
            {
                foreach (var item in mentors)
                {
                    var converted = JsonConvert.SerializeObject(item);
                    str.WriteLine(converted);
                }
               
            }
        }

        //  private void RefreshFile(Mentor mentors)
        // {
        //     using(StreamWriter str = new StreamWriter(path))
        //     {
        //             var converted = JsonConvert.SerializeObject(mentors);
        //             str.WriteLine(converted);
        //     }
        // }

        public static void AddToList()
        {
            if(ListContext.MentorDb.Count == 0)
            {
                using(StreamReader streamReader = new StreamReader(path))
            {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    Mentor mentor = JsonConvert.DeserializeObject<Mentor>(jsonLine);
                    ListContext.MentorDb.Add(mentor);
                }
            }
            }
            
        }

        public Mentor GetbyRefNum(string refNum)
        {
            foreach (var item in ListContext.MentorDb)
           {
                if(item.RefNum == refNum && item.IsDeleted == false)
                {return item;}
           }
           return null;
        }


        public void Delete(string email)
        {
            var get = Get(email);
            get.IsDeleted = true;

            RefreshFile(GetAll());
        }
    }
}