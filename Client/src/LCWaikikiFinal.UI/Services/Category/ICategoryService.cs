using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.Services
{
        public interface ICategoryService
        {
                Task<IReadOnlyList<GetCategoriesViewModel>> GetCategoriesAsync();
        }
}
