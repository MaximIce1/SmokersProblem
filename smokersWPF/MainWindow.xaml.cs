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

namespace smokersWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Table Table_ = new Table();
        static Logger Logger = new Logger();
        public MainWindow()
        {
            InitializeComponent();
            int[] initInv1 = { 1, 0, 0 };
            int[] initInv2 = { 0, 1, 0 };
            int[] initInv3 = { 0, 0, 1 };
            File.Create("outfile.txt").Close();
            Agent agent = new Agent(Table_, Logger);
            Smoker smoker1 = new Smoker(Table_, Logger, 1, initInv1);
            Smoker smoker2 = new Smoker(Table_, Logger, 2, initInv2);
            Smoker smoker3 = new Smoker(Table_, Logger, 3, initInv3);

        }
    }
}