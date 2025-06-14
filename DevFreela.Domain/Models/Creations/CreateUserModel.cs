using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace DevFreela.Domain.Models.Creations
{
    public class CreateUserModel
    {
        public CreateUserModel(string fullName, string email, DateTime birthDate, int phoneNumber, string password, string confirmPassword, RolesTypesEnum role)
        {
            if (role is RolesTypesEnum.Admin)
            {
                throw new ArgumentException("Erro. A atribuição de usuário 'Admin' é inválida.");
            }

            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            PhoneNumber = phoneNumber;
            Password = password;
            ConfirmPassword = confirmPassword;
            Role = role;
        }


        [Required(ErrorMessage = "O informe do nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome deve ter no máximo 100 caracteres.")]
        public string FullName { get; set; }


        [Required(ErrorMessage = "O informe do e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido.")]
        public string Email { get; set; }


        [Required(ErrorMessage = "O informe da data de nascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "A data de nascimento deve ser uma data válida.")]
        public DateTime BirthDate { get; set; }


        [Required(ErrorMessage = "O informe do telefone é obrigatório.")]
        [Range(100000000, 999999999, ErrorMessage = "Erro. O telefone deve ter 11 dígitos: (00) 0 0000-0000")]
        public int PhoneNumber { get; set; }


        [Required(ErrorMessage = "O informe de 'função' é obrigatório.")]
        [EnumDataType(typeof(RolesTypesEnum), ErrorMessage = "Erro. O tipo de função informado não é válido.")]
        public RolesTypesEnum Role { get; set; }


        [Required(ErrorMessage = "O informe da senha é obrigatório.")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Senha deve ter no mínimo 8 caracteres")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$",
        ErrorMessage = "Senha deve conter letras maiúsculas, minúsculas, números e caracteres especiais")]
        public string Password { get; set; }


        [Required(ErrorMessage = "A Confirmação de senha é obrigatória.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "As senhas informadas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}