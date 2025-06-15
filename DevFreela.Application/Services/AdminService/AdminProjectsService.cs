using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Application.Interfaces.AdminInterface;
using DevFreela.Application.Mappers;
using DevFreela.Application.Repositories.AdminRepository;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.PatternResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.AdminService
{
    internal class AdminProjectsService : IAdminProjectsInterface
    {

        private readonly IAdminProjectRepository _adminProjectsRepository;
        public AdminProjectsService(IAdminProjectRepository adminProjectsRepository)
        {
            _adminProjectsRepository = adminProjectsRepository;
        }

        public async Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByClientAdmin(string EmailClient)
        {
            ResponseModel<List<AdminFreelancerProjectDTO>> Response = new ResponseModel<List<AdminFreelancerProjectDTO>>();

            var ResponseRepository = await _adminProjectsRepository.GetAllProjectsByClientAdminAsync(EmailClient);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }

            foreach (var p in ResponseRepository.Content)
            {
                var projectMapped = ProjectMapper.ToAdminFreelancerProjectDTO(p);
                Response.Content.Add(projectMapped);
            }

            if (Response.Content is null)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = "Erro. Falha no mapeamento.";
                return Response;
            } 

            Response.Status = ResponseStatusEnum.Success;
            return Response;
        }

        public async Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByFreelancerAdmin(string EmailFreelancer)
        {
            
            ResponseModel<List<AdminFreelancerProjectDTO>> Response = new ResponseModel<List<AdminFreelancerProjectDTO>>();

            var ResponseRepository = await _adminProjectsRepository.GetAllProjectsByFreelancerAdminAsync(EmailFreelancer);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }

            foreach (var p in ResponseRepository.Content)
            {
                var projectMapped = ProjectMapper.ToAdminFreelancerProjectDTO(p);
                Response.Content.Add(projectMapped);
            }

            if (Response.Content is null)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = "Erro. Falha no mapeamento.";
                return Response;
            } 

            Response.Status = ResponseStatusEnum.Success;
            return Response;
        }

        public async Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetAllProjectsByStatusAdmin(ProjectStatusEnum status, int Size)
        {
            
            ResponseModel<List<AdminFreelancerProjectDTO>> Response = new ResponseModel<List<AdminFreelancerProjectDTO>>();

            var ResponseRepository = await _adminProjectsRepository.GetAllProjectsByStatusAdminAsync(status, Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }

            foreach (var p in ResponseRepository.Content)
            {
                var projectMapped = ProjectMapper.ToAdminFreelancerProjectDTO(p);
                Response.Content.Add(projectMapped);
            }

            if (Response.Content is null)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = "Erro. Falha no mapeamento.";
                return Response;
            } 

            Response.Status = ResponseStatusEnum.Success;
            return Response;
        }

        public async Task<ResponseModel<List<AdminFreelancerProjectDTO>>> GetSearchAdmin(string Search, int Size)
        {
            
            ResponseModel<List<AdminFreelancerProjectDTO>> Response = new ResponseModel<List<AdminFreelancerProjectDTO>>();

            var ResponseRepository = await _adminProjectsRepository.GetSearchAdminAsync(Search, Size);

            if (ResponseRepository.Status != ResponseStatusEnum.Success)
            {
                Response.Status = ResponseRepository.Status;
                Response.Message = ResponseRepository.Message;
                return Response;
            }

            foreach (var p in ResponseRepository.Content)
            {
                var projectMapped = ProjectMapper.ToAdminFreelancerProjectDTO(p);
                Response.Content.Add(projectMapped);
            }

            if (Response.Content is null)
            {
                Response.Status = ResponseStatusEnum.Error;
                Response.Message = "Erro. Falha no mapeamento.";
                return Response;
            } 

            Response.Status = ResponseStatusEnum.Success;
            return Response;
        }
    }
}
