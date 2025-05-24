using DevFreela.Application.DTOs;
using DevFreela.Application.ViewModels;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models;
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
        public static ProjectDTO ToProjectDTO(ProjectEntity entity)//GetById
            => new(entity.Id, entity.Title, entity.Description,
           entity.IdClient, entity.IdFreeLancer, entity.Client.FullName,
           entity.FreeLancer.FullName, entity.IsDeleted, entity.TotalCost, entity.Comments);

        public static ProjectItemDTO ToProjectItemDTO(ProjectEntity project)//GetSearch
            => new(project.Id, project.Title,
                project.Client.FullName, project.FreeLancer.FullName, project.TotalCost);



        public static ProjectEntity ToProjectEntity(CreateProjectModel model)
          => new(model.Title, model.Description, model.IdClient, model.IdFreeLancer, model.TotalCost);
    }
}
