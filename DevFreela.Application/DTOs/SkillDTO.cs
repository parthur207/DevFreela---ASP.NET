using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.DTOs
{
    public class SkillDTO
    {

        public SkillDTO(int id, string skill)
        {
            Id = id;
            Skill = skill;
        }

        public int Id { get; set; }
        public string Skill { get; set; }

     
    }
}
