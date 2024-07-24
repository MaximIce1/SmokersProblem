using SmokersWPF_MVVM.Classes;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace SmokersWPF_MVVM
{
    public partial class MainWindow : Window
    {
        static Logger Logger = new();
        MainVM vm = new();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
            int[] initInv1 = { 1, 0, 0 };
            int[] initInv2 = { 0, 1, 0 };
            int[] initInv3 = { 0, 0, 1 };
            File.Create("outfile.txt").Close();
            _ = new Agent(vm);
            _ = new Smoker(vm, 1, initInv1);
            _ = new Smoker(vm, 2, initInv2);
            _ = new Smoker(vm, 3, initInv3);
        }

    }
}