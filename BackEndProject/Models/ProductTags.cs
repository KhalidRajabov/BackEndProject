namespace BackEndProject.Models
{
    public class ProductTags
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }

        public Product Product { get; set; }
        public Tag Tags { get; set; }
    }
}
