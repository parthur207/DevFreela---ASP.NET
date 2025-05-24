using DevFreela.Application.DTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class SkillMapper
    {
        public static List<SkillDTO> ToListSkillDTO(List<(int, string)> listTuple)
        {
            var skillsMapped = new List<SkillDTO>();

            foreach (var (id, skill) in listTuple)
            {
                skillsMapped.Add(new SkillDTO(id, skill));
            }

            return skillsMapped;
        }

        public static SkillEntity ToSkillEntity(CreateSkillModel model)
            => new(model.Description);
    }
}
