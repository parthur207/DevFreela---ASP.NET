using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.ClientInterface;
using DevFreela.Application.Mappers;
using DevFreela.Application.Repositories.ClientRepository;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.ClientService
{
    internal class ClientProjectsService : IClientProjectsInterface
    {

        private readonly IClientProjectRepository _clientProjectRepository;
        public ClientProjectsService(IClientProjectRepository clientProjectRepository)
        {
            _clientProjectRepository = clientProjectRepository;
        }

        public async Task<ResponseModel<List<GenericProjectDTO>>> GetPurchasedProjectsClient(int IdUser, string search, int Size)
        {

            ResponseModel<List<GenericProjectDTO>> Response = new ResponseModel<List<GenericProjectDTO>>();

            var ResponseRepository = await _clientProjectRepository.GetPurchasedProjectsClientAsync(IdUser, search, Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }

            foreach (var p in ResponseRepository.Content)
            {
                var projectMapped = ProjectMapper.ToGenericProjectDTO(p);
                Response.Content.Add(projectMapped);
            }

            Response.Status = ResponseStatusEnum.Success;
            return Response;
        }

        public async Task<SimpleResponseModel> BuyProjectClient(int IdUser, int IdProject)
        {
            SimpleResponseModel Response = new SimpleResponseModel();

            var  ResponseRepository= await _clientProjectRepository.BuyProjectClientAsync(IdUser, IdProject);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }
            Response.Status = ResponseStatusEnum.Success;
            Response.Message = ResponseRepository.Message;
            return Response;
        }

        public async Task<SimpleResponseModel> CancelPurchaseClient(int IdUser, int IdProject)
        {  
            SimpleResponseModel Response = new SimpleResponseModel();
            
            var ResponseRepository = await _clientProjectRepository.CancelPurchaseClientAsync(IdUser, IdProject);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }
            Response.Status = ResponseStatusEnum.Success;
            Response.Message = ResponseRepository.Message;
            return Response;
        }

      

        public async Task<SimpleResponseModel> MakePaymentClient(int IdUser, int IdProject)
        {
            throw new NotImplementedException();
        }
    }
}
