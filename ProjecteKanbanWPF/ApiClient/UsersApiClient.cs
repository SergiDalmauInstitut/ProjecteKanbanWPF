using ProjecteKanbanWPF.ApiClient.ApiObjects;
using ProjecteKanbanWPF.Objects;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace ProjecteKanbanWPF.ApiClient
{
    internal class UsersApiClient
    {
        private readonly string BaseUri;
        private static readonly HttpClient _httpClient = new();

        public UsersApiClient()
        {
            BaseUri = ConfigurationManager.AppSettings["BaseUri"] ?? "https://localhost:44339/api/";
        }

        /// <summary>
        /// Obté un usuari a partir del Id
        /// </summary>
        /// <param name="Id">Codi d'usuari</param>
        /// <returns>Usuari o null si no el troba</returns>
        public async Task<Usuari?> GetUserByLoginAsync(LoginDTO login)
        {
            Usuari? user = new();

            using (var client = _httpClient)
            {
                client.BaseAddress = new Uri(BaseUri);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Enviem una petició GET al endpoint /users/{Id}
                HttpResponseMessage response = await client.PostAsJsonAsync("users/login", login);
                if (response.IsSuccessStatusCode)
                {
                    user = await response.Content.ReadFromJsonAsync<Usuari>();
                    response.Dispose();
                }
                else
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        user = null;
                    }
                }
            }
            return user;
        }

        public async Task AddAsync(Usuari user)
        {
            using var client = _httpClient;

            client.BaseAddress = new Uri(BaseUri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //Enviem una petició POST al endpoint /users}
            HttpResponseMessage response = await client.PostAsJsonAsync("users", user);
            response.EnsureSuccessStatusCode();
        }
    }
}
