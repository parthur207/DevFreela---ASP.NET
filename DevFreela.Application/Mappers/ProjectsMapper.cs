using DevFreela.Application.DTOs.ClientDTOs;
using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class ProjectMapper
    {
        public static AdminFreelancerProjectDTO ToAdminFreelancerProjectDTO(ProjectEntity entity)
        { 

       
              var buyers = entity.Purchases.Select(x => (x.User.FullName, x.User.Email)).ToList();
            List<(string, string)> comments = entity.Comments.SelectMany(x => x.User.FullName, x=>x.Content  ).ToList();
            return new(entity.Id, entity.Title, entity.Description, buyers,
               entity.FreeLancer.FullName, entity.IsDeleted, entity.TotalCost, comments);
        }
        public static GenericProjectDTO ToGenericProjectDTO(ProjectEntity project)//GetSearch
            => new(project.Id, project.Title, project.FreeLancer.FullName, project.TotalCost);

        public static ClientBuyerProjectDTO ToClientBuyerProjectDTO() 
        {
            throw new NotImplementedException();
        }

        public static ProjectEntity ToProjectEntity(CreateProjectModel model)
          => new(model.Title, model.Description, model., model., model.TotalCost);
    }
}
