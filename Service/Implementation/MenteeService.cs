using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Menu;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Repository.Interface;
using MyProject.Service.Interface;

namespace MyProject.Service.Implementation
{
    public class MenteeService : IMenteeService
    {
        IMenteeRepository menteeRepository = new MenteeRepository();
        IMentorRepository mentorRepository = new MentorRepository();
        IProfileRepository profileRepository = new ProfileRepository();

        public void Create(Mentee obj)
        {
            var id = ListContext.MenteeDb.Count+1;
            Random rand = new Random();
            var refNum = $"MenteeRef{rand.Next(1000,100000)}";
            Mentee mentee = new Mentee(id, obj.MentorRefNum, obj.UserEmail, refNum, obj.IsDeleted);
            menteeRepository.Create(mentee);
        }

        public Mentee Get(string email)
        {
             var getMentee = menteeRepository.Get(email);
            if(getMentee == null)
            {
                System.Console.WriteLine("The mentee doesn't exist");
                return null;
            }
            return getMentee;
        }

        public List<Mentee> GetAll()
        {
           var getAll = menteeRepository.GetAll().Where(c => c.IsDeleted == false).ToList();

           foreach (var item in getAll)
           {
                System.Console.WriteLine($"{item.UserEmail}\t{item.Id}\t{item.ReferenceNo}");
           }
            return getAll;
        }

        // public void AssignMentee(string mentorRefNum, Mentee obj)
        // {
        //    var get = mentorRepository.GetbyRefNum(mentorRefNum);
        //    var f = new List<Mentee>();
        //    if(get == null)
        //    {
        //         System.Console.WriteLine("Mentor does not exist");
        //    }
        //    else
        //    {
        //         get.Mentees.Add(obj);
        //          mentorRepository.Update(get.CategoryName, get.MentorStatus,get.YearsOfExperience, get.UserEmail, get.Mentees );
        //    }
           
           
       // }

        public void Assign(string category)
        {
            var getMentee = menteeRepository.Get(MainMenu.loggedInEmail);
            if (getMentee.MentorRefNum == null)
            {
                 var mentors = mentorRepository.GetAll().Where(c => c.CategoryName.ToLower() == category.ToLower() && c.Mentees.Count <= 2 && c.RefNum != getMentee.MentorRefNum).ToArray();
            if (mentors.Length == 0)
            {
                System.Console.WriteLine("There are no mentors in this category");
            }
            else
            {
                Random rand = new Random();
                int index = rand.Next(0, mentors.Length);
                var mentor = mentors[index];
                
                var getMentor = mentorRepository.GetbyRefNum(mentor.RefNum);
                if (getMentee != null)
                {
                    menteeRepository.Update(mentor.RefNum, getMentee.UserEmail);
                    getMentor.Mentees.Add(getMentee);
                    mentorRepository.Update(getMentor.CategoryName, getMentor.MentorStatus, getMentor.YearsOfExperience, getMentor.UserEmail, getMentor.Mentees);
                    System.Console.WriteLine($"Mentor Assigned and email is {mentor.UserEmail}");
                }
            }
            }
            else
            {
                System.Console.WriteLine("You've been assigned to a mentor already");
            }
           
            
        }
        public void ToStrings(Mentee obj)
        {
            var getprofile = profileRepository.Get(obj.UserEmail);
            System.Console.WriteLine($"mentee Email : {obj.UserEmail} \n Mentee FisrtName : {getprofile.FirstName} \n Mentee LastName {getprofile.LastName}\n Mentee PhoneNumber {getprofile.PhoneNumber}");
        }

        public List<Mentee> GetMenteesByMentorRef(string RefNum)
        {
            var getAll = menteeRepository.GetAll().Where(c => c.MentorRefNum == RefNum).ToList();
            if (getAll.Count() == 0)
            {
                System.Console.WriteLine("No Mentee Assigned");
            }
            else
            {
                foreach (var item in getAll)
                {
                        System.Console.WriteLine($"Mentee Email : {item.UserEmail}\t Mentee ReferenceNo : {item.ReferenceNo}");
                }
            }
            return getAll;
        }

        public void Delete(string email)
        {
            menteeRepository.Delete(email);
        }
    }
}