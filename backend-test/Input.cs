using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backend_test
{
    internal class Input
    {
        public static string GetStringInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            return input;
        }

        public static int GetNumberInput(string message)
        {
            Console.Write(message);
            try
            {
                string input = Console.ReadLine();
                int number = Convert.ToInt32(input);
                return number;
            }
            catch
            {
                return -1;
            }
        }
    }
}
