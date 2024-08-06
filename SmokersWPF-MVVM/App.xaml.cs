using System.Configuration;
using System.Data;
using System.Windows;

namespace SmokersWPF_MVVM
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow wnd = new MainWindow();
            if (e.Args.Length == 1 && Int32.Parse(e.Args[0]).GetType() == typeof(int)) wnd.vm.SmokersCount = Int32.Parse(e.Args[0]);
            wnd.Show();
            
        }
    }

}
