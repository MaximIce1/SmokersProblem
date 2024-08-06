using SmokersWPF_MVVM.Classes;
using System.CodeDom;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmokersWPF_MVVM
{
    public partial class MainWindow : Window
    {
        static Logger logger = new();
        public MainVM vm = new();
        public Semaphore sem = new(2, 4);
        Random random = new Random();
        int[] initInv1 = { 1, 0, 0 };
        int[] initInv2 = { 0, 1, 0 };
        int[] initInv3 = { 0, 0, 1 };
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            File.Create("outfile.txt").Close();
            string[]? args = Environment.GetCommandLineArgs();
            if (args[0] == "-sc" || args[0] == "--smokers_count")
            {
                try
                {
                    for (int i = 0; i <= int.Parse(args[1]); i++)
                    {
                        switch (random.Next(3)) {
                            case 0:
                                _ = new Smoker(vm, i, initInv1, this);
                                break;
                            case 1:
                                _ = new Smoker(vm, i, initInv2, this);
                                break;
                            case 2:
                                _ = new Smoker(vm, i, initInv3, this);
                                break;
                        }       
                    }
                }
                catch (Exception e)
                {
                    Logger.Log($"{e}: Argument Missing");
                    Application.Current.Shutdown();
                }
            }
            else
            {
                for (int i = 1; i <= 3; i++)
                {
                    switch (random.Next(3))
                    {
                        case 0:
                            _ = new Smoker(vm, i, initInv1, this);
                            break;
                        case 1:
                            _ = new Smoker(vm, i, initInv2, this);
                            break;
                        case 2:
                            _ = new Smoker(vm, i, initInv3, this);
                            break;
                    }
                }
            }
            _ = new Agent(vm);
        }
    }
}