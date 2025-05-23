using DevFreela.Application.DTOs;
using DevFreela.Application.ViewModels;
using DevFreela.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Mappers
{
    public class ProjectMapper
    {
        public static ProjectDTO ToProjectModel(ProjectEntity entity)
        => new(entity.Id, entity.Title, entity.Description,
       entity.IdClient, entity.IdFreeLancer, entity.Client.FullName,
       entity.FreeLancer.FullName, entity.IsDeleted, entity.TotalCost, entity.Comments);

        public static ProjectItemDTO ToProjectItemModel(ProjectEntity project)
        => new(project.Id, project.Title,
            project.Client.FullName, project.FreeLancer.FullName, project.TotalCost);
    }
}
