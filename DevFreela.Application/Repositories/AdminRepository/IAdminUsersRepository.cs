using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.AdminRepository
{
    public interface IAdminUsersRepository
    {

        //Querys
        Task<ResponseModel<List<UserDTO>>> GetAllUsersAdminAsync(int Size);
        Task<ResponseModel<UserDTO>> GetUserByEmailAdminAsync(string Email);
        Task<ResponseModel<List<UserDTO>>> GetAllFreelancersAdminAsync(int Size);
        Task<ResponseModel<List<UserDTO>>> GetAllClientsAdminAsync(int Size);
        Task<ResponseModel<List<UserDTO>>> GetAllUsersInactiveAdminAsync(int Size);

        //Commands
        Task<SimpleResponseModel> InactiveUserAdminAsync(string Email);
        Task<SimpleResponseModel> ActivateUserAdminAsync(string Email);
    }
}
