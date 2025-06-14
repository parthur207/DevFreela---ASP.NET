using DevFreela.Application.DTOs.GenericDTOs;
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
        Task<ResponseModel<List<ProjectDTO>>> GetAllProjectsAsync(string search, int Size);
        Task<ResponseModel<List<ProjectDTO>>> GetAllProjectsByOwnerAsync(string NameOrEmail, int Size);


        //Commands
        Task<SimpleResponseModel> CreateCommentProjectAsync(int UserId, CreateCommentModel CommentModel);

    }
}
