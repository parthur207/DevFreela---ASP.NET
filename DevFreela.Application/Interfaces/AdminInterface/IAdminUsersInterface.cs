using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Models;
using DevFreela.Domain.Models;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.AdminInterface
{
    public interface IAdminUsersInterface
    {
        //Querys
        Task<ResponseModel<List<UserDTO>>> GetAllUsersAdmin();
        Task<ResponseModel<UserDTO>> GetUserByEmailAdmin(string Email);
        Task<ResponseModel<List<UserDTO>>> GetAllFreelancersAdmin();
        Task<ResponseModel<List<UserDTO>>> GetAllClientsAdmin();
        Task<ResponseModel<List<UserDTO>>> GetAllUsersInactiveAdmin();

        //Commands
        Task<SimpleResponseModel> InactiveUserAdmin(string Email);
        Task<SimpleResponseModel> ActivateUserAdmin(string Email);
    }
}
