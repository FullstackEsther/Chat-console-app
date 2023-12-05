using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject;
using MyProject.Context;
using MyProject.Menu;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Service.Implementation;
using MyProject.Service.Interface;

namespace ChatConsole.Menu
{
    public class MentorMenu
    {
        IUserService userService = new UserService();
        IProfileService profileService = new ProfileService();
        IMentorService mentorService = new MentorService();
        IMenteeService menteeService = new MenteeService();
        ICategoryService categoryService = new CategoryService();

        IChatService chatService = new ChatService();
        public void CreateMentor()
        {
            System.Console.Write("Enter your Firstname :");
            string firstName = Console.ReadLine();

            System.Console.Write("Enter your Lastname :");
            string lastName = Console.ReadLine();

            System.Console.Write("Enter your Address :");
            string address = Console.ReadLine();

            System.Console.Write("Enter your PhoneNumber :");
            string phoneNumber = Console.ReadLine();

            System.Console.Write("Enter your Age :");
            int age = int.TryParse(Console.ReadLine(), out int result) ? result : 0;

            Console.Write("enter your number years of experience: ");
            int years = int.TryParse(Console.ReadLine(), out int results) ? results : 0;
            string categoryname = "";
            while (true)
            {
                categoryService.GetAll();

                Console.Write("enter the name of category: ");
                categoryname = Console.ReadLine();

                var check = categoryService.Get(categoryname);
                if (check != null)
                {
                    break;
                }
            }

            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            User user = new User
            (
               0,
               email,
               pass,
               "Mentor",
               false
            );
            var createUser = userService.Create(user);
            if (!createUser)
            {
                System.Console.WriteLine("Fail to create");
            }
            else
            {
                Profile profile = new Profile
                (
                  0,
                  age,
                  firstName,
                  email,
                  lastName,
                  address,
                  phoneNumber,
                  false
                );
                profileService.Create(profile);

                Mentor mentor = new Mentor
                (
                    0,
                    email,
                    categoryname,
                    MentorStatus.Avalaible,
                    years,
                    "",
                    new List<Mentee>(),
                    false
                );
                mentorService.Create(mentor);
                // System.Console.WriteLine("Mentor created Successfully");
            }


        }

        public void UseCaseMentor()
        {
           try
           {
                 while (true)
            {
                System.Console.WriteLine("Enter 1 to view profile \nEnter 2 to update profile \nEnter 3 to view Mentees \nEnter 4 chat with Mentee  \nEnter 5 to go back");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    var get = mentorService.Get(MainMenu.loggedInEmail);
                    mentorService.ToStrings(get);


                }
                else if (opt == 2)
                {
                    Update();

                }
                else if (opt == 3)
                {
                    var get = mentorService.Get(MainMenu.loggedInEmail);
                    menteeService.GetMenteesByMentorRef(get.RefNum);
                }
                else if (opt == 4)
                {
                    Messaging();
                }
                
                else if (opt == 5)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("invalid input");
                }
            }
            
           }
           catch (Exception ex)
           {
                System.Console.WriteLine(ex.Message);
                UseCaseMentor();
           }
        }
        private void Update()
        {
            var array = new string[] { "FirstName", "LastName", "Address", "PhoneNumber", "Age", "YearsOfExperience", "Password" };
            int id = 1;
            foreach (var item in array)
            {
                System.Console.WriteLine($"{id}\t {item}");
                id++;
            }
            System.Console.WriteLine("Enter the number of the items you want to update");
            int response = int.TryParse(Console.ReadLine(), out int result)? result :0;
            Looping(response);


        }

        private void Looping(int response)
        {
           try
           {
                 var mentObj = mentorService.Get(MainMenu.loggedInEmail);
            var profileObj = profileService.Get(MainMenu.loggedInEmail);
            var userObj = userService.Get(MainMenu.loggedInEmail);
            for (int i = 0; i < response; i++)
            {
                System.Console.WriteLine("Enter the id of the item you want to update");
                int ans = int.Parse(Console.ReadLine());

                switch (ans)
                {
                    case 1:
                        System.Console.WriteLine("Enter the value");
                        profileObj.FirstName = Console.ReadLine();
                        break;
                    case 2:
                        System.Console.WriteLine("Enter the value");
                        profileObj.LastName = Console.ReadLine();
                        break;

                    case 3:
                        System.Console.WriteLine("Enter the value");
                        profileObj.Address = Console.ReadLine();
                        break;

                    case 4:
                        System.Console.WriteLine("Enter the value");
                        profileObj.PhoneNumber = Console.ReadLine();
                        break;

                    case 5:
                        System.Console.WriteLine("Enter the value");
                        profileObj.Age = int.Parse(Console.ReadLine());
                        break;

                    case 6:
                        System.Console.WriteLine("Enter the value");
                        mentObj.YearsOfExperience = int.Parse(Console.ReadLine());
                        break;

                    case 7:
                        System.Console.WriteLine("Enter the value");
                        userObj.Password = Console.ReadLine();
                        break;

                    default:
                        System.Console.WriteLine("Invalid Input");
                        break;
                }
            }
            profileService.Update(profileObj);
            mentorService.Update(mentObj.CategoryName, mentObj.MentorStatus, mentObj.YearsOfExperience, mentObj.UserEmail, mentObj.Mentees);
            userService.Update(MainMenu.loggedInEmail, userObj.Password);
           }
           catch (Exception ex)
           {
                System.Console.WriteLine(ex.Message);
           }
        }

        public void Messaging()
        {
            var mentor = mentorService.Get(MainMenu.loggedInEmail);
            if (mentor.Mentees.Count == 0)
            {
                System.Console.WriteLine("Cannot chat, No mentee assigned!");
            }
            else
            {
                System.Console.WriteLine("Select Mentee RefNum");
                var mentee = menteeService.GetMenteesByMentorRef(mentor.RefNum);
                var menteeRe = Console.ReadLine();
                var getChat = chatService.GetbyRef(menteeRe, mentor.RefNum);
                if (getChat == null)
                {
                    System.Console.Write("Enter the message you want to send :");
                    var messageContent = Console.ReadLine();
                    Chat chat = new Chat(0, mentor.RefNum, menteeRe, new List<Message>(), false);
                    Message message = new Message(0, messageContent, chat.Id, mentor.RefNum, DateTime.Now, false);
                    chat.Messages.Add(message);
                    chatService.Create(chat);
                }
                else
                {
                    foreach (var item in getChat.Messages)
                    {
                        System.Console.WriteLine($"{item.SenderEmail} : {item.MessageChat}\t {item.DateCreated.TimeOfDay}");
                    }

                    while (true)
                    {
                        System.Console.Write("Enter the message you want to send or 0 to exist:");
                        var messageContent = Console.ReadLine();
                         if (messageContent == 0.ToString())
                        {
                            break;
                        }
                        Message message = new Message(0, messageContent, getChat.Id, mentor.RefNum, DateTime.Now, false);
                        getChat.Messages.Add(message);

                        chatService.Update(getChat);
                    }
                    
                }
            }
        }

    }
}
