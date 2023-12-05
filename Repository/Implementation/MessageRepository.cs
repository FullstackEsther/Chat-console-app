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
    public class MessageRepository : IMessageRepository
    {
       static string path =  @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile\message.txt";

        public void Create(Message obj)
        {
            ListContext.MessageDb.Add(obj);

            using(StreamWriter streamWriter = new StreamWriter(path, true))
            {
                var toString = JsonConvert.SerializeObject(obj);
                streamWriter.WriteLine(toString);
            }
        }


         public static void AddToList()
        {
            if(ListContext.MessageDb.Count == 0)
            {
                using(StreamReader streamReader = new StreamReader(path))
                {
                var read = File.ReadAllLines(path);
                foreach (var jsonLine in read)
                {
                    Message message = JsonConvert.DeserializeObject<Message>(jsonLine);
                    ListContext.MessageDb.Add(message);
                }
                }
            }
           
        }
    }
}