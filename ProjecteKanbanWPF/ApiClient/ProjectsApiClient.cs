using ProjecteKanbanWPF.Objects;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ProjecteKanbanWPF.ApiClient
{
    internal class ProjectsApiClient
    {
        private readonly string BaseUri;
        private static readonly HttpClient _httpClient = new();

        public ProjectsApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"] ?? "https://localhost:44339/api/";
            _httpClient.BaseAddress = new Uri(BaseUri);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<List<Projecte>?> GetProjectsFromUserId(long Id)
        {
            List<Projecte>? projectes = [];

            HttpResponseMessage response = await _httpClient.GetAsync("projects/users/" + Id);

            if (response.IsSuccessStatusCode)
            {
                projectes = await response.Content.ReadFromJsonAsync<List<Projecte>>();
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    projectes.Clear();
                }
            }
            return projectes;
        }

        public async Task<Projecte> CreateProjectAsync(Projecte newProject)
        {
            HttpResponseMessage response = await _httpClient.PostAsJsonAsync("projects", newProject);
            response.EnsureSuccessStatusCode();

            Projecte? createdProject = await response.Content.ReadFromJsonAsync<Projecte>();

            return createdProject ?? throw new HttpRequestException("Error en rebre el projecte creat de l'API.");
        }

        public async Task AddUserToProjectAsync(long projectId, long userId)
        {
            string url = $"projects/{projectId}/users/{userId}";

            HttpResponseMessage response = await _httpClient.PostAsync(url, content: null);
            response.EnsureSuccessStatusCode();
        }

        public async Task RemoveProjectAsync(long Id)
        {
            string url = $"projects/{Id}";

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}