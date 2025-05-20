using DevFreela.Domain.Entities;

namespace DevFreela.Application.ViewModels
{
    public class ProjectItemViewModel
    {
        public ProjectItemViewModel(int id, string title, string clientName, string freeLancerName, decimal totalCost)
        {
            Id = id;
            Title = title;
            ClientName = clientName;
            FreeLancerName = freeLancerName;
            TotalCost = totalCost;

        }

        public int Id { get; private set; }

        public string Title { get; private set; }
        public string ClientName { get; private set; }

        public string FreeLancerName { get; private set; }

        public decimal TotalCost { get; private set; }


        public static ProjectItemViewModel ToProjectModel(ProjectEntity project)
           => new (project.Id, project.Title,
               project.Client.FullName, project.FreeLancer.FullName, project.TotalCost);

    }
}
