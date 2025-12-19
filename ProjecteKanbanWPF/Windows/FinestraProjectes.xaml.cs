using ProjecteKanbanWPF.ApiClient;
using ProjecteKanbanWPF.Objects;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProjecteKanbanWPF.Windows
{
    public partial class FinestraProjectes : Window
    {
        Usuari usuariIniciat;
        readonly ProjectsApiClient projectsApi;
        public ObservableCollection<Projecte> Projectes { get; set; } = [];

        public FinestraProjectes(Usuari user)
        {
            InitializeComponent();
            usuariIniciat = user;
            projectsApi = new();

            GetProjectesAsync(usuariIniciat);

            DataContext = this;
        }

        private async void GetProjectesAsync(Usuari user)
        {
            List<Projecte>? projectes = null;
            try
            {
                projectes = await projectsApi.GetProjectsFromUserId(user.Id);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (projectes != null)
            {
                foreach (var p in projectes)
                {
                    Projectes.Add(p);
                }
            }
        }
        public void AfegirProjecte(Projecte projecte)
        {
            Projectes.Add(projecte);
        }

        public void EliminarProjecte(ProjecteVisual projecteVisual)
        {
            Projectes.Remove(projecteVisual.ProjecteData);
        }
        public void EntrarProjecte(Projecte projecte)
        {
            MainWindow mw = new(projecte);
            mw.Show();
            Close();
        }

        private void NouProjecte_Click(object sender, RoutedEventArgs e)
        {
            FinestraProjecteNou fn = new();
            bool? result = fn.ShowDialog();

            if (result == true)
            {
                
            }
        }
    }
}