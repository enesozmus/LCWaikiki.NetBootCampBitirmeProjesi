using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.Services
{
        public interface IBrandService
        {
                Task<IReadOnlyList<GetBrandsViewModel>> GetBrandsAsync();
        }
}
