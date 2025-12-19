using ProjecteKanbanWPF.Windows;
using System.Configuration;
using System.Data;
using System.Windows;

namespace ProjecteKanbanWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            FinestraLogin f = new();
            bool? resultat = f.ShowDialog();

            if (resultat == true) 
            {
                MainWindow.Show();
            }
        }
    }
}
