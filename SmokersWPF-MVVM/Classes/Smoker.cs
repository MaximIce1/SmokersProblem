using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokersWPF_MVVM.Classes
{
    internal class Smoker
    {
        int[] initInv = { 0, 0, 0 };
        public bool isSmoking = false;
        static Semaphore sem = new Semaphore(1, 4);
        const int SMOKING_TIME = 1000;
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
                if (initInv[0] != table.Res1 && initInv[1] != table.Res2 && initInv[2] != table.Res3)
                {
                    table.SmokingState = true;
                    Thread.Sleep(50);
                    Logger.log($"{Thread.CurrentThread.Name} is smoking");
                    Thread.Sleep(SMOKING_TIME);
                }
                table.SmokingState = false;
                table.sem.Release();
            }
        }
    }
}


