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

        public async Task<SimpleResponseModel> CreateSkillAsync(SkillEntity entity)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                if (entity is null)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "A nova habilidade não pode ser nula.";
                    return response;
                }

                await _dbContext.Skills.AddAsync(entity);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Habilidade criada com sucesso.";
                return response;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
                response.Status = ResponseStatusEnum.Error;
                return response;
            }
        }

        public async Task<ResponseModel<List<SkillDTO>>> GetAllSkillsAsync()
        {
            ResponseModel<List<SkillDTO>> response = new ResponseModel<List<SkillDTO>>();
            try
            {
                var skills = await _dbContext.Skills
                    .ToListAsync();

                if (skills is null || skills.Count == 0)
                {
                    response.Status = ResponseStatusEnum.Error;
                    response.Message = "Nenhuma habilidade foi encontrada.";
                    return response;
                }

                response.Status = ResponseStatusEnum.Success;
                response.Content = SkillMapper.ToListSkillDTO(skills);
                return response;
            }
            catch (Exception ex)
            {
                response.Status = ResponseStatusEnum.Error;
                response.Message = ex.Message;
                return response;
            }
        }
    }
}
