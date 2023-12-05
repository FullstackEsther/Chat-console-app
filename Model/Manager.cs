using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Manager : BaseClass
    {
        public string UserEmail { get; set; }

        public Manager(int id, string userEmail, bool isdeleted) : base(id, isdeleted)
        {
            UserEmail = userEmail;
        }
    }
}