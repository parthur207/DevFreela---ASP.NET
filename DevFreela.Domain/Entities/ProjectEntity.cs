using DevFreela.Domain.Enums;

namespace DevFreela.Domain.Entities
{
    public class ProjectEntity : BaseEntity
    {
        public ProjectEntity(string title, string description, int idFreeLancer, decimal totalCost)
            : base()
        {
            Title = title;
            Description = description;
            IdFreeLancer = idFreeLancer;
            TotalCost = totalCost;
            Status = ProjectStatusEnum.Created;
            Comments = [];
            Purchases = [];
        }

        public string Title { get; private set; }
        public string Description { get; private set; }

        public int IdFreeLancer { get; private set; }
        public UserEntity FreeLancer { get; private set; }

        public decimal TotalCost { get; private set; }

        public DateTime? StartedAt { get; private set; }
        public DateTime? AvailableAt { get; private set; }

        public ProjectStatusEnum Status { get; private set; }

        public List<ProjectCommentEntity> Comments { get; set; }
        public List<UserProjectEntity> Purchases { get; private set; }

        public void AssignFreelancer(int idFreeLancer)
        {
            IdFreeLancer = idFreeLancer;
        }

        public void SetPaymentPending()
        {
            if (Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.Available || Status == ProjectStatusEnum.InProgress)
            {
                Status = ProjectStatusEnum.PaymentPending;
            }
        }

        public void Suspend()
        {
            if (Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.PaymentPending || Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Available)
            {
                Status = ProjectStatusEnum.Suspended;
            }
        }

        public void Cancel()
        {
            if (Status == ProjectStatusEnum.Created || Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended || Status == ProjectStatusEnum.Available)
            {
                Status = ProjectStatusEnum.Cancelled;
            }
        }

        public void Start()
        {
            if (Status == ProjectStatusEnum.Created)
            {
                Status = ProjectStatusEnum.InProgress;
                StartedAt = DateTime.Now;
            }
        }

        public void MakeAvailable()
        {
            if (Status == ProjectStatusEnum.InProgress || Status == ProjectStatusEnum.Suspended)
            {
                Status = ProjectStatusEnum.Available;
                AvailableAt = DateTime.Now;
            }
        }

        public void MakeAsSold()
        {
            if (Status == ProjectStatusEnum.PaymentPending)
            {
                Status = ProjectStatusEnum.Sold;
            }
        }

        public void UpdateProject(string title, string description, decimal totalCost)
        {
            Title = title;
            Description = description;
            TotalCost = totalCost;
        }
    }
}
