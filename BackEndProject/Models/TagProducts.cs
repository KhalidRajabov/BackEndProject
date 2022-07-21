namespace BackEndProject.Models
{
    public class TagProducts
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int TagId { get; set; }

        public Product Product { get; set; }
        public Tags Tags { get; set; }
    }
}
