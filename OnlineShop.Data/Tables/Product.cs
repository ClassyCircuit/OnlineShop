namespace OnlineShop.Data.Tables
{
    public class Product : BaseTable
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string ImagePath { get; set; }
    }

}
