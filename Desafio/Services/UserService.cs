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

        private readonly Hash hashService;
        private readonly UserRepository userRepository;

      

        public UserService()
        {
            hashService = new Hash();
            userRepository = new UserRepository();
        }

        public void ExecuteMigration()
        {
            userRepository.ExecuteMigration();
        }
        public IEnumerable<UserViewModel> GetAllUsers()
        {

            var data = userRepository.GetAllUsers();

            return data.Select(x => new UserViewModel
            {
                Id = int.Parse(x.Id),
                Nome = x.Name,
                Empresa = x.Company,
                Hash = x.Hash,
                HashDecrip = x.HashDecrip
            }).ToList();
        }

        public bool VerifyPopulation()
        {
            return userRepository.VerifyPopulation();
        }

        public IEnumerable<UserViewModel> SearchUsers(string user, string company)
        {
            var data = userRepository.GetAllUsers();

            if (!string.IsNullOrEmpty(user))
            {
                data = data.Where(x => x.Name.ToUpper() == user.ToUpper());
            }

            if (!string.IsNullOrEmpty(company))
            {
                data = data.Where(x => x.Company.ToUpper() == company.ToUpper());
            }

            return data.Select(x => new UserViewModel
            {
                Id = int.Parse(x.Id),
                Nome = x.Name,
                Empresa = x.Company,
                Hash = x.Hash,
                HashDecrip = x.HashDecrip
            }).ToList();
        }

        public void PopulationTableUsers(UsersList dataFromApi)
        {
            dataFromApi.Users.ForEach(x =>
            {
                var hash = hashService.BuildHash(x.Role);
                x.Hash = hash;
                var decript = Encoding.UTF8.GetString(Convert.FromBase64String(hash));
                x.HashDecrip = decript;
            });

            userRepository.PopulationTableUsers(dataFromApi.Users);
        }
    }
}
