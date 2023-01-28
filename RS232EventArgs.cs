using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CESATAutomationDevelop
{
    class RS232EventArgs : EventArgs
    {
        public RS232EventArgs(string value)
        {
            this.value = value;
        }
        public string value { get; set; }
    }
}
