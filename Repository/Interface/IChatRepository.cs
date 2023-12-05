using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface IChatRepository
    {
        public void Create(Chat obj);
        public Chat Get(int id);
        public Chat GetbyRefNo(string menteeRef);
        public Chat GetbyRef(string menteeRef, string mentorRef);
        public List<Chat> GetAll();
         public void Delete(int id);
         public void Update(Chat obj);
         

    }
}