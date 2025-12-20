using ProjecteKanbanWPF.Objects;
using System.Windows;

namespace ProjecteKanbanWPF.Windows
{
    public partial class FinestraEditarTasca : Window
    {
        public Tasca TascaResultat { get; private set; }
        public bool Afegir { get; private set; } = false;

        public TascaVisual? TascaOriginal { get; set; }

        public FinestraEditarTasca(Projecte proj, Usuari user)
        {
            InitializeComponent();

            TascaResultat = new Tasca { Id = 0, Name = "Nova tasca", IdProject = proj.Id, IdResponsible = user.Id };
            DataContext = TascaResultat;
            Title = "Crear Nova Tasca";
        }

        public FinestraEditarTasca(Tasca tascaExistents)
        {
            InitializeComponent();

            TascaResultat = tascaExistents;
            DataContext = TascaResultat;
            Title = "Editar Tasca: " + tascaExistents.Name;
        }

        private void Afegir_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TascaResultat.Name))
            {
                MessageBox.Show("El nom de la tasca no pot estar buit.", "Error de validació", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DialogResult = true;
            Afegir = true;
        }

        private void Eliminar_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Afegir = false;

            if (Owner is MainWindow mw && TascaOriginal != null)
            {
                mw.EliminarTasca(TascaOriginal);
            }
        }
    }
}