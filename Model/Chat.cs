using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Chat: BaseClass
    {
       public string MentorRef { get; set; }
       public string MenteeRef { get; set; }
       public List<Message> Messages{get; set;}
    
       public Chat(int id,string mentorRef, string menteeRef, List<Message> messages, bool isdeleted) : base(id, isdeleted)
        {
            MentorRef = mentorRef;
            MenteeRef = menteeRef;
            Messages = messages;
        }
    }
}