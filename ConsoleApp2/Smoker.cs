using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Smoker
    {
        int[] initInv = { 0, 0, 0 };
        public bool isSmoking = false;
        static Semaphore sem = new Semaphore(1, 4);
        Table table;
        public Smoker(Table table, int i, int[] invInit)
        {
            Thread thread = new Thread(Grab);
            thread.Name = $"{i} Smoker";
            thread.Start();
            this.table = table;
            initInv = invInit;
        }
        public void Grab()
        {
            for (; ; )
            {
                table.sem.WaitOne();
                if (initInv[0] != table.onTable[0] && initInv[1] != table.onTable[1] && initInv[3] != table.onTable[3])
                {
                    table.onTable = Array.ConvertAll(table.onTable, i => i * 0);
                    
                }
            }
        }
    }
}
