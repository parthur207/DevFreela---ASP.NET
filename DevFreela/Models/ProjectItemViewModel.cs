using DevFreela.Entities;

namespace DevFreela.Models
{
    public class ProjectItemViewModel
    {

        public ProjectItemViewModel(int id, string title, string description, string clientName, string freeLancerName, decimal totalCost)
        {
            Id = id;
            Title = title;
            Description = description;
            ClientName = clientName;
            FreeLancerName = freeLancerName;
            TotalCost = totalCost;

        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }
        public string ClientName { get; private set; }

        public string FreeLancerName { get; private set; }

        public decimal TotalCost { get; private set; }


        public static ProjectItemViewModel FromEntity(Project entity)
           => new ProjectItemViewModel(entity.Id, entity.Title, entity.Description,
               entity.Client.FullName, entity.FreeLancer.FullName, entity.TotalCost);

    }
}
