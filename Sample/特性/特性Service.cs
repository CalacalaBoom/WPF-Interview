using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 特性
{
    [MyCustomAttribute("This is a sample class.")]
    public class 特性Service
    {
        [Obsolete("Use NewMethod instead.")]
        public void OldMethod() { }

        public void NewMethod() { }

        [MyCustomAttribute("This is a sample method.")]
        public void SampleMethod() { }
    }
}
