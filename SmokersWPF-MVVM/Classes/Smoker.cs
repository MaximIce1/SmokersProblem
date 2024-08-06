using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace SmokersWPF_MVVM.Classes
{
    internal class Smoker
    {
        int res1, res2, res3 = 0;
        int[] initInv = { 0, 0, 0 };
        public bool isSmoking = false;
        SmokerVM smokeVM = new();
        MainVM mainVM;
        const int SMOKING_TIME = 1000;
        FlowDocument flowdoc = new FlowDocument();
        Table resTable = new Table();

        public Smoker(MainVM vm, int i, int[] invInit, MainWindow window)
        {
            Thread thread = new Thread(Grab);
            thread.Name = $"{i} Smoker";
            thread.Start();
            initInv = invInit;
            this.mainVM = vm;
            DrawWindow();
        }
        public void Grab()
        {
            for (; ; )
            {
                Table_.sem.WaitOne();
                if (initInv[0] != mainVM.Res1 && initInv[1] != mainVM.Res2 && initInv[2] != mainVM.Res3)
                {
                    Table_.smokingState = true;
                    smokeVM.SmokingState = true;
                    Thread.Sleep(50);
                    Logger.Log($"{Thread.CurrentThread.Name} is smoking");
                    mainVM.WhosSmoking = $"{Thread.CurrentThread.Name} is smoking";
                    Thread.Sleep(SMOKING_TIME);
                }
                Table_.smokingState = false;
                smokeVM.SmokingState= false;
                Table_.sem.Release();
            }
        }
        void DrawWindow()
        {
            SmokerWindow window = new SmokerWindow();
            window.mainStackPanel.DataContext = mainVM;
            window.SmokingText.DataContext = smokeVM;
            window.Show();
            
        }
    }
}


