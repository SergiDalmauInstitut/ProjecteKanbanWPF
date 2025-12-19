using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace ProjecteKanbanWPF.Windows
{
    /// <summary>
    /// Lógica de interacción para FinestraProjectes.xaml
    /// </summary>
    public partial class FinestraProjectes : Window
    {
        public class Projecte
        {
            public string? Titol { get; set; }
            public string? Descripcio { get; set; }
        }
        public ObservableCollection<Projecte> Projectes { get; set; }

        public FinestraProjectes()
        {
            InitializeComponent();

            Projectes =
            [
                new() { Titol="Projecte 1", Descripcio="Descripcio del projecte 1"}
            ];
            DataContext = this;
        }
        private void EntrarProjecte_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            Projecte projecte = (Projecte)btn.DataContext;

            if (projecte != null)
            {
                MainWindow mw = new();
                mw.Show();
                this.Close();
            }
        }
        private void NouProjecte_Click(object sender, RoutedEventArgs e)
        {
            // es pot millorar
            Projectes.Add(new Projecte { Titol = "Projecte nou", Descripcio = "Descripcio del projecte nou" });
        }
    }
}