using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eight
{
    public class Dog : Animal,DogInterface
    {
        public override string Name => "Dog";

        public void Run()
        {
            Console.WriteLine("I can Run");
        }

        public override void Speak()
        {
            Console.WriteLine("I'm Dog");
        }
    }
}
