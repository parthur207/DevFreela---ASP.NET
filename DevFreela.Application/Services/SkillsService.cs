using DevFreela.Application.DTOs;
using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Domain.Models;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DevFreela.Application.Services
{
    public class SkillsService : ISkillInterface
    {

        private readonly DevFreelaDbContext _dbContext;
        public SkillsService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<List<SkillDTO>>> GetAllSkillsAsync()
        {
            ResponseModel<List<SkillDTO>> response= new ResponseModel<List<SkillDTO>>();
           
            try
            {
                var skills = await _dbContext.Skills
                    .ToListAsync();

                if (skills is null || skills.Count == 0)
                {
                    response.Status = false;
                    response.Message = "Nenhuma habilidade foi encontrada.";
                    return response;
                }

                response.Status = true;
                response.Content = SkillMapper.ToListSkillDTO(skills);
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public async Task<SimpleResponseModel> InsertSkill(CreateSkillModel Model)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                if (Model is null)
                {
                    response.Status = false;
                    response.Message = "A nova habilidade não pode ser nula.";
                    return response;
                }

                var SkillMapped = SkillMapper.ToSkillEntity(Model);

                await _dbContext.AddAsync(SkillMapped);
                await _dbContext.SaveChangesAsync();

                response.Status = true;
                response.Message = "Habilidade criada com sucesso.";
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
