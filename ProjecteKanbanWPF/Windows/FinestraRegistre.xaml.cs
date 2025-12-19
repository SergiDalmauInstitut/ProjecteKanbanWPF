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

namespace ProjecteKanbanWPF.Windows
{
    /// <summary>
    /// Lógica de interacción para FinestraRegistre.xaml
    /// </summary>
    public partial class FinestraRegistre : Window
    {
        public FinestraRegistre()
        {
            InitializeComponent();
        }

        private void Acceptar_Click(object sender, RoutedEventArgs e)
        {
            /*
            Aqui si vols pots fer un if amb un messageBox dintre per dir que s'ha guardat el usuari correctament
            If ("Funciona"){
            MessageBox.Show("S'ha registrat l'usuari");
            }
            else{
            MessageBox.Show("Falten dades per completar");
            */
            this.Close();
        }

        private void Cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
