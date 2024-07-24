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
        MainVM vm;
        const int SMOKING_TIME = 1000;
        public Smoker(MainVM vm, int i, int[] invInit)
        {
            Thread thread = new Thread(Grab);
            thread.Name = $"{i} Smoker";
            thread.Start();
            initInv = invInit;
            this.vm = vm;
            
        }
        public void Grab()
        {
            for (; ; )
            {
                Table_.sem.WaitOne();
                if (initInv[0] != Table_.res1 && initInv[1] != Table_.res2 && initInv[2] != Table_.res3)
                {
                    Table_.smokingState = true;
                    Thread.Sleep(50);
                    Logger.Log($"{Thread.CurrentThread.Name} is smoking");
                    vm.WhosSmoking = $"{Thread.CurrentThread.Name} is smoking";
                    Thread.Sleep(SMOKING_TIME);
                }
                Table_.smokingState = false;
                Table_.sem.Release();
            }
        }
    }
}


