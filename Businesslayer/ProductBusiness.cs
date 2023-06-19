using Entities;
using EntitiesViewModels;
using IBusiness;
using IRepository;

namespace Businesslayer
{
    public class ProductBusiness : IProductbusiness
    {
        private readonly IProductRepo _product;
        public ProductBusiness(IProductRepo _product)
        {
            this._product = _product;
        }

        public async Task<Response> AddProducts(Products e)
        {
            Response response = new Response();
            try
            {
                response.returnId = 1;
                response.returnCode = "ConstantsValues.CODE_SUCCESSFULLY_COMPLETED";
                response.returnStatus = "Common.ConstantsValues.SUCESSFULL";
                response.returnText = "Add-Items";
                response.returnException = "";
                response.returnObject = await _product.AddProducts(e);
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
            _product.deleteProducts(id);  
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