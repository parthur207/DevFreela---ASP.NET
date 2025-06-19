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
        public AdminFreelancerProjectDTO(int id, string title, string description, List<(string, string)> buyers ,string freeLancerName, bool isDeleted, decimal totalCost, List<(string, string)> comments)
        {
            Id = id;
            Title = title;
            Description = description;
            Buyers = buyers;
            FreeLancerName = freeLancerName;
            IsDeleted = isDeleted;
            TotalCost = totalCost;
            Comments = comments;
        }

        public int Id { get; private set; }

        public string Title { get; private set; }

        public string Description { get; private set; }

        public List <(string, string)> Buyers { get; private set; }

        public string FreeLancerName { get; private set; }

        public decimal TotalCost { get; private set; }

        public bool IsDeleted { get; private set; }

        public List<(string, string)> Comments { get; private set; }


    }
}
