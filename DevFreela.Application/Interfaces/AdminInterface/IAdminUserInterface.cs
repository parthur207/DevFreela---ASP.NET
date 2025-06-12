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
    public interface IAdminUserInterface
    {
        Task<ResponseModel<List<UserDTO>>> GetAllUsersAsync();
        Task<ResponseModel<UserDTO>> GetByEmailAsync(string email);
    }
}
