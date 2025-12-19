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
    public partial class FinestraLogin : Window
    {
        public FinestraLogin()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("falta fer implementació");
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock block = sender as TextBlock;

            block.Foreground = Brushes.Blue;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock block = sender as TextBlock;

            block.Foreground = Brushes.Black;
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string nom = txtBox.Text; 
            string contrasenya = PasswordBox.Password;

            if (ValidateUser(nom, contrasenya))
            {
                FinestraProjectes finestraProjectes = new FinestraProjectes();
                finestraProjectes.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuari o contrasenya incorrectes");
            }
        }
        private bool ValidateUser(string nom, string contrasenya)
        {
            // implementacio de la bdd / app 
            return nom == "admin" && contrasenya == "admin";
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // fer un add de les dades
            MessageBox.Show("S'han registrat les dades");
        }
    }
}