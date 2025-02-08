using DevFreela.Models;
using DevFreela.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Runtime.CompilerServices;

namespace DevFreela.Services.Projects
{
    public class ProjectService : IProjects
    {

        //private readonly MyDbContext _dbContext;
        private readonly FreeLancerTotalCostConfig _values;

        private readonly DevFreelaDbContext _dbContext;

        public ProjectService(IOptions<FreeLancerTotalCostConfig> Config, DevFreelaDbContext DbContext) //MyDbContext DbContext)
        {
            _values = Config.Value;

            _dbContext = DbContext;
        }


        public async Task<ResponseModel<CreateProjectInputModel>> PostProject(CreateProjectInputModel model)
        {

            ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>();
            try
            {
                var newproject = model.ToProjectEntity();

                 _dbContext.Projects.Add(newproject);

                await _dbContext.SaveChangesAsync();

                Resposta.Message = "Projeto criado com sucesso!";
                return Resposta;
            }

            catch (Exception ex){
                Resposta.Message = "Erro ao criar projeto: " + ex.Message;
                Resposta.Status = false;
                return Resposta;
            }
        }

        public async Task<ResponseModel<CreateProjectInputModel>> DeleteProject(int Id)
        {
            ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>();

            try 
            { 
                var delete=await _dbContext.Projects.FindAsync(Id);
                 _dbContext.Projects.Remove(delete);
                await _dbContext.SaveChangesAsync();

                Resposta.Message = "Projeto deletado com sucesso.";
                return Resposta;
            }
            catch(Exception ex)
            {

                Resposta.Message = "Erro ao deletar projeto: " + ex.Message;
                Resposta.Status = false;
                return Resposta;
            }
        }

    /*public async Task<ResponseModel<CreateProjectInputModel>> PostProject(CreateProjectInputModel Model)
    {
        ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>();

        if (Model.TotalCost < _values.Minimum || Model.TotalCost > _values.Maximum)
        {
            Resposta.Message = $"O valor total do projeto deve estar entre {_values.Minimum} e {_values.Maximum}";
            Resposta.status = false;

            return Resposta;
        }
        try
        {
            await _dbContext.Projects.Add(Model);
            _dbContext.SaveChanges();

            Resposta.Message = "Projeto criado com sucesso!";

            return Resposta;
        }
        catch (Exception ex)
        {
            Resposta.Message = $"Erro ao criar projeto:  + {ex.Message}";
            Resposta.status = false;
            return Resposta;
        }
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

    }*/

    public async Task<ResponseModel<CreateProjectInputModel>> GetById(int Id)
    {

        ResponseModel<CreateProjectInputModel> Resposta = new ResponseModel<CreateProjectInputModel>();

        Id++;

        Resposta.Content = Id.ToString();

        return Resposta;
    }
          /*try { 

                var Model= _dbContext.Projects.Find(Id);    
                Resposta.Content = Model;
                return Resposta;

            }
            catch (Exception ex)
            {
                Resposta.Message = $"Erro ao buscar projeto: {ex.Message}";
                Resposta.status = false;
                return Resposta;
            }*/

      
        

        public async Task<ResponseModel<CreateProjectInputModel>> GetSearch(string Search)
        {
            ResponseModel<CreateProjectInputModel>  Resposta=new ResponseModel<CreateProjectInputModel>();

            if (!int.TryParse(Search,  out int search))
            {
                Resposta.Message= "O valor de busca deve ser um número inteiro";
                Resposta.Status = false;
                return Resposta;
            }
            search++;

            Resposta.Content = search.ToString();
            return Resposta;
        }


        public async Task<ResponseModel<UpdateProjectInputModel>> Put(int Id, UpdateProjectInputModel Model)
        {
            ResponseModel <UpdateProjectInputModel> Resposta = new ResponseModel<UpdateProjectInputModel>();

            Model.IdProject = Id;

            if (Model.TotalCost < _values.Minimum || Model.TotalCost > _values.Maximum)
            {
                Resposta.Message= $"O valor total do projeto deve estar entre {_values.Minimum} e {_values.Maximum}";
                Resposta.Status = false;

                return Resposta;
            }

            //await _dbContext.Projects.Update(Model);    
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

        public Task<ResponseModel<CreateCommentInputModel>> PostComment()
        {
            throw new NotImplementedException();
        }
    }
}