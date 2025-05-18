using DevFreela.Domain.Entities;

namespace DevFreela.Application.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, int idClient, int idFreeLancer, string clientName, string freeLancerName, bool isDeleted, decimal totalCost, List<ProjectCommentEntity> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreeLancer = idFreeLancer;
            ClientName = clientName;
            FreeLancerName = freeLancerName;
            IsDeleted = isDeleted;
            TotalCost = totalCost;
            Comments = comments.Select(x => new { x.IdUser, x.Content })
                .Cast<object>()
                .ToList();
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int IdClient { get; private set; }

        public int IdFreeLancer { get; private set; }

        public string ClientName { get; private set; }

        public string FreeLancerName { get; private set; }

        public decimal TotalCost { get; private set; }

        public bool IsDeleted { get; private set; }

        public List<object> Comments { get; private set; }


        public static ProjectViewModel ToProjectModel(ProjectEntity entity)
        =>new(entity.Id, entity.Title, entity.Description,
               entity.IdClient, entity.IdFreeLancer, entity.Client.FullName,
               entity.FreeLancer.FullName, entity.IsDeleted, entity.TotalCost, entity.Comments);
        
    }
}
