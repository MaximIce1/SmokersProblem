using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SmokersWPF_MVVM
{
    internal class Logger
    {
        private static void WriteConsole(string str)
        {
            Console.WriteLine(str);
        }
        private static void WriteFile(string filename, string str)
        {
            object locker = new();
            lock (locker)
            {
                FileStream ostrm;
                StreamWriter writer;
                TextWriter oldOut = Console.Out;
                ostrm = new FileStream(filename, FileMode.Append, FileAccess.Write);
                writer = new StreamWriter(ostrm);
                Console.SetOut(writer);
                Console.WriteLine(str);
                Console.SetOut(oldOut);
                writer.Close();
                ostrm.Close();
            }

        }
        public static void Log(string str)
        {
            WriteConsole(str);
            WriteFile("outfile.txt", str);
        }
    }
}
