using System.ComponentModel.DataAnnotations;

namespace Desafio.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Empresa { get; set; }
        public string Hash { get; set; }

        [Display(Name = "Hash Decrip")]
        public string HashDecrip { get; set; }
    }
}
