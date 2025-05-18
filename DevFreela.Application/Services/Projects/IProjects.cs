using DevFreela.Application.Models;


namespace DevFreela.Application.Services.Projects
{
    public interface IProjects
    {

        //public Task<ResponseModel<CreateProjectModel>> PostProject();

        public Task<ResponseModel<CreateProjectModel>> GetSearch(string Search);

        public Task<ResponseModel<CreateProjectModel>> GetById(int Id);

        public Task<ResponseModel<UpdateProjectModel>> Put(int Id, UpdateProjectModel Model);

        //public Task<ResponseModel<CreateProjectInputModel>> Delete(int Id);

        public Task<ResponseModel<CreateProjectModel>> Start(int Id);

        public Task<ResponseModel<CreateProjectModel>> Complete(int Id);

        //public Task<ResponseModel<CreateCommentModel>> PostComment();


    }
}
