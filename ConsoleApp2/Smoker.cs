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
        const int SMOKING_TIME = 1000;
        Table table;
        Logger logger;
        public Smoker(Table table, Logger logger, int i, int[] invInit)
        {
            Thread thread = new Thread(Grab);
            thread.Name = $"{i} Smoker";
            thread.Start();
            this.table = table;
            initInv = invInit;
            this.logger = logger;
        }
        public void Grab()
        {
            for (; ; )
            {
                table.sem.WaitOne();
                if (initInv[0] != table.onTable[0] && initInv[1] != table.onTable[1] && initInv[2] != table.onTable[2])
                {
                    table.isSomeoneSmoking = true;
                    Thread.Sleep(50);
                    table.onTable = Array.ConvertAll(table.onTable, i => i * 0);
                    logger.log($"{Thread.CurrentThread.Name} is smoking");
                    Thread.Sleep(SMOKING_TIME);
                }
                table.isSomeoneSmoking = false;
                table.sem.Release();
            }
        }
    }
}
