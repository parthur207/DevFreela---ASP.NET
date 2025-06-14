using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Domain.Models.Creations
{
    public class LoginModel
    {
        [Required(ErrorMessage = "É necessário o informe de seu e-mail.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "É necessário o informe de sua senha.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
