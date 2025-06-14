using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.GenericInterface;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.GenericService
{
    internal class ProjectGenericService : IProjectGenericInterface
    {
        public Task<SimpleResponseModel> CreateCommentProject(int UserId, CreateCommentModel CommentModel)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProjectDTO>>> GetAllProjects(string search, int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<ProjectDTO>>> GetAllProjectsByOwner(string NameOrEmail, int Size)
        {
            throw new NotImplementedException();
        }
    }
}
