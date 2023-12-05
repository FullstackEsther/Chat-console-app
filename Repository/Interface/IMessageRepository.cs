using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Repository.Interface
{
    public interface IMessageRepository
    {
        public void Create(Message obj);
       
    }
}