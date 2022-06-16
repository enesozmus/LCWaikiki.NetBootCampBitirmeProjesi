using System.ComponentModel.DataAnnotations;

namespace LCWaikikiFinal.UI.Models
{
        public class CreateOfferViewModel
        {
                [Required(ErrorMessage = "Teklif işlemi için fiyat bilgisi gereklidir!")]
                public int OfferPrice { get; set; }
                public int ProductId { get; set; }
                public int AppUserId { get; set; }
        }
}
