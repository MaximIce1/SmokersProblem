using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace smokersWPF
{
    internal class Logger
    {
        object locker = new();
        public void WriteConsole(string str)
        {
            Console.WriteLine(str);
        }
        public void WriteFile(string filename, string str)
        {
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
        public void log(string str)
        {
            WriteConsole(str);
            WriteFile("outfile.txt", str);
        }
    }
}
