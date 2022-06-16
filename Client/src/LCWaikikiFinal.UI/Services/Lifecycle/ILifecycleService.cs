using LCWaikikiFinal.UI.Models;

namespace LCWaikikiFinal.UI.Services
{
        public interface ILifecycleService
        {
                Task<IReadOnlyList<GetLifecyclesViewModel>> GetLifecyclesAsync();
        }
}
