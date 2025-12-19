using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjecteKanbanWPF.Windows
{
    /// <summary>
    /// Lógica de interacción para FinestraProjectes.xaml
    /// </summary>
    public partial class FinestraProjectes : Window
    {
        public class Projecte
        {
            public string Titol { get; set; }
            public string Descripcio { get; set; }
        }
        public ObservableCollection<Projecte> Projectes { get; set; }

        public FinestraProjectes()
        {
            InitializeComponent();

            Projectes = new ObservableCollection<Projecte>
            {
                new Projecte { Titol="Projecte 1", Descripcio="Descripcio del projecte 1"}
            };
            DataContext = this;
        }
        private void EntrarProjecte_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            Projecte projecte = btn.DataContext as Projecte;

            if (projecte != null )
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                this.Close();
            }
        }
        private void NouProjecte_Click(object sender, RoutedEventArgs e)
        {
            // es pot millorar
            Projectes.Add(new Projecte { Titol = "Projecte nou", Descripcio = "Descripcio del projecte nou"});
        }
    }
}