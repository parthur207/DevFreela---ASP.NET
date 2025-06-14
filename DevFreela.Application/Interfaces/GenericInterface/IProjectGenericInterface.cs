using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface IProjectGenericInterface
    {

        //Querys
        Task<ResponseModel<List<ProjectDTO>>> GetAllProjects(string search, int Size);
        Task<ResponseModel<List<ProjectDTO>>> GetAllProjectsByOwner(string NameOrEmail, int Size);


        //Commands
        Task<SimpleResponseModel> CreateCommentProject(int UserId, CreateCommentModel CommentModel);
    }
}
