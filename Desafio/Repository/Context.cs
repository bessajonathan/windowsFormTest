using Desafio.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Repository
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=db.sqlite3");
        }
        public DbSet<User> Users { get; set; }
    }
}
