using ProjecteKanbanWPF.Objects;
using System.Windows;

namespace ProjecteKanbanWPF.Windows
{
    /// <summary>
    /// Lógica de interacción para FinestraProjecteNou.xaml
    /// </summary>
    public partial class FinestraProjecteNou : Window
    {
        public Projecte ProjecteFinal { get; private set; } = new Projecte();
        public FinestraProjecteNou()
        {
            InitializeComponent();
            DataContext = ProjecteFinal;
        }
        private void Acceptar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}