using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class SkillMapper
    {
        public static List<AdminFreelancerSkillDTO> ToListSkillDTO(List<SkillEntity> Skills)
        {
            var skillsMapped = new List<AdminFreelancerSkillDTO>();

            foreach (var s in Skills)
            {
                skillsMapped.Add(new AdminFreelancerSkillDTO(s.Description));
            }

            return skillsMapped;
        }

        public static SkillEntity ToSkillEntity(CreateSkillModel model)
            => new(model.Description);
    }
}
