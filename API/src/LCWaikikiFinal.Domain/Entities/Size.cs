namespace LCWaikikiFinal.Domain.Entities
{
        public class Size : EntityBase
        {
                public string Name { get; set; }
                public ICollection<Product> Products { get; set; }
        }
}
