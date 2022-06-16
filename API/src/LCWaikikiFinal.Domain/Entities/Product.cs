using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LCWaikikiFinal.Domain.Entities
{
        public class Product : EntityBase
        {
                public string Name { get; set; }
                public decimal Price { get; set; }
                public bool IsOfferable { get; set; }
                public bool IsSold { get; set; }
                public int AmountOfStock { get; set; }
                public string ImageUrl { get; set; }
                [NotMapped]
                [Display(Name = "Image")]
                public IFormFile Image { get; set; }
                public ProductDetail ProductDetail { get; set; }
                public int CategoryId { get; set; }
                public Category Category { get; set; }
                public int? BrandId { get; set; }
                public Brand Brand { get; set; }
                public int? ColorId { get; set; }
                public Color Color { get; set; }
                public int SizeId { get; set; }
                public Size Size { get; set; }
                public int LifecycleId { get; set; }
                public Lifecycle Lifecycle { get; set; }
                public int AppUserId { get; set; }
                public AppUser AppUser { get; set; }
                public ICollection<Offer> Offers { get; set; }
        }
}
