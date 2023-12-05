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
    public class ChatRepository : IChatRepository
    {
        static string path =  @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\chat.txt";
        public ChatRepository()
        {
            AddToList();
        }
        public void Create(Chat obj)
        {
           ListContext.ChatDb.Add(obj);

            using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString = JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }

        public void Delete(int id)
        {
            var get = Get(id);
            get.IsDeleted = true;
            RefreshFile(GetAll());

        }

        public Chat Get(int id)
        {
           foreach (var item in ListContext.ChatDb)
           {
                if(item.Id == id)
                {
                    return item;
                }
           }
           return null;
        }

        

        public List<Chat> GetAll()
        {
            return ListContext.ChatDb;
        }

        public Chat GetbyRef(string menteeRef, string mentorRef)
        {
           var get = ListContext.ChatDb.FirstOrDefault(x => x.MenteeRef == menteeRef && x.MentorRef == mentorRef);
            return get;
        }

        public Chat GetbyRefNo(string menteeRef)
        {
            var get = ListContext.ChatDb.FirstOrDefault(x => x.MenteeRef == menteeRef);
            return get;
        }

        public void Update(Chat obj)
        {
            var get = GetAll().FirstOrDefault(c => c.Id == obj.Id);
           get.Messages = obj.Messages;
           get.IsDeleted = obj.IsDeleted;
           RefreshFile(GetAll());
        }

        private void RefreshFile(List<Chat> chat)
        {
            using(StreamWriter str = new StreamWriter(path))
            {
                foreach (var item in chat)
                {
                    var converted = JsonConvert.SerializeObject(item);
                    str.WriteLine(converted);
                }
                
            }
        }
        public static void AddToList()
        {
            if(ListContext.ChatDb.Count == 0)
            {
                using(StreamReader streamReader = new StreamReader(path))
            {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    Chat chat = JsonConvert.DeserializeObject<Chat>(jsonLine);
                    ListContext.ChatDb.Add(chat);
                }
            }
            }
            
        }
    }
}