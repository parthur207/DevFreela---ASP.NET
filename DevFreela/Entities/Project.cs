using DevFreela.Enum;

namespace DevFreela.Entities
{
    public class Project : BaseEntity
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }

        public int IdClient { get; private set; }

        public User Client { get; private set; }
        public int IdFreeLancer { get; private set; }

        public User FreeLancer { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime? StartedAt{ get; private set; }

        public DateTime? CompletedAt { get; private set; }

        public ProjectStatusEnum Status { get; private set; }

        public List<ProjectComment> Comments { get; set; }

        public Project()
        {

        }
    }
}
