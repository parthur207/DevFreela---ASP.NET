using DevFreela.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class UserSkillMapper
    {
        public static UserSkillEntity ToUserSkillEntity(int UserId, int SkillId)
        {
            return new UserSkillEntity(UserId, SkillId);
        }
    }
}
