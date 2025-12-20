using ProjecteKanbanWPF.Objects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace ProjecteKanbanWPF.ApiClient
{
    internal class TasksApiClient
    {
        private static string BaseUri;
        private static readonly HttpClient _httpClient = new();
        static TasksApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"] ?? "https://localhost:44339/api/";
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(BaseUri)
            };
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        public TasksApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"] ?? "https://localhost:44339/api/";
        }

        public async Task<Tasca> AddTaskToProjectAsync(Tasca tasca)
        {
            string url = $"tasks/{tasca.IdProject}";

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync(url, tasca);
            response.EnsureSuccessStatusCode();

            Tasca? tascaResultat = await response.Content.ReadFromJsonAsync<Tasca>();

            return tascaResultat ?? throw new HttpRequestException("Error en crear la tasca");
        }

        public async Task<int> EditTaskAsync(long IdProject,Tasca tasca)
        {
            string url = $"tasks/{IdProject}";

            HttpResponseMessage response = await _httpClient.PutAsJsonAsync(url, tasca);
            response.EnsureSuccessStatusCode();

            int? resultat = await response.Content.ReadFromJsonAsync<int>();

            return resultat ?? throw new HttpRequestException("Error en editar la tasca");
        }

        public async Task<List<Tasca>?> GetTasksFromProjectId(long Id)
        {
            List<Tasca>? tasques = [];

            HttpResponseMessage response = await _httpClient.GetAsync("tasks/" + Id);

            if (response.IsSuccessStatusCode)
            {
                tasques = await response.Content.ReadFromJsonAsync<List<Tasca>>();
            }
            else
            {
                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    tasques.Clear();
                }
            }
            return tasques;
        }

        public async Task RemoveTaskAsync(long Id)
        {
            string url = $"tasks/{Id}";

            HttpResponseMessage response = await _httpClient.DeleteAsync(url);
            response.EnsureSuccessStatusCode();
        }
    }
}
