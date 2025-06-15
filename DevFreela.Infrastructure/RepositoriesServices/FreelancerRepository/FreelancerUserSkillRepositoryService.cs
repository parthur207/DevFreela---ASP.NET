using DevFreela.Application.Repositories.FreelancerRepository;
using DevFreela.Domain.Entities;
using DevFreela.Domain.Enums;
using DevFreela.Domain.Models.Creations;
using DevFreela.Domain.Models.ResponsePattern;
using DevFreela.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.RepositoriesServices.FreelancerRepository
{
    internal class FreelancerUserSkillRepositoryService : IFreelancerUserSkillRepository
    {

        private readonly DevFreelaDbContext _dbContext;

        public FreelancerUserSkillRepositoryService(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SimpleResponseModel> CreateUserSkillAsync(int UserId, UserSkillEntity Entity)
        {

            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var hasSkill = await _dbContext.UserSkills.AnyAsync(x => x.IdUser == UserId && x.Skill.Description == Entity.Skill.Description);

                if (!await _dbContext.Users.AnyAsync(x => x.Id == UserId))
                {
                    response.Status = ResponseStatusEnum.NotFound;
                    response.Message = "O usuário não existe.";
                    return response;
                }

                if (hasSkill is true)
                {
                    response.Message = "O usuário em questão ja possui a habilidade informada.";
                    response.Status = ResponseStatusEnum.Error;
                    return response;
                }

                await _dbContext.UserSkills.AddAsync(Entity);
                await _dbContext.SaveChangesAsync();

                response.Status = ResponseStatusEnum.Success;
                response.Message = "Habilidade cadastrada com sucesso.";
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

