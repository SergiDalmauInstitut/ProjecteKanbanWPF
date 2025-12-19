using ProjecteKanbanWPF.Objects;
using System.Windows;

namespace ProjecteKanbanWPF.Windows
{
    /// <summary>
    /// Lógica de interacción para FinestraRegistre.xaml
    /// </summary>
    public partial class FinestraRegistre : Window
    {
        public Usuari UsuariFinal { get; private set; }

        public FinestraRegistre()
        {
            UsuariFinal = new();
            DataContext = UsuariFinal;
            InitializeComponent();
        }

        private void Acceptar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameBox.Text) || string.IsNullOrEmpty(MailBox.Text)
                || string.IsNullOrEmpty(LastNameBox.Text)
                || string.IsNullOrEmpty(PasswordBox.Password)
                || string.IsNullOrEmpty(RoleBox.Text))
            {
                MessageBox.Show("Emplena les dades");
                return;
            }

            UsuariFinal.Password = PasswordBox.Password;
            DialogResult = true;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
