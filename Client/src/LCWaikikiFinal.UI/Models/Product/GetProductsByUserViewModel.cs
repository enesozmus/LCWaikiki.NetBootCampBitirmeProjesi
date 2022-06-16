namespace LCWaikikiFinal.UI.Models
{
        public class GetProductsByUserViewModel
        {
                public int Id { get; set; }
                public string Name { get; set; }
                public decimal Price { get; set; }
                public bool IsOfferable { get; set; }
                public bool IsSold { get; set; }
                public int AppUserId { get; set; }
        }
}
