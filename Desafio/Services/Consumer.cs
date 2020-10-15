using Desafio.Repository;
using System;
using System.Linq;
using System.Text;

namespace Desafio.Services
{
    public class Consumer
    {
        public async void GetUsersFromApi()
        {
            var apiService = new ApiService();
            var dataFromApi = await apiService.GetData();

            foreach (var user in dataFromApi.Users)
            {
                var hashService = new Hash();
                var hash = hashService.BuildHash(user.Role);
                user.Hash = hash;
                var description = Encoding.UTF8.GetString(Convert.FromBase64String(hash));
                user.HashDescription = description;
            }

            var context = new Context();
            context.PopulationTableUsers(dataFromApi.Users);
        }
    }
}
