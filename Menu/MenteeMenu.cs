using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Menu;
using MyProject.Model;
using MyProject.Service.Implementation;
using MyProject.Service.Interface;

namespace ChatConsole.Menu
{
    public class MenteeMenu
    {
        IUserService userService = new UserService();
        IProfileService profileService = new ProfileService();
        IMenteeService menteeService = new MenteeService();
        ICategoryService categoryService = new CategoryService();
        IMentorService mentorService = new MentorService();
        IChatService chatService = new ChatService();
        public void CreateMentee()
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

            Console.Write("enter your email: ");
            string email = Console.ReadLine();

            Console.Write("enter your password: ");
            string pass = Console.ReadLine();

            User user = new User
            (
                0,
                email,
                pass,
                "Mentee",
                false
            );
            var createUser = userService.Create(user);
            if (!createUser)
            {
                System.Console.WriteLine("Fail to create Try again!!");
                CreateMentee();
            }
            else
            {
                Profile profile = new Profile(0, age, firstName, email, lastName, address, phoneNumber, false);
                profileService.Create(profile);
                Mentee mentee = new Mentee(0, null, email, null, false);

                menteeService.Create(mentee);
                System.Console.WriteLine("Mentee Created Successfully");

            }
        }

        public void UseCaseMentee()
        {
            try
            {
                while (true)
                {
                    System.Console.WriteLine("Enter 1 to chat with mentor\nEnter 2 to update profile\nEnter 3 to view your Profile \nEnter 4 to view mentor\nEnter 5 to Assign Mentor\nEnter 6 to go back ");
                    int opt = int.Parse(Console.ReadLine());
                    if (opt == 1)
                    {
                        Messaging();
                    }
                    else if (opt == 2)
                    {
                        Update();
                    }
                    else if (opt == 3)
                    {
                        var get = menteeService.Get(MainMenu.loggedInEmail);
                        menteeService.ToStrings(get);
                    }
                    else if (opt == 4)
                    {
                        var getMentee = menteeService.Get(MainMenu.loggedInEmail);
                        var getMentor = mentorService.GetbyRefNum(getMentee.MentorRefNum);
                        if (getMentor == null)
                        {
                            System.Console.WriteLine("No Mentor Assigned");
                        }
                        else
                        {
                            mentorService.ToStrings(getMentor);
                        }

                    }

                    else if (opt == 5)
                    {
                        System.Console.WriteLine("Please select Category Name");
                        var ch = categoryService.GetAll();
                        var categoryName = Console.ReadLine();
                        var getCategory = categoryService.Get(categoryName);
                        if (getCategory != null)
                        {
                            menteeService.Assign(categoryName);
                        }
                        UseCaseMentee();
                    }
                    else if (opt == 6)
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
                UseCaseMentee();

            }
        }

        private void Update()
        {
            var array = new string[] { "FirstName", "LastName", "Address", "PhoneNumber", "Age", "Password" };
            int id = 1;
            foreach (var item in array)
            {
                System.Console.WriteLine($"{id}\t{item}");
                id++;
            }
            System.Console.WriteLine("Enter the number of the item you want to update");
            int response = int.TryParse(Console.ReadLine(), out int result) ? result :0;
            Looping(response);


        }

        private void Looping(int response)
        {
           try
           {
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
                        profileObj.Age = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                        break;

                    case 6:
                        System.Console.WriteLine("Enter the value");
                        userObj.Password = Console.ReadLine();
                        break;

                    default:
                        System.Console.WriteLine("Invalid Input");
                        break;
                }
            }
            profileService.Update(profileObj);
            userService.Update(MainMenu.loggedInEmail, userObj.Password);
           }
           catch (Exception ex)
           {
            
            System.Console.WriteLine(ex.Message);
            Update();
           }
        }

        public void Messaging()
        {
            try
            {
                var mentee = menteeService.Get(MainMenu.loggedInEmail);
                if (mentee.MentorRefNum == null)
                {
                    System.Console.WriteLine("Cannot chat, No mentor assigned!");
                }
                else
                {

                    var getChat = chatService.GetbyRefNo(mentee.ReferenceNo);
                    if (getChat == null)
                    {
                        System.Console.Write("Enter the message you want to send :");
                        var messageContent = Console.ReadLine();
                        Chat chat = new Chat(0, mentee.MentorRefNum, mentee.ReferenceNo, new List<Message>(), false);
                        Message message = new Message(0, messageContent, chat.Id, mentee.ReferenceNo, DateTime.Now, false);
                        chat.Messages.Add(message);
                        chatService.Create(chat);
                    }
                    else
                    {
                        foreach (var item in getChat.Messages)
                        {
                            System.Console.WriteLine($"{item.SenderEmail} : {item.MessageChat}\t{item.DateCreated.TimeOfDay.ToString().Substring(0,8)}");
                        }
                        while (true)
                        {
                            System.Console.Write("Enter the message you want to send or 0 to exist:");
                            var messageContent = Console.ReadLine();
                            if (messageContent == 0.ToString())
                            {
                                break;
                            }
                            Message message = new Message(0, messageContent, getChat.Id, mentee.ReferenceNo, DateTime.Now, false);
                            getChat.Messages.Add(message);

                            chatService.Update(getChat);
                        }

                    }



                }
            }
            catch (Exception ex)
            {
                System.Console.WriteLine(ex.Message);
                UseCaseMentee();
            }
        }

    }
}