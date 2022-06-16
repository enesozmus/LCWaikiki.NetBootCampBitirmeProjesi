namespace LCWaikikiFinal.UI.Models
{
        public class GetOffersByUserViewModel
        {
                public int Id { get; set; }
                public int OfferPrice { get; set; }
                public string ProductName { get; set; }
                public DateTime CreatedDate { get; set; }
                public int AppUserId { get; set; }
        }
}
