namespace OnlineShop.Data.Tables
{
    public class Category : BaseTable
    {
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}