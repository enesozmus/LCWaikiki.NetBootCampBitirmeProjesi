namespace LCWaikikiFinal.Domain.Entities
{
        public class ProductDetail : EntityBase
        {
                public string? ShortDescription { get; set; }
                public string? LongDescription { get; set; }
                public string? Fabric { get; set; }
                public string? Pattern { get; set; }
                public decimal? UnitWeight { get; set; }
                public int ProductId { get; set; }
                public Product Product { get; set; }
        }
}
