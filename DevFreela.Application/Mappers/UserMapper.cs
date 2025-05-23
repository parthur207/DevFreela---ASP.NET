using DevFreela.Application.DTOs;
using DevFreela.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class UserMapper
    {

        public static UserDTO ToUserViewModel(UserEntity entity)
        {
            var skills = entity.Skills.Select(x => x.Skill.Description).ToList();
            return new UserDTO(entity.FullName, entity.Email, entity.BirthDate, skills);
        }
    }
}
