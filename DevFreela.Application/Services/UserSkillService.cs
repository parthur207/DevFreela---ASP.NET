using DevFreela.Application.Interfaces;
using DevFreela.Application.Mappers;
using DevFreela.Application.Models;
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
    public class UserSkillService : IUserSkillInterface
    {
        private readonly DevFreelaDbContext _dbContext;
        public UserSkillService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SimpleResponseModel> CreateUserSkillAsync(UserSkillModel Model)
        {
            var response = new SimpleResponseModel();

            try
            {
                if (!await _dbContext.Users.AnyAsync(x => x.Id == Model.UserId))
                {
                    response.Status = false;
                    response.Message = "Usuário não encontrado.";
                    return response;
                }

                if (Model.SkillsIds == null || !Model.SkillsIds.Any())
                {
                    response.Status = false;
                    response.Message = "Erro. Informe pelo menos uma habilidade a ser adicionada.";
                    return response;
                }

                var notFoundSkills = new List<int>();

                foreach (var skillId in Model.SkillsIds)
                {
                    var skillExists = await _dbContext.Skills.AnyAsync(x => x.Id == skillId);

                    if (!skillExists)
                    {
                        notFoundSkills.Add(skillId);
                        continue;
                    }

                    var userSkill = UserSkillMapper.ToUserSkillEntity(Model.UserId, skillId);
                    await _dbContext.UserSkills.AddAsync(userSkill);
                }

                await _dbContext.SaveChangesAsync();

                if (notFoundSkills.Any())
                {
                    response.Status = true;
                    response.Message = $"Algumas habilidades foram adicionadas com sucesso. Não encontradas: {string.Join(", ", notFoundSkills)}.";
                }
                else
                {
                    response.Status = true;
                    response.Message = "Todas as habilidades foram adicionadas com sucesso.";
                }

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = $"Erro ao adicionar habilidades: {ex.Message}";
                return response;
            }
        }
    }
}
