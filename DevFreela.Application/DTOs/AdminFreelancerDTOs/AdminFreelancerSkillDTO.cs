using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.DTOs.AdminFreelancerDTOs
{
    public class AdminFreelancerSkillDTO
    {
        public AdminFreelancerSkillDTO(string skill)
        {
            Skill = skill;
        }

        public string Skill { get; set; }

    }
}
