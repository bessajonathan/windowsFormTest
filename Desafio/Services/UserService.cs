using Desafio.Models;
using Desafio.Repository;
using Desafio.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Desafio.Services
{
    public class UserService
    {
        private readonly Context context;
        private readonly Hash hashService;
        public UserService()
        {
            context = new Context();
            hashService = new Hash();
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {

            return context.GetAllUsers();
        }

        public IEnumerable<UserViewModel> SearchUsers(string user, string company)
        {

            var lstUsers = context.GetAllUsers();

            if (!string.IsNullOrEmpty(user))
            {
                lstUsers = lstUsers.Where(x => x.Nome.ToUpper() == user.ToUpper());
            }

            if (!string.IsNullOrEmpty(company))
            {
                lstUsers = lstUsers.Where(x => x.Empresa.ToUpper() == company.ToUpper());
            }

            return lstUsers;
        }

        public  void PopulationTableUsers(UsersList dataFromApi)
        {
            dataFromApi.Users.ForEach(x =>
            {
                var hash = hashService.BuildHash(x.Role);
                x.Hash = hash;
                var decript = Encoding.UTF8.GetString(Convert.FromBase64String(hash));
                x.HashDecrip = decript;
            });
          
            context.PopulationTableUsers(dataFromApi.Users);
        }
    }
}
