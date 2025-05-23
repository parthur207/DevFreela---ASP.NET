using DevFreela.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class SkillMappers
    {
        public static List<SkillDTO> ToListSkillViewModel(List<(int, string)> listTuple)
        {
            var skillsMapped = new List<SkillDTO>();

            foreach (var (id, skill) in listTuple)
            {
                skillsMapped.Add(new SkillDTO(id, skill));
            }

            return skillsMapped;
        }
    }
}
