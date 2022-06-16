namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsByUserQueryResponse
        {
                public int Id { get; set; }
                public string Name { get; set; }
                public decimal Price { get; set; }
                public bool IsOfferable { get; set; }
                public bool IsSold { get; set; }
                public int AppUserId { get; set; }
        }
}
