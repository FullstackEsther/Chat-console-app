using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Context;
using MyProject.Model;
using MyProject.Repository.Interface;
using MyProject.Service.Interface;
using Newtonsoft.Json;

namespace MyProject.Repository.Implementation
{
    public class ManagerRepository : IManagerRepository
    {
      

        public Manager Get(string userEmail) 
       {
         foreach (var item in ListContext.ManagerDb)
         {
            if(item.UserEmail == userEmail)
            {
                return item;
            }  
         }
         return null;
       }

      
    }
}