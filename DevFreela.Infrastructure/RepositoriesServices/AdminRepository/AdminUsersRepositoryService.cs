using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using DevFreela.A.RepositoriesServices.AdminRepository;
using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Repositories.AdminRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace DevFreela.Infrastructure.RepositoriesServices.AdminRepository
{
    public class AdminUsersRepositoryService : IAdminUsersRepository
    {

        private readonly DevFreelaDbContext _dbContext;
        public AdminUsersRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
     
        public async Task<ResponseModel<List<UserEntity>>> GetAllClientsAdminAsync(int Size)
        {
            ResponseModel<List<UserEntity>> Response = new ResponseModel<List<UserEntity>>();
            try
            {
                var Users = _dbContext.Users
                    .Where(u => u.Role == RolesTypesEnum.Client)
                    .Include(x=>x.OwnedProjects)
                    .Take(Size)
                    .ToList();

                if (Users is null || !Users.Any())
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Nenhum cliente foi encontrado.";
                    return Response;
                }

                Response.Content = Users;
                Response.Status = ResponseStatusEnum.Success;
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }


        public async Task<ResponseModel<List<UserEntity>>> GetAllFreelancersAdminAsync(int Size)
        { 
            
            ResponseModel<List<UserEntity>> Response = new ResponseModel<List<UserEntity>>();
            try
            {
                var Users = await _dbContext.Users
                    .Where(u => u.Role == RolesTypesEnum.FreeLancer)
                    .Include(x=>x.Skills)
                        .ThenInclude(x => x.Skill)  
                    .Take(Size)
                    .ToListAsync();

                if (Users is null || !Users.Any())
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Nenhum freelancer foi encontrado.";
                    return Response;
                }

                Response.Content = Users;
                Response.Status = ResponseStatusEnum.Success;
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<ResponseModel<List<UserEntity>>> GetAllUsersAdminAsync(int Size)
        {
            ResponseModel<List<UserEntity>> Response = new ResponseModel<List<UserEntity>>();
            try
            {
                var Users = await _dbContext.Users
                    .Include(x => x.Skills)
                        .ThenInclude(x => x.Skill)
                    .Include(x=>x.OwnedProjects)
                    .ThenInclude(x=>x.Title)
                    .Take(Size)
                    .ToListAsync();

                if (Users is null || !Users.Any())
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Nenhum usuário foi encontrado.";
                    return Response;
                }

                Response.Content = Users;
                Response.Status = ResponseStatusEnum.Success;
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<ResponseModel<List<UserEntity>>> GetAllUsersInactiveAdminAsync(int Size)
        {
            
            ResponseModel<List<UserEntity>> Response = new ResponseModel<List<UserEntity>>();
            try
            {
                var Users = await _dbContext.Users
                    .Where(u => u.IsDeleted == true)
                    .Include(x => x.Skills)
                        .ThenInclude(x => x.Skill)
                    .Include(x => x.OwnedProjects)
                    .Take(Size)
                    .ToListAsync();

                if (Users is null || !Users.Any())
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Nenhum usuário inativo foi encontrado.";
                    return Response;
                }

                Response.Content = Users;
                Response.Status = ResponseStatusEnum.Success;
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<ResponseModel<UserEntity>> GetUserByEmailAdminAsync(string Email)
        {
           
            ResponseModel<UserEntity> Response = new ResponseModel<UserEntity>();
            try
            {
                var User = await _dbContext.Users
                    .Include(x => x.Skills)
                        .ThenInclude(x => x.Skill)
                    .Include(x => x.OwnedProjects)
                        .ThenInclude(x=>x.Title)
                    .FirstOrDefaultAsync(u => u.Email == Email);

                if (User is null)
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Usuário não encontrado.";
                    return Response;
                }

                Response.Content = User;
                Response.Status = ResponseStatusEnum.Success;
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<SimpleResponseModel> ActivateUserAdminAsync(string Email)
        {
            SimpleResponseModel Response = new SimpleResponseModel();
            try
            {
                var User = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Email == Email);

                if (User is null)
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Usuário não encontrado.";
                    return Response;
                }

                var Result=User.SetAsActive();

                if (Result is false)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "O usuário ja está ativo.";
                    return Response;
                }

                _dbContext.Users.Update(User);
                await _dbContext.SaveChangesAsync();

                Response.Status = ResponseStatusEnum.Success;
                Response.Message = "Usuário ativado com sucesso.";
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }

        public async Task<SimpleResponseModel> InactiveUserAdminAsync(string Email)
        {
            
            SimpleResponseModel Response = new SimpleResponseModel();
           
            try
            {
                var User = await _dbContext.Users
                    .FirstOrDefaultAsync(u => u.Email == Email);

                if (User is null)
                {
                    Response.Status = ResponseStatusEnum.NotFound;
                    Response.Message = "Usuário não encontrado.";
                    return Response;
                }

                var Result = User.SetAsDeleted();

                if (Result is false)
                {
                    Response.Status = ResponseStatusEnum.Error;
                    Response.Message = "O usuário ja está inativo.";
                    return Response;
                }

                _dbContext.Users.Update(User);
                await _dbContext.SaveChangesAsync();

                Response.Status = ResponseStatusEnum.Success;
                Response.Message = "Usuário inativado com sucesso.";
                return Response;
            }
            catch (Exception ex)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return Response;
            }
        }
    }
}
