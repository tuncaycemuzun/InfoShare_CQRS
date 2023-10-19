namespace InfoShare_CQRS.Data.Entities
{
    public class Product
    {
        public Guid Id { get; set; }
        public Guid BrandId { get; set; }
        public Brand Brand { get; set; }
        public required string Name { get; set; }
        public required decimal Price { get; set; }
    }
}
