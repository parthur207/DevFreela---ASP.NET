using DevFreela.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.DTOs.GenericDTOs
{
    public class AdminFreelancerProjectDTO
    {
        public AdminFreelancerProjectDTO(int id, string title, string description, string clientName, string freeLancerName, bool isDeleted, decimal totalCost, List<ProjectCommentEntity> comments)
        {
            Id = id;
            Title = title;
            Description = description;
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

        public string ClientName { get; private set; }

        public string FreeLancerName { get; private set; }

        public decimal TotalCost { get; private set; }

        public bool IsDeleted { get; private set; }

        public List<object> Comments { get; private set; }


    }
}
