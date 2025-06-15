using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;

namespace DevFreela.Application.Services
{
    public class UserService : IAdminUsersInterface
    {
        private readonly DevFreelaDbContext _dbContext;//Alterar para injeção de dependecia repository
        public UserService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ResponseModel<List<UserDTO>>> GetAllUsersAsync()
        {
            ResponseModel<List<UserDTO>> response = new ResponseModel<List<UserDTO>> { Content = new List<UserDTO>() };

            try
            {
                var users = await _dbContext.Users.Include(x=>x.Skills).ThenInclude(x=>x.Skill)
                    .ToListAsync();

                if (users is null || !users.Any())
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
                var user = await _dbContext.Users.Include(x=>x.Skills).ThenInclude(x=>x.Skill)
                    .SingleOrDefaultAsync(x => x.Email == email);

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

        public async Task<SimpleResponseModel> CreateUserAsync(CreateUserModel userModel)
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
