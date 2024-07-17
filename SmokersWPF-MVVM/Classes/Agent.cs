using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmokersWPF_MVVM.Classes
{
    internal class Agent
    {
        Random random = new Random();
        Table table;
        public Agent(Table table)
        {
            Thread thread = new Thread(Supply);
            thread.Name = "Agent";
            thread.Start();
            this.table = table;
        }
        void Supply()
        {
            byte rndm;
            table.sem.WaitOne();
            for (; ; )
            {
                if (table.SmokingState == false)
                {
                    rndm = (byte)random.Next(3);
                    switch (rndm)
                    {

                        case 0: table.Res1 = 1; table.Res2 = 1; table.Res3 = 0; break;
                        case 1: table.Res1 = 1; table.Res2 = 0; table.Res3 = 1; break;
                        case 2: table.Res1 = 0; table.Res2 = 1; table.Res3 = 1; break;

                    }
                    table.RaisePropertyChanged(nameof(table.Res1));
                    table.RaisePropertyChanged(nameof(table.Res2));
                    table.RaisePropertyChanged(nameof(table.Res3));
                    Logger.log($"Agent provided resources: {table.Res1} {table.Res2} {table.Res3}");
                }
            }
        }   
    }
}
