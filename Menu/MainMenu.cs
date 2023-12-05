using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatConsole.Menu;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Service.Implementation;
using MyProject.Service.Interface;

namespace MyProject.Menu
{
    public class MainMenu
    {
        IUserService userService = new UserService();
        MenteeMenu menteeMenu = new MenteeMenu();
        MentorMenu mentorMenu = new MentorMenu();
        ManagerMenu managerMenu = new ManagerMenu();
        public static string loggedInEmail = "";
        public void UserMenu()
        {
            Console.WriteLine("Enter 1 to register as a Mentor \nEnter 2 to register as a Mentee \nEnter 3 to login");
            int opt = int.Parse(Console.ReadLine());



            if (opt == 1)
            {
                mentorMenu.CreateMentor();
                Options();
            }
            else if (opt == 2)
            {
                menteeMenu.CreateMentee();
                Options();

            }
            else if (opt == 3)
            {
                LoginMenu();

            }
            else
            {
                Console.WriteLine("invalid input");
                UserMenu();
            }
        }

        public void LoginMenu()
        {
            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();



            var response = userService.Login(email, pass);
            if (response != null)
            {
                loggedInEmail = email;
                System.Console.WriteLine("Login successful");
                if (response.Role == "Mentee")
                {
                    menteeMenu.UseCaseMentee();
                    Options();
                }
                else if (response.Role == "Mentor")
                {
                    mentorMenu.UseCaseMentor();
                    Options();
                }
                else if (response.Role == "Manager")
                {
                    managerMenu.Menu();
                    Options();
                }

            }
            else
            {
                System.Console.WriteLine("Login Failed press 1 to Try again or press any number to go to Menu");
                var input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    LoginMenu();
                }
                else
                {
                    UserMenu();
                }


            }

        }
        public void Options()
        {
            System.Console.WriteLine("Enter 1 to login \nEnter 2 to go to Main menu");
            int option = int.Parse(Console.ReadLine());
            if (option == 1)
            {
                LoginMenu();
            }
            else
            {
                UserMenu();
            }
        }
    }
}

