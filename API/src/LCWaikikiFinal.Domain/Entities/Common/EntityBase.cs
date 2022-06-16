namespace LCWaikikiFinal.Domain.Entities
{
        public abstract class EntityBase
        {
                public int Id { get; set; }
                public DateTime CreatedDate { get; set; }
                public DateTime? LastModifiedDate { get; set; }
        }
}
