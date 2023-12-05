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
    public class MentorService : IMentorService
    {
        IMentorRepository mentorRepo = new MentorRepository();
        
        IProfileRepository profileRepository = new ProfileRepository();
        public void Create( Mentor obj)
        {
           var exists = mentorRepo.Get(obj.UserEmail);
           if(exists == null)
           {
                var id = ListContext.MentorDb.Count+1;
                Random rand = new Random();
                 
                var refNum = $"MentorRef{rand.Next(1000, 10000)}";

                Mentor mentor = new Mentor(id, obj.UserEmail, obj.CategoryName, obj.MentorStatus, obj.YearsOfExperience, refNum, new List<Mentee>(), obj.IsDeleted);
                mentorRepo.Create(mentor);

           }
           else
           {
             System.Console.WriteLine("Email already exixts ...");
           }

        }

        public Mentor Get(string email)
        {
            var getMentor = mentorRepo.Get(email);
            if(getMentor == null)
            {
                System.Console.WriteLine("The mentor doesn't exist");
                return null;
            }
            return getMentor;
        }

        // public List<Mentor> GetAll()
        // {
        //     var getAllMentors = mentorRepo.GetAll();
        //     List<Mentor> newList = new List<Mentor>();
        //     if (getAllMentors.Count == 0)
        //     {
        //         System.Console.WriteLine("The list is Empty");
        //         return null;
        //     }

        //     foreach (var item in getAllMentors)
        //     {
        //         if(item.IsDeleted == true || item.Mentees?.Count >= 2)
        //         {
        //            continue;
        //         }
        //         else
        //         {
        //              ToStrings(item);
        //              newList.Add(item);
        //         }
               

        //     }
        //     return newList;
        // }

        public void Update(string categoryname, MentorStatus mentorStatus, int yearsofExperience , string userEmail,List<Mentee> mentees)
        {
           mentorRepo.Update(categoryname, mentorStatus, yearsofExperience, userEmail, mentees);
        }
        
        
        public Mentor GetbyRefNum(string refNum)
        {
            var getMentor = mentorRepo.GetbyRefNum(refNum);
            if(getMentor == null)
            {
                System.Console.WriteLine("The mentor doesn't exist");
                return null;
            }
            return getMentor;
        }

        public List<Mentor> GetAllMentors()
        {
            var getAllMentors = mentorRepo.GetAll().Where(x => x.IsDeleted == false).ToList();

            foreach (var item in getAllMentors)
            {
                System.Console.WriteLine($"{item.Id}\t{item.UserEmail}\t{item.RefNum}");
            }
            return getAllMentors;
        }

        public void ToStrings(Mentor obj)
        {
            var getprofile = profileRepository.Get(obj.UserEmail);
            System.Console.WriteLine($"Email : {obj.UserEmail}\nFirstName : {getprofile.FirstName}\nLastName : {getprofile.LastName}\nPhoneNumber : {getprofile.PhoneNumber}");
        }

        public void Delete(string email)
        {
            mentorRepo.Delete(email);
        }

       
    }
}