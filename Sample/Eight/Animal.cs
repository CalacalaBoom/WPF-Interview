using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight
{
    public abstract class Animal
    {
        public abstract string Name { get; }

        public abstract void Speak();

        public void Eat()
        {
            Console.WriteLine("Eateing...");
        }
    }
}
