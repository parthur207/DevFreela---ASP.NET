using DevFreela.Application.DTOs;
using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services
{
    public class UserService : IUserInterface
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<UserDTO>>> GetAllUsersAsync()
        {
            ResponseModel<List<UserDTO>> response = new ResponseModel<List<UserDTO>>();

            try
            {
                var users = await _dbContext.Users
                    .ToListAsync();

                if (users is null || users.Count == 0)
                {
                    response.Status = false;
                    response.Message = "Nenhum usuário foi encontrado.";
                    return response;
                }

                foreach (var u in users)
                {
                    var userMapped = UserMapper.ToUserDTO(u);
                    response.Content.Add(userMapped);
                }
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<ResponseModel<UserDTO>> GetByEmailAsync(string email)
        {
            ResponseModel<UserDTO> response = new ResponseModel<UserDTO>();

            try
            {
                var user = _dbContext.Users
                    .SingleOrDefault(x => x.Email == email);

                if (user is null)
                {
                    response.Status = false;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                var userMapped = UserMapper.ToUserDTO(user);

                response.Content = userMapped;
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> InsertUser(CreateUserModel userModel)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                if (userModel is null)
                {
                    response.Status = false;
                    response.Message = "O usuário não pode ser nulo.";
                    return response;
                }
                var userMapped = UserMapper.ToUserEntity(userModel);
                await _dbContext.Users.AddAsync(userMapped);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "Usuário criado com sucesso.";

                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
