using DevFreela.Application.Repositories.FreelancerRepository;
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

        public async Task<SimpleResponseModel> CreateUserSkillAsync(int UserId, CreateUserSkillModel model)
        {
            SimpleResponseModel response = new SimpleResponseModel();
            try
            {
                var FreelanceEntity = await _dbContext.Users.FirstOrDefaultAsync(x=>x.Id==UserId);
                await _dbContext.FreelanceEntity.AddAsync(userSkill);
                await _dbContext.SaveChangesAsync();
                response.Status = true;
                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return
            }
        }
    }
}
