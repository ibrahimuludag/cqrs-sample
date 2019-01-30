namespace CqrsSample.Data.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }

        public byte[] RowVersion { get; set; }
    }
}