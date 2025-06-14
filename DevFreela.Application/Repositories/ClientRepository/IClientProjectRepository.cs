using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Repositories.ClientRepository
{
    public interface IClientProjectRepository
    {

        //Querys
        Task<ResponseModel<List<ProjectDTO>>> GetPurchasedProjectsClientAsync(int IdUser, string search, int Size);

        //Commands
        Task<SimpleResponseModel> BuyProjectClientAsync(int IdUser, int IdProject);
        Task<SimpleResponseModel> MakePaymentClientAsync(int IdUser, int IdProject);
        Task<SimpleResponseModel> CancelPurchaseClientAsync(int IdUser, int IdProject);
    }
}
