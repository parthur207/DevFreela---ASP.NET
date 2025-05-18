using DevFreela.Domain.Entities;

namespace DevFreela.Application.Models
{
    public class CreateUserModel
    {

        public CreateUserModel(string fullName, string email, DateTime birthDate)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
        }
        
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

       public UserEntity ToUserEntity()
        => new(FullName, Email, BirthDate);
    }
}