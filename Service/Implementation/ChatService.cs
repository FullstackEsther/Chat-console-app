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
    public class ChatService : IChatService
    {
        IChatRepository chatRepository = new ChatRepository();
        public void Create(Chat obj)
        {
            var id = ListContext.ChatDb.Count +1;
            Chat chat = new Chat(id, obj.MentorRef, obj.MenteeRef, obj.Messages, obj.IsDeleted);
            chatRepository.Create(chat);
        }

        public void Delete(int id)
        {
            chatRepository.Delete(id);
        }

        public Chat Get(int id)
        {
            var getChat = chatRepository.Get(id);
            if(getChat == null)
            {
                System.Console.WriteLine("Chat does not exist");
                return null;
            }
            return getChat;
        }

        public List<Chat> GetAll()
        {
           var getAll = chatRepository.GetAll();
           if (getAll == null)
           {
                System.Console.WriteLine("No chat exists");
                return null;
           }
           return getAll;
        }

        public Chat GetbyRef(string menteeRef, string mentorRef)
        {
            var getChat = chatRepository.GetbyRef(menteeRef, mentorRef);
            if(getChat == null)
            {
                return null;
            }
            return getChat;
        }

        public Chat GetbyRefNo(string menteeRef)
        {
               var getChat = chatRepository.GetbyRefNo(menteeRef);
            if(getChat == null)
            {
                return null;
            }
            return getChat;
        }

        public void Update(Chat obj)
        {
           var update = chatRepository.GetbyRefNo(obj.MenteeRef);
           if (update != null)
           {
                chatRepository.Update(update);
           }
        }
    }
}