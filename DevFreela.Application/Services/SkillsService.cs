using DevFreela.Application.Interfaces;
using DevFreela.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace DevFreela.Application.Services
{
    public class SkillsService : ISkillInterface
    {

        private readonly DbContext _dbContext;
        public SkillsService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ResponseModel<List<(int Id, string Description)>>> GetAllSkillsAsync()
        {
            ResponseModel<List<(int, string)>> response= new ResponseModel<List<(int, string)>>();

            try
            {
                var skills = await _dbContext.Skills.
                    Where(s => s.IsActive)
                    .AsNoTracking()
                    .Select(s => (s.Id, s.Description))
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Message = ex.Message;
                return response;
            }
        }

        public Task<SimpleResponseModel> InsetSkill(CreateSkillModel Model)
        {
            throw new NotImplementedException();
        }
    }
}
