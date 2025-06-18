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
        public static AdminFreelancerProjectDTO ToAdminFreelancerProjectDTO(ProjectEntity entity)//GetById
            => new(entity.Id, entity.Title, entity.Description,entity.Client.FullName,
           entity.FreeLancer.FullName, entity.IsDeleted, entity.TotalCost, entity.Comments);

        public static GenericProjectDTO ToGenericProjectDTO(ProjectEntity project)//GetSearch
            => new(project.Id, project.Title,
                project.Client.FullName, project.FreeLancer.FullName, project.TotalCost);

        public static ClientBuyerProjectDTO ToClientBuyerProjectDTO() 
        {
            throw new NotImplementedException();
        }

        public static ProjectEntity ToProjectEntity(CreateProjectModel model)
          => new(model.Title, model.Description, model., model., model.TotalCost);
    }
}
