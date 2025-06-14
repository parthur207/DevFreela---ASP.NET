using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.AdminService
{
    internal class AdminUsersService : IAdminUsersInterface
    {

        public Task<ResponseModel<List<UserDTO>>> GetAllClientsAdmin(int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserDTO>>> GetAllFreelancersAdmin(int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserDTO>>> GetAllUsersAdmin(int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<List<UserDTO>>> GetAllUsersInactiveAdmin(int Size)
        {
            throw new NotImplementedException();
        }

        public Task<ResponseModel<UserDTO>> GetUserByEmailAdmin(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> ActivateUserAdmin(string Email)
        {
            throw new NotImplementedException();
        }

        public Task<SimpleResponseModel> InactiveUserAdmin(string Email)
        {
            throw new NotImplementedException();
        }
    }
}
