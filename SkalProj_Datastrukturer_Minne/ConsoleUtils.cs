using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkalProj_Datastrukturer_Minne
{
    internal static class ConsoleUtils
    {
        /// <summary>
        /// Simple function to stall program until user presses enter
        /// </summary>
        public static void WaitToContinue()
        {
            Console.WriteLine("Press enter to continue");
            Console.ReadLine();
        }
    }
}
