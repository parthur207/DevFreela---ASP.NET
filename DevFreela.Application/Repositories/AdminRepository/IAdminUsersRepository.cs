using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Entities;
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
        Task<ResponseModel<List<UserEntity>>> GetAllUsersAdminAsync(int Size);
        Task<ResponseModel<UserEntity>> GetUserByEmailAdminAsync(string Email);
        Task<ResponseModel<List<UserEntity>>> GetAllFreelancersAdminAsync(int Size);
        Task<ResponseModel<List<UserEntity>>> GetAllClientsAdminAsync(int Size);
        Task<ResponseModel<List<UserEntity>>> GetAllUsersInactiveAdminAsync(int Size);

        //Commands
        Task<SimpleResponseModel> InactiveUserAdminAsync(string Email);
        Task<SimpleResponseModel> ActivateUserAdminAsync(string Email);
    }
}
