using DevFreela.Application.DTOs.AdminFreelancerDTOs;
using DevFreela.Application.Mappers;
using DevFreela.Application.Repositories.GenericRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.RepositoriesServices.GenericRepository
{
    internal class SkillGenericRepositoryService : ISkillGenericRepository
    {

        private readonly DevFreelaDbContext _dbContext;
        public SkillGenericRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SimpleResponseModel> CreateSkillAsync(SkillEntity Entity)
        {
            
            SimpleResponseModel response = new SimpleResponseModel();

            try
            {
                if (string.IsNullOrWhiteSpace(Entity.Description))
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "A skill não pode ser nula.";
                    return response;
                }

                if (await _dbContext.Skills.AllAsync(x=>x.Description == Entity.Description))
                {

                    response.Status=ResponseStatusEnum.Error;
                    response.Message = "A skill informada já existe.";
                    return response;
                }

                await _dbContext.Skills.AddAsync(Entity);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Skill criada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }

        public async Task<ResponseModel<List<SkillEntity>>> GetAllSkillsAsync()
        {   
            ResponseModel<List<SkillEntity>> response = new ResponseModel<List<SkillEntity>>();
            try
            {
                var skills = await _dbContext.Skills.ToListAsync();

                if (skills is null || !skills.Any())
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "Nenhuma skill encontrada.";
                    return response;
                }

                response.Content = skills;
                response.Status = ResponseStatusEnum.Success;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = $"Ocorreu um erro inesperado: {ex.Message}";
                return response;
            }
        }
    }
}
