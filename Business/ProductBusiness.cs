using BusinessInterface;
using Entities;
using EntitiesViewModels;
using IRepository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepo productRepo;
        public ProductBusiness(IProductRepo productRepo)
        {
            this.productRepo = productRepo;
        }

        public async Task<Response> AddProducts(Products e)
        {
            Response response = new Response();
            try
            {
                response.returnId = -1;
                response.returnCode = "CODE_SUCCESSFULLY_COMPLETED";
                response.returnStatus = "SUCESSFULL";
                response.returnText = "Add-Items";
                response.returnException = "";
                response.returnObject = await productRepo.AddProducts(e);
            }
            catch (Exception ex)
            {
                string req = "JSON Request: Add Items";

                response.returnId = -1;
                response.returnCode = "0";
                response.returnStatus = "Error";
                response.returnText = ex.Message.ToString();
                response.returnException = ex.InnerException == null ? req + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString() : req + Environment.NewLine + Environment.NewLine + "Inner Exception: " + ex.InnerException.ToString() + Environment.NewLine + Environment.NewLine + "Message: " + ex.Message.ToString() + Environment.NewLine + Environment.NewLine + "Stack Trace: " + ex.StackTrace.ToString();
                response.returnObject = null;
            }
            return response;
        }

        public void deleteProducts(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Response>> EditProducts(Products e)
        {
            throw new NotImplementedException();
        }

        public Task<Response> GetIdByProducts(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Response>> ListProducts()
        {
            throw new NotImplementedException();
        }
    }
}