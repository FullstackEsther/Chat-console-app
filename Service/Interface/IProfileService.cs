using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyProject.Model;

namespace MyProject.Service.Interface
{
    public interface IProfileService
    {
        public void Create(Profile obj);
        public Profile Get(string email);
        public void Delete(string email);
        public void Update(Profile obj);
    }
}