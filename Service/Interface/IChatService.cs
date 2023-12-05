using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface IChatService
    {
        public void Create(Chat obj);
        public Chat Get(int id);
        public List<Chat> GetAll();
        public void Delete(int id);
         public Chat GetbyRefNo(string menteeRef);
         public void Update(Chat obj);
         public Chat GetbyRef(string menteeRef, string mentorRef);

    }
}