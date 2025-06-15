using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.GenericRepository
{
    public interface IProjectGenericRepository
    {
        //Querys
        Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsAsync(string search, int Size);
        Task<ResponseModel<List<ProjectEntity>>> GetAllProjectsByOwnerAsync(string NameOrEmail, int Size);


        //Commands
        Task<SimpleResponseModel> CreateCommentProjectAsync(int UserId, ProjectCommentEntity CommentModel);

    }
}
