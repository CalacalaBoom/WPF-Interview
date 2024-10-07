using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace One
{
    public static class ShareValue
    {
        public static readonly object _lockObj = new object();
        public static int _shareValue = 100;
        public static void UpdateValue()
        {
            lock (_lockObj)
            {
                _shareValue--;
            }
        }
    }
}
