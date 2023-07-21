namespace Entities.Dtos.Product
{
    public record ProductDtoForUpdate : ProductDto
    {
        public bool ShowCase { get; set; }
    }
}
