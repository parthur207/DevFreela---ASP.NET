using DevFreela.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.DTOs.GenericDTOs
{
    public class ProjectGenericDTO
    {
        public ProjectGenericDTO(int id, string title, string clientName, string freeLancerName, decimal totalCost)
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

    }
}
