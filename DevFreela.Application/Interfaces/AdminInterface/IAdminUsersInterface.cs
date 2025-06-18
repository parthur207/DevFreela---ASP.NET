using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Models;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.AdminInterface
{
    public interface IAdminUsersInterface
    {
        //Querys
        Task<ResponseModel<List<GenericUserDTO>>> GetAllUsersAdmin(int Size);
        Task<ResponseModel<GenericUserDTO>> GetUserByEmailAdmin(string Email);
        Task<ResponseModel<List<GenericUserDTO>>> GetAllFreelancersAdmin(int Size);
        Task<ResponseModel<List<GenericUserDTO>>> GetAllClientsAdmin(int Size);
        Task<ResponseModel<List<GenericUserDTO>>> GetAllUsersInactiveAdmin(int Size);

        //Commands
        Task<SimpleResponseModel> InactiveUserAdmin(string Email);
        Task<SimpleResponseModel> ActivateUserAdmin(string Email);
    }
}
