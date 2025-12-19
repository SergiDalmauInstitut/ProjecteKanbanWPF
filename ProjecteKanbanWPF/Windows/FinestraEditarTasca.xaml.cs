using ProjecteKanbanWPF.Objects;
using System.Windows;

namespace ProjecteKanbanWPF.Windows
{
    public partial class FinestraEditarTasca : Window
    {
        public Tasca TascaResultat { get; private set; }
        public bool Afegir { get; private set; }

        public TascaVisual? TascaOriginal { get; set; }

        public FinestraEditarTasca()
        {
            InitializeComponent();

            TascaResultat = new Tasca { Id = 0, Nom = "Nova tasca" };
            this.DataContext = TascaResultat;
            this.Title = "Crear Nova Tasca";
        }

        public FinestraEditarTasca(Tasca tascaExistents)
        {
            InitializeComponent();

            TascaResultat = tascaExistents;
            this.DataContext = TascaResultat;
            this.Title = "Editar Tasca: " + tascaExistents.Nom;
        }

        private void Afegir_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TascaResultat.Nom))
            {
                MessageBox.Show("El nom de la tasca no pot estar buit.", "Error de validació", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show(TascaResultat.Nom);
            this.DialogResult = true;
            this.Afegir = true;
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Afegir = false;

            if (Owner is MainWindow mw && TascaOriginal != null)
            {
                mw.EliminarTasca(TascaOriginal);
            }
        }
    }
}