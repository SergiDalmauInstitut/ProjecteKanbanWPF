using ProjecteKanbanWPF.ApiClient;
using ProjecteKanbanWPF.ApiClient.ApiObjects;
using ProjecteKanbanWPF.Objects;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProjecteKanbanWPF.Windows
{
    public partial class FinestraLogin : Window
    {
        readonly UsersApiClient usersApi;
        public FinestraLogin()
        {
            InitializeComponent();
            DataContext = this;

            usersApi = new();
        }
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("falta fer implementació");

            FinestraCanviContrasenya fcc = new();
            fcc.Show();
        }
        private void TextBlock_MouseEnter(object sender, MouseEventArgs e)
        {
            TextBlock block = (TextBlock)sender;

            block.Foreground = Brushes.Blue;
        }

        private void TextBlock_MouseLeave(object sender, MouseEventArgs e)
        {
            TextBlock block = (TextBlock)sender;

            block.Foreground = Brushes.Black;
        }
        private async void Login_Click(object sender, RoutedEventArgs e)
        {
            string nom = txtBox.Text;
            string contrasenya = PasswordBox.Password;

            if (string.IsNullOrEmpty(nom) || string.IsNullOrEmpty(contrasenya))
            {
                MessageBox.Show("Emplena les dades");
                return;
            }

            LoginBtn.IsEnabled = false;
            Usuari? user = await ValidateUser(nom, contrasenya);
            if (user != null)
            {
                FinestraProjectes finestraProjectes = new(user);
                finestraProjectes.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Usuari o contrasenya incorrectes");
            }
            LoginBtn.IsEnabled = true;
        }
        private async Task<Usuari?> ValidateUser(string nom, string contrasenya)
        {
            Usuari? result = null;
            LoginDTO login = new()
            {
                Mail = nom,
                Password = HashPassword(contrasenya)
            };
            try
            {
                result = await usersApi.GetUserByLoginAsync(login);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return result;
        }
        private async void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterBtn.IsEnabled = false;
            FinestraRegistre fr = new();
            bool? result = fr.ShowDialog();

            if (result == true)
            {
                Usuari usuari = fr.UsuariFinal;
                usuari.Password = HashPassword(usuari.Password);

                try
                {
                    await usersApi.AddAsync(usuari);
                    MessageBox.Show("Usuari registrat correctament.", "Operació correcta");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            RegisterBtn.IsEnabled = true;
        }

        private static string HashPassword(string pass)
        {
            StringBuilder hash = new();

            byte[] hashArray = SHA256.HashData(Encoding.UTF8.GetBytes(pass));
            foreach (byte b in hashArray)
            {
                hash.Append(b.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}