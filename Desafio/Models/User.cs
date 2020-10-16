using System.ComponentModel.DataAnnotations;

namespace Desafio.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Hash { get; set; }
        public string HashDecrip { get; set; }
    }
}
