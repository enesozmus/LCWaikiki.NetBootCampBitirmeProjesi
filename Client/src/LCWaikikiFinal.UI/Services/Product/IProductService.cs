using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.Services
{
        public interface IProductService
        {
                Task<IReadOnlyList<GetProductsViewModel>> GetProductsAsync();
        }
}
