namespace LCWaikikiFinal.Domain.Entities
{
        public class Offer : EntityBase
        {
                public int OfferPrice { get; set; }
                public bool IsAccepted { get; set; }
                public int ProductId { get; set; }
                public Product Product { get; set; }
                public int AppUserId { get; set; }
                public AppUser AppUser { get; set; }
        }
}
