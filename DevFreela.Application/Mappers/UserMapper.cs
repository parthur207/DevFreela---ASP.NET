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
        public static GenericUserDTO ToUserGenericDTO(UserEntity entity)
        {
            var skills = entity.Skills.Select(x => x.Skill.Description).ToList();
            return new GenericUserDTO(entity.FullName, entity.Email, entity.Role, entity.BirthDate, skills);
        }

        public static UserEntity ToUserEntity(CreateUserModel model)
         => new(model.FullName, model.Email, model.Password, model.BirthDate, model.Role);
    }
}
