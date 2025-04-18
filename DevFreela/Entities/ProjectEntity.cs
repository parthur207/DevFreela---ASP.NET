using DevFreela.Enum;

namespace DevFreela.Entities
{
    public class ProjectEntity : BaseEntity
    {

        public ProjectEntity(){ }
     
        public ProjectEntity(string title, string description, int idClient, int idFreeLancer, decimal totalCost) 
            : base()
        {
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreeLancer = idFreeLancer;
            TotalCost = totalCost;

            Status = ProjectStatusEnum.Created;
            Comments = [];
        }


        public string Title { get; private set; }
        public string Description { get; private set; }

        public int IdClient { get; private set; }

        public UserEntity Client { get; private set; }
        public int IdFreeLancer { get; private set; }

        public UserEntity FreeLancer { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime? StartedAt{ get; private set; }

        public DateTime? CompletedAt { get; private set; }

        public ProjectStatusEnum Status { get; private set; }

        public List<ProjectCommentEntity> Comments { get; set; }

        public void Cancel()
        {
            if (Status==ProjectStatusEnum.InProgress || Status==ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status==ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;

            }
        }

        public void Complete()
        {
            if (Status==ProjectStatusEnum.PaymentPending || Status==ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.Completed;
                CompletedAt = DateTime.Now;
            }
        }

        public void SetPaymentPeding()
        {
            if (Status==ProjectStatusEnum.InProgress) 
            {
                Status = ProjectStatusEnum.PaymentPending;
            }
        }

        public void Update(string title, string description, Decimal totalcost)
        {
            Title = title;
            Description = description;
            TotalCost = totalcost;
        }
    }
}
