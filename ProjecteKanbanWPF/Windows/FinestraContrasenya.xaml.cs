using System;
using System.Collections.Generic;
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
using ProjecteKanbanWPF.Objects;

namespace ProjecteKanbanWPF.Windows
{
    /// <summary>
    /// Lógica de interacción para FinestraContrasenya.xaml
    /// </summary>
    public partial class FinestraCanviContrasenya : Window
    {
        public CanviContrasenya Dades { get; set; }

        public FinestraCanviContrasenya()
        {
            InitializeComponent();

            Dades = new CanviContrasenya();
            DataContext = Dades;
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            // si pots cambia la contrasenya en al bdd
            this.Close();
        }
        private void Canviar_Click(object sender, RoutedEventArgs e)
        {
            //Dades.ContrasenyaAntiga = PasswordAntiga.Password;
            //Dades.ContrasenyaNova = PasswordNova.Password;

            // MessageBox.Show("S'ha canviat de contrasenya");
            this.Close();
        }
    }
}
