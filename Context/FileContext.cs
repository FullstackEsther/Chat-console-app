using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Context
{
    public class FileContext
    {
        string Basefile = @"C:\Users\Admin\OneDrive\Desktop\ChatConsole\baseFile";
        
        public void Create()
        {
          
                if (!Directory.Exists(Basefile))
            {
                Directory.CreateDirectory(Basefile);
                
            }

            var categoryFile = Path.Combine(Basefile, "category.txt");
            if(!File.Exists(categoryFile))
            {
                File.Create(categoryFile).Close();
            }
            
            var messageFile = Path.Combine(Basefile, "message.txt");
            if(!File.Exists(messageFile))
            {
                File.Create(messageFile).Close();
            }
            
            var chatfile = Path.Combine(Basefile, "chat.txt");
            if(!File.Exists(chatfile))
            {
                File.Create(chatfile).Close();
            }
            
            var managerfile = Path.Combine(Basefile, "manager.txt");
            if(!File.Exists(managerfile))
            {
                File.Create(managerfile).Close();
            }
            
            var mentorfile = Path.Combine(Basefile, "mentor.txt");
            if(!File.Exists(mentorfile))
            {
                File.Create(mentorfile).Close();
                
            }
            


            var menteefile = Path.Combine(Basefile, "mentee.txt");
            if(!File.Exists(menteefile))
            {
                File.Create(menteefile).Close();
            }


            var profilefile = Path.Combine(Basefile, "profile.txt");
            if(!File.Exists(profilefile))
            {
                File.Create(profilefile).Close();
            }


            var userfile = Path.Combine(Basefile, "user.txt");
            if(!File.Exists(userfile))
            {
                File.Create(userfile).Close();
            }
            
            var messagefile = Path.Combine(Basefile, "message.txt");
            if(!File.Exists(messagefile))
            {
                File.Create(messagefile).Close();
            }
            
        }
    }
}