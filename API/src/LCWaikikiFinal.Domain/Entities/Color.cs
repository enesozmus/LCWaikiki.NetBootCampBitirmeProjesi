namespace LCWaikikiFinal.Domain.Entities
{
        public class Color : EntityBase
        {
                public string Name { get; set; }
                public ICollection<Product> Products { get; set; }
        }
}
