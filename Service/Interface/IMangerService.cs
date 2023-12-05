using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface IMangerService
    { 
        public Manager Get(string name);
    }
}