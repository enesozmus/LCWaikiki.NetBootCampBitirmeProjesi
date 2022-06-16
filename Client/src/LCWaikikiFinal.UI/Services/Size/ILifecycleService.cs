using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.Services
{
        public interface ISizeService
        {
                Task<IReadOnlyList<GetSizesViewModel>> GetSizesAsync();
        }
}
