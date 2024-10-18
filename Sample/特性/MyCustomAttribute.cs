using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class )]
    public class MyCustomAttribute : Attribute
    {
        public string Description { get; }


        public MyCustomAttribute(string description)
        {
            Description = description;
        }
    }
}
