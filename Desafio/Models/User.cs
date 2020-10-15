using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Desafio.Models
{
    public class User
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Role { get; set; }
        public string Hash { get; set; }
        public string HashDescription { get; set; }
    }
}
