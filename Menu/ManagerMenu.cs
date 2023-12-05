using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyProject.Menu;
using MyProject.Model;
using MyProject.Service.Implementation;
using MyProject.Service.Interface;

namespace ChatConsole.Menu
{
    public class ManagerMenu
    {
        ICategoryService categoryService = new CategoryService();
        IUserService userService = new UserService();
        IProfileService profileService = new ProfileService();
        IMenteeService menteeService = new MenteeService();
        IMentorService mentorService = new MentorService();
        IMangerService mangerService = new ManagerService();

        public void Menu()
        {
            while (true)
            {
                System.Console.WriteLine(" Enter 1 to Add Category \n Enter 2 to View mentee \n Enter 3 to View Mentor \n Enter 4 to Delete User \n Enter 5 to View all Mentees \n Enter 6 to view all mentors \n Enter 7 to view all Category \n Enter 8 to go back ");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    System.Console.WriteLine("Enter the name of the Category");
                    string name = Console.ReadLine();

                    Category category = new Category(0, name, false);
                    var check = categoryService.Create(category);
                    if (check)
                    {
                        System.Console.WriteLine("Category Created Successfully");
                        Menu();
                    }

                }
                else if (opt == 2)
                {
                    menteeService.GetAll();
                    System.Console.WriteLine("Enter the email of the mentee");
                    string email = Console.ReadLine();
                    menteeService.ToStrings(menteeService.Get(email));
                    Menu();
                }
                else if (opt == 3)
                {
                    mentorService.GetAllMentors();
                    System.Console.WriteLine("Enter the email of the Mentor");
                    string email = Console.ReadLine();

                    mentorService.ToStrings(mentorService.Get(email));
                    Menu();
                }
                else if (opt == 4)
                {
                    System.Console.WriteLine("Enter 1 to delete Mentee /n Enter 2 to delete Mentor");
                    int input = int.Parse(Console.ReadLine());
                    if (input == 1)
                    {
                        DeleteMentee();
                    }
                    if (input == 2)
                    {
                        DeleteMentor();
                    }
                }
                else if (opt == 5)
                {
                    menteeService.GetAll();
                }
                else if (opt == 6)
                {
                    mentorService.GetAllMentors();
                }
                else if (opt == 7)
                {
                    categoryService.GetAll();
                }


                else if (opt == 8)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("invalid input");
                }


            }

        }

        private void DeleteMentee()
        {
            var get = menteeService.GetAll();
            if (get.Count == 0)
            {
                System.Console.WriteLine("There are no mentees in this list");
            }
            else
            {
                System.Console.WriteLine("Enter the email you want to delete");
                string dec = Console.ReadLine();
                userService.Delete(dec);
                profileService.Delete(dec);
                menteeService.Delete(dec);
            }

        }

        private void DeleteMentor()
        {
            var get = mentorService.GetAllMentors();
            if (get.Count == 0)
            {
                System.Console.WriteLine("There are no mentors in this list");
            }
            else
            {
                System.Console.WriteLine("Enter the email you want to delete");
                string dec = Console.ReadLine();
                userService.Delete(dec);
                profileService.Delete(dec);
                mentorService.Delete(dec);
            }

        }

    }
}