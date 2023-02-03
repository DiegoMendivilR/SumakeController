using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CESATAutomationDevelop
{
    public class CobotSimulated
    {
        bool moving = false;
        public async Task MoveArm()
        {
            moving = true;
            Console.WriteLine("Cobot moving");
            await Task.Delay(2000).ContinueWith((task) => {
                moving = false;
                Console.WriteLine("Cobot stoped");
            });
        }
    }
}
