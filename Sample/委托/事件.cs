using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 委托
{
    public delegate void Notify();
    public class 事件
    {
        public event Notify ProcessCompleted;

        public void StartProcess()
        {
            ProcessCompleted?.Invoke();
        }
    }
}
