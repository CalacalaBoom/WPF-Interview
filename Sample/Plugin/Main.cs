using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Plugin
{
    public class Main : IPlugin
    {
        public void Execute()
        {
            Console.WriteLine("Plugin is executed");
        }

        public string GetName()
        {
            return "MyPlugin";
        }
    }
}
