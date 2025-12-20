using ProjecteKanbanWPF.ApiClient;
using ProjecteKanbanWPF.Objects;
using System.Collections.ObjectModel;
using System.Windows;

namespace ProjecteKanbanWPF.Windows
{
    public partial class FinestraProjectes : Window
    {
        readonly Usuari usuariIniciat;
        readonly ProjectsApiClient projectsApi;
        readonly TasksApiClient tasksApi;
        public ObservableCollection<Projecte> Projectes { get; set; } = [];

        public FinestraProjectes(Usuari user)
        {
            InitializeComponent();
            usuariIniciat = user;
            projectsApi = new();
            tasksApi = new();

            CarregarProjectes();

            DataContext = this;
            if (!user.Role.Equals("admin", StringComparison.CurrentCultureIgnoreCase))
                NewProjectBtn.Visibility = Visibility.Hidden;
        }

        private void CarregarProjectes()
        {
            GetProjectesAsync(usuariIniciat);
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

        public async void EliminarProjecte(ProjecteVisual projecteVisual)
        {
            try
            {
                await projectsApi.RemoveProjectAsync(projecteVisual.ProjecteData.Id);
                Projectes.Remove(projecteVisual.ProjecteData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void EntrarProjecte(Projecte projecte)
        {
            MainWindow mw = new(projecte, usuariIniciat);
            mw.Show();
            Close();
        }

        private async void NouProjecte_Click(object sender, RoutedEventArgs e)
        {
            FinestraProjecteNou fn = new(usuariIniciat);
            bool? result = fn.ShowDialog();

            if (result == true)
            {
                try
                {
                    await projectsApi.CreateProjectAsync(fn.ProjecteFinal);
                    Projectes.Add(fn.ProjecteFinal);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}