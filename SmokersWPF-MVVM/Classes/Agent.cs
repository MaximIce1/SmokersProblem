using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmokersWPF_MVVM.Classes
{
    internal class Agent
    {
        Random random = new Random();
        MainVM vm;
        public Agent(MainVM vm)
        {
            Thread thread = new Thread(Supply);
            thread.Name = "Agent";
            thread.Start();
            this.vm = vm;
        }
        void Supply()
        {
            byte rndm;
            Table_.sem.WaitOne();
            for (; ; )
            {
                if (Table_.smokingState == false)
                {
                    rndm = (byte)random.Next(3);
                    switch (rndm)
                    {

                        case 0: vm.Res1 = 1; vm.Res2 = 1; vm.Res3 = 0; break;
                        case 1: vm.Res1 = 1; vm.Res2 = 0; vm.Res3 = 1; break;
                        case 2: vm.Res1 = 0; vm.Res2 = 1; vm.Res3 = 1; break;

                    }
                    Table_.smokingState = true;
                    vm.OnPropertyChanged("Res1");
                    vm.OnPropertyChanged("Res2");
                    vm.OnPropertyChanged("Res3");
                    Logger.Log($"Agent provided resources: {Table_.res1} {Table_.res2} {Table_.res3}");
                    vm.AgentLog = ($"Agent provided resources: {Table_.res1} {Table_.res2} {Table_.res3}");
                    Table_.smokingState = true;
                }
            }
        }   
    }
}
