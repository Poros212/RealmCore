using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealmCore.UI.ConsoleApp
{
    internal class ConsoleIO
    {

        #region Outputs
        public static void DisplayText(string text) 
        {
            Console.WriteLine(text);
        }

        public static void DisplayTextInline(string text)
        {
            Console.Write(text);
        }
        #endregion

        #region Inputs

        #endregion
    }
}
