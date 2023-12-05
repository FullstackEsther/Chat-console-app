using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;
using MyProject.Repository.Implementation;
using MyProject.Repository.Interface;
using MyProject.Service.Interface;

namespace MyProject.Service.Implementation
{
    public class ManagerService : IMangerService
    {
        IManagerRepository managerRepository = new ManagerRepository();
        

        public Manager Get(string name)
        {
            throw new NotImplementedException();
        }
    }
}