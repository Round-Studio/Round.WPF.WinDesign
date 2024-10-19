using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Win_Design.Cs.API.Log
{
    class Logs
    {
        static string Logs_Str = "";
        public static string Get_Logs()
        {
            return Logs_Str;
        }
        public static void WriteLine(dynamic message)
        {
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")}][Debug]:{message}");
            Logs_Str += $"[{DateTime.Now.ToString("HH:mm:ss")}][Debug]:{message}\n";
        }
    }
}
