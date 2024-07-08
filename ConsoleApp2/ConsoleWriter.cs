using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Writer
    {
        public void Logger (string text)
        {
            Console.WriteLine (text);
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            ostrm = new FileStream("outfile.txt", FileMode.Append, FileAccess.Write);
            writer = new StreamWriter(ostrm);
            Console.SetOut(writer);
            Console.WriteLine(text);
            Console.SetOut(oldOut);
            writer.Close();
            ostrm.Close();
        }
    }
}
