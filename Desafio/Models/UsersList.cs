using System.Collections.Generic;

namespace Desafio.Models
{
    public class UsersList
    {
        public UsersList()
        {
            Users = new List<User>();
        }
        public List<User> Users { get; set; }
    }
}
