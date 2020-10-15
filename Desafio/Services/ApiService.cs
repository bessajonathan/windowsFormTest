using Desafio.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Desafio.Services
{
    public class ApiService
    {
     
        public async Task<UsersList> GetData()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://0f26bdf5-c99d-4193-b418-5a036dc134d8.mock.pstmn.io/users");

            if (!response.IsSuccessStatusCode)
            {
                return new UsersList();

            }

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsersList>(data);
        }
    }
}
