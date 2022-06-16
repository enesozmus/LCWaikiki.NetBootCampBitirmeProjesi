using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCWaikikiFinal.UI.Models
{
        public class CreateProductViewModel
        {
                public string Name { get; set; }
                public decimal Price { get; set; }
                public int SizeId { get; set; }
                public bool IsOfferable { get; set; }
                public bool IsSold { get; set; }
                public string? ImageUrl { get; set; }
                [NotMapped]
                [Display(Name = "Image")]
                public IFormFile Image { get; set; }
                public int AmountOfStock { get; set; }
                public int CategoryId { get; set; }
                public int? BrandId { get; set; }
                public int? ColorId { get; set; }
                public int LifecycleId { get; set; }
                public int AppUserId { get; set; }
        }
}
