using Desafio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.Repository
{

    public class UserRepository
    {
        private readonly Context context;
        public UserRepository()
        {
            context = new Context();
        }


        public IEnumerable<User> GetAllUsers()
        {
            return context.Users.ToList();
        }

        public void PopulationTableUsers(List<User> users)
        {
            var any = context.Users.Any();

            if (any)
            {
                var lstusers = GetAllUsers();

                context.RemoveRange(lstusers);
                context.SaveChanges();
            }
            users.ForEach(x =>
            {
                context.Users.Add(x);
            });

            context.SaveChanges();
        }

        public void ExecuteMigration()
        {
            context.Database.Migrate();
        }

        public bool VerifyPopulation()
        {
            return context.Users.Any();
        }
    }
}
