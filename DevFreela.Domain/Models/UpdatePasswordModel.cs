using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Domain.Models
{
    public class UpdatePasswordModel
    {
        [Required(ErrorMessage = "O informe da senha atual é obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres.")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "Insira uma nova senha.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
            ErrorMessage = "A nova senha deve conter letras maiúsculas, minúsculas, números e caracteres especiais.")]
        public string NewPassword { get; set; }


        [Required(ErrorMessage = "Insira a confirmação da nova senha.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres.")]
        [Compare("NewPassword", ErrorMessage = "A confirmação da nova senha não confere com a nova senha.")]
        public string ConfirmNewPassword { get; set; }  
    }
}
