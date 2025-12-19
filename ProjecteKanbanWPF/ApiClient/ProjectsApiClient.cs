using ProjecteKanbanWPF.ApiClient.ApiObjects;
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
using System.Windows;

namespace ProjecteKanbanWPF.ApiClient
{
    internal class ProjectsApiClient
    {
        private readonly string BaseUri;
        private static readonly HttpClient _httpClient = new();

        public ProjectsApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"] ?? "https://localhost:44339/api/";
        }
        public async Task<List<Projecte>?> GetProjectsFromUserId(long Id)
        {
            List<Projecte>? projectes = [];

            using (var client = _httpClient)
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("projects/users/" + Id);

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
            }
            return projectes;
        }
    }
}
