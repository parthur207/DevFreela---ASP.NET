using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class UserMapper
    { 
        public static UserDTO ToUserDTO(UserEntity entity)
        {
            var skills = entity.Skills.Select(x => x.Skill.Description).ToList();
            return new UserDTO(entity.FullName, entity.Email, entity.BirthDate, skills);
        }

        public static UserEntity ToUserEntity(CreateUserModel model)
         => new(model.FullName, model.Email, model.BirthDate);
    }
}
