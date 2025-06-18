using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.DTOs.GenericDTOs
{
    public class GenericUserDTO
    {

        public GenericUserDTO(string fullName, string email, RolesTypesEnum role, DateTime birthDate, List<string> skills)
        {
            FullName = fullName;
            Email = email;
            Role = role.ToString();
            BirthDate = birthDate;
            Skills = skills;
        }

        public string FullName { get; private set; }
        public string Email { get; private set; }
        public string Role { get; private set; }
        public DateTime BirthDate { get; private set; }
        public List<string> Skills { get; private set; }
    }
}
