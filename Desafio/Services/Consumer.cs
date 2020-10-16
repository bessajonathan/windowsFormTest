namespace Desafio.Services
{
    public class Consumer
    {
        private readonly ApiService apiService;
        private readonly UserService userService;
        public Consumer()
        {
            apiService = new ApiService();
            userService = new UserService();
        }
        public async void GetUsersFromApi()
        {
            var dataFromApi = await apiService.GetData();

            userService.PopulationTableUsers(dataFromApi);
        }
    }
}
