using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface IMenteeRepository
    {
        public void Create(Mentee obj);
        public Mentee Get(string email);
        public List<Mentee> GetAll();
        public void Update(string mentorRef, string email);
        public void Delete(string email);

    }
}