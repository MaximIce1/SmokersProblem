using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Table
    { 
        public int[] onTable = { 0, 0, 0 };
        public Semaphore sem = new Semaphore(2, 4);
        public bool isSomeoneSmoking = false;
    }
}
