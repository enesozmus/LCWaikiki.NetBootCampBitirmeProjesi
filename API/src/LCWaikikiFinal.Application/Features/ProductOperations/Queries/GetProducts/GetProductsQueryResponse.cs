namespace LCWaikikiFinal.Application.Features.ProductOperations.Queries
{
        public class GetProductsQueryResponse
        {
                public int Id { get; set; }
                public string Username { get; set; }
                public string Name { get; set; }
                public string ImageUrl { get; set; }
                public decimal Price { get; set; }
                public string Brand { get; set; }
                public string Color { get; set; }
                public string Status { get; set; }
                public string Size { get; set; }
                public bool IsOfferable { get; set; }
                public bool IsSold { get; set; }
                public int AmountOfStock { get; set; }
                public DateTime CreatedDate { get; set; }
        }
}
