using DevFreela.Application.DTOs.GenericDTOs;
using DevFreela.Domain.Models.PatternResult;
using DevFreela.Domain.Models.ResponsePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Interfaces.ClientInterface
{
    public interface IClientProjectsInterface
    {

        //Querys
        Task<ResponseModel<List<GenericProjectDTO>>> GetPurchasedProjectsClient(int IdUser,  string search, int Size);

        //Commands
        Task<SimpleResponseModel> BuyProjectClient(int IdUser, int IdProject);
        Task<SimpleResponseModel> MakePaymentClient(int IdUser, int IdProject);
        Task<SimpleResponseModel> CancelPurchaseClient(int IdUser, int IdProject);

    }
}
