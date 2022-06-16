using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.Services
{
        public interface IColorService
        {
                Task<IReadOnlyList<GetColorsViewModel>> GetColorsAsync();
        }
}
