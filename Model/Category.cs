using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Model
{
    public class Category: BaseClass
    {
        public string Name{get; set;}
        public Category(int id, string name, bool isDeleted) : base(id, isDeleted)
        {
            Name = name;
        }
    }
}