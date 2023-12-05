using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public abstract class BaseClass
    {
        public int Id;
        public bool IsDeleted;


        public BaseClass(int id , bool isdeleted)
        {
            Id = id;
            IsDeleted = isdeleted;
        }
    }
}