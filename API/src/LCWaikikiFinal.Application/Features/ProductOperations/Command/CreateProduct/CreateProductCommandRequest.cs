using MediatR;

namespace LCWaikikiFinal.Application.Features.ProductOperations.Command
{
        public class CreateProductCommandRequest : IRequest
        {
                public string Name { get; set; }
                public decimal Price { get; set; }
                public int SizeId { get; set; }
                public bool IsOfferable { get; set; }
                public bool IsSold { get; set; }
                public string ImageUrl { get; set; }
                public int AmountOfStock { get; set; }
                public int CategoryId { get; set; }
                public int? BrandId { get; set; }
                public int? ColorId { get; set; }
                public int LifecycleId { get; set; }
                public int AppUserId { get; set; }
        }
}
