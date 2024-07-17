using SmokersWPF_MVVM.Classes;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace SmokersWPF_MVVM
{
    public partial class MainWindow : Window
    {
        static Logger Logger = new();
        static Table TableVM = new();
        public MainWindow()
        {
            InitializeComponent();
            int[] initInv1 = { 1, 0, 0 };
            int[] initInv2 = { 0, 1, 0 };
            int[] initInv3 = { 0, 0, 1 };
            File.Create("outfile.txt").Close();
            Agent agent = new Agent(TableVM);
            Smoker smoker1 = new Smoker(TableVM, 1, initInv1);
            Smoker smoker2 = new Smoker(TableVM, 2, initInv2);
            Smoker smoker3 = new Smoker(TableVM, 3, initInv3);
            
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}