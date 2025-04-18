using DevFreela.Entities;

namespace DevFreela.Models
{
    public class ProjectViewModel
    {
        public ProjectViewModel(int id, string title, string description, int idClient, int idFreeLancer, string clientName, string freeLancerName, decimal totalCost, Dictionary<int, string> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            IdClient = idClient;
            IdFreeLancer = idFreeLancer;
            ClientName = clientName;
            FreeLancerName = freeLancerName;
            TotalCost = totalCost;
            Comments = comments;

        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public int IdClient { get; private set; }

        public int IdFreeLancer { get; private set; }

        public string ClientName { get; private set; }

        public string FreeLancerName { get; private set; }

        public Decimal TotalCost { get; private set; }

        public Dictionary<int, string> Comments { get; private set; }


        public static ProjectViewModel ToProjectModel(ProjectEntity entity)
        {
            var comments = entity.Comments.ToDictionary(x => x.Key.IdUser, x => x.Value.Content);
            return new ProjectViewModel(entity.Id, entity.Title, entity.Description,
                    entity.IdClient, entity.IdFreeLancer, entity.Client.FullName,
                    entity.FreeLancer.FullName, entity.TotalCost, comments);
        }  
    }
}
