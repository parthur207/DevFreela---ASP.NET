using DevFreela.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.Services.Projects
{
    public class ProjectService : IProjects
    {

        private readonly MyDbContext _dbContext;

        public ProjectsService(MyDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        private readonly FreeLancerTotalCostConfig _values;

        public ProjectService(IOptions<FreeLancerTotalCostConfig> Config)
        {
            _values = Config.Value;
        }


        public async Task<ResponseModel<CreateProjectInputModel>> Delete(int Id)
        {
            ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>();

            try
            {

                var ModelDelete=  await GetById(Id);  
                await _dbContext.Projects.Remove(Id);
                Resposta.Message = "Projeto deletado com sucesso!"; 
                return Resposta;

            }
            catch (Exception ex)
            {

                Resposta.Message= $"Ocorreu um erro ao deletar o projeto: {ex.Message}";
                return Resposta;
            }

        }

        public async Task<ResponseModel<CreateProjectInputModel>> GetById(int Id)
        {
            
            ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>(); 

            try { 

                var Model= _dbContext.Projects.Find(Id);    
                Resposta.Content = Model;
                return Resposta;

            }
            catch (Exception ex)
            {
                Resposta.Message = $"Erro ao buscar projeto: {ex.Message}";
                Resposta.status = false;
                return Resposta;
            }
        }

        public async Task<ResponseModel<List<CreateProjectInputModel>>> GetSearch(string Search)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<CreateCommentInputModel>> PostComment(int Id, string Comment)
        {
            
        }

        public async Task<ResponseModel<CreateProjectInputModel>> PostProject(CreateProjectInputModel Model)
        {
            ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>();

            try
            {
                await _dbContext.Projects.Add(Model); 
                _dbContext.SaveChanges();

                Resposta.Message = "Projeto criado com sucesso!";

                return Resposta;
            }
            catch (Exception ex)
            {
                Resposta.Message= $"Erro ao criar projeto:  + {ex.Message}";
                Resposta.status = false;
                return Resposta;
            }
        }

        public async Task<ResponseModel<UpdateProjectInputModel>> Put(int Id, UpdateProjectInputModel Model)
        {
            ResponseModel <UpdateProjectInputModel> Resposta = new ResponseModel<UpdateProjectInputModel>();

            Model.IdProject = Id;

            if (Model.TotalCost < _values.Minimum || Model.TotalCost > _values.Maximum)
            {
                Resposta.Message= $"O valor total do projeto deve estar entre {_values.Minimum} e {_values.Maximum}";
                Resposta.status = false;

                return Resposta;
            }

            await _dbContext.Projects.Update(Model);    
            Resposta.Message= "Projeto atualizado com sucesso!";
            return Resposta;
        }

        public async Task<ResponseModel<CreateProjectInputModel>> Start(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<CreateProjectInputModel>> Complete(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
