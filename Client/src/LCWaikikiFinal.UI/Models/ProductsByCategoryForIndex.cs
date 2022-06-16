namespace LCWaikikiFinal.UI.Models
{
        public class ProductsByCategoryForIndex
        {
                public IReadOnlyList<GetCategoriesViewModel> CategoryItems { get; set; }
                public IReadOnlyList<GetProductsViewModel> ProductItems { get; set; }
        }
}
