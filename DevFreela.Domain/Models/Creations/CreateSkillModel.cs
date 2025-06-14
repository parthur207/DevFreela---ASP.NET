using DevFreela.Domain.Entities;

namespace DevFreela.Domain.Models.Creations
{
    public class CreateSkillModel
    {

        public CreateSkillModel(string description)
        {
            Description = description;
        }
        public string Description { get; set; }
    }
}
