using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Context
{
    public class ListContext
    {
        public static List<Category> CategoriesDb = new List<Category>();
        public static List<Chat> ChatDb = new List<Chat>();
        public static List<Manager> ManagerDb = new List<Manager>()
        {
            new Manager(1, "EstherOtufale@gmail.com", false)
        };
        public static List<Mentor> MentorDb = new List<Mentor>();
        public static List<Mentee> MenteeDb = new List<Mentee>();
        public static List<Profile> ProfileDb = new List<Profile>()
        {
            new Profile(1, 12, "Esther","EstherOtufale@gmail.com", "Otufale", "Abeokuta", "0813464324", false)
        };
        public static List<User> UserDb = new List<User>()
        {
            new User(1, "EstherOtufale@gmail.com", "1234", "Manager", false)
            
        };
        public static List<Message> MessageDb = new List<Message>();


        
    }
}