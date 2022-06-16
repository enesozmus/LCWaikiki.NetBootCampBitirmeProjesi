namespace LCWaikikiFinal.Domain.Entities
{
        public class Lifecycle : EntityBase
        {
                public string Description { get; set; }
                public ICollection<Product> Products { get; set; }
        }
}
