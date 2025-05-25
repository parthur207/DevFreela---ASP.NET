using DevFreela.Application.DTOs;
using DevFreela.Application.Models;
using DevFreela.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces
{
    public interface IUserInterface
    {
        Task<ResponseModel<List<UserDTO>>> GetAllUsersAsync();
        Task<ResponseModel<UserDTO>> GetByEmailAsync(string email);
        Task<SimpleResponseModel> InsertUser(CreateUserModel userModel);
    }
}
