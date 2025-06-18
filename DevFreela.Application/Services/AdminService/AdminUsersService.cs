using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Mappers;
using DevFreela.Application.Repositories.AdminRepository;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;

namespace DevFreela.Application.Services.AdminService
{
    internal class AdminUsersService : IAdminUsersInterface
    {
        private readonly IAdminUsersRepository _adminUsersRepository;
        public AdminUsersService(IAdminUsersRepository adminUsersRepository)
        {
            _adminUsersRepository = adminUsersRepository;
        }

        public async Task<ResponseModel<List<GenericUserDTO>>> GetAllClientsAdmin(int Size)
        {
            
            ResponseModel<List<GenericUserDTO>> response = new ResponseModel<List<GenericUserDTO>>();

            var ResponseRepository = await _adminUsersRepository.GetAllClientsAdminAsync(Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            foreach (var u in ResponseRepository.Content)
            {
                var userMapped = UserMapper.ToUserGenericDTO(u);
                response.Content.Add(userMapped);
            }

            response.Status = ResponseStatusEnum.Success;
            return response;
        }

        public async Task<ResponseModel<List<GenericUserDTO>>> GetAllFreelancersAdmin(int Size)
        { 
            ResponseModel<List<GenericUserDTO>> response = new ResponseModel<List<GenericUserDTO>>();

            var ResponseRepository = await _adminUsersRepository.GetAllFreelancersAdminAsync(Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            foreach (var u in ResponseRepository.Content)
            {
                var userMapped = UserMapper.ToUserGenericDTO(u);
                response.Content.Add(userMapped);
            }

            response.Status = ResponseStatusEnum.Success;
            return response;
        }

        public async Task<ResponseModel<List<GenericUserDTO>>> GetAllUsersAdmin(int Size)
        {
            
            ResponseModel<List<GenericUserDTO>> response = new ResponseModel<List<GenericUserDTO>>();

            var ResponseRepository = await _adminUsersRepository.GetAllUsersAdminAsync(Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            foreach (var u in ResponseRepository.Content)
            {
                var userMapped = UserMapper.ToUserGenericDTO(u);
                response.Content.Add(userMapped);
            }

            response.Status = ResponseStatusEnum.Success;
            return response;
        }

        public async Task<ResponseModel<List<GenericUserDTO>>> GetAllUsersInactiveAdmin(int Size)
        {
            
            ResponseModel<List<GenericUserDTO>> response = new ResponseModel<List<GenericUserDTO>>();

            var ResponseRepository = await _adminUsersRepository.GetAllUsersInactiveAdminAsync(Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            foreach (var u in ResponseRepository.Content)
            {
                var userMapped = UserMapper.ToUserGenericDTO(u);
                response.Content.Add(userMapped);
            }

            response.Status = ResponseStatusEnum.Success;
            return response;
        }

        public async Task<ResponseModel<GenericUserDTO>> GetUserByEmailAdmin(string Email)
        {
           
            ResponseModel<GenericUserDTO> response = new ResponseModel<GenericUserDTO>();

            var ResponseRepository = await _adminUsersRepository.GetUserByEmailAdminAsync(Email);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            var userMapped = UserMapper.ToUserGenericDTO(ResponseRepository.Content);
            response.Content = userMapped;
            response.Status = ResponseStatusEnum.Success;
            return response;
        }

        public async Task<SimpleResponseModel> ActivateUserAdmin(string Email)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();

            var ResponseRepository = await _adminUsersRepository.ActivateUserAdminAsync(Email);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            response.Status = ResponseStatusEnum.Success;
            return response;
        }

        public async Task<SimpleResponseModel> InactiveUserAdmin(string Email)
        {
            SimpleResponseModel response = new SimpleResponseModel();

            var ResponseRepository = await _adminUsersRepository.InactiveUserAdminAsync(Email);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                response.Status = ResponseRepository.Status;
                response.Message = ResponseRepository.Message;
                return response;
            }

            response.Status = ResponseStatusEnum.Success;
            return response;
        }
    }
}
