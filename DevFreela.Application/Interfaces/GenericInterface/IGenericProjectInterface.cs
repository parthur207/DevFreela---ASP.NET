using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevFreela.Application.DTOs.GenericDTOs;

namespace DevFreela.Application.Interfaces.GenericInterface
{
    public interface IGenericProjectInterface
    {

        //Querys
        Task<ResponseModel<List<ProjectItemDTO>>> GetSearch(string Search, int N);

        Task<ResponseModel<ProjectDTO>> GetByProjectId(int Id);


        //Commands
        Task<SimpleResponseModel> CreateCommentProject(int Id, CreateCommentModel CommentModel);
    }
}
