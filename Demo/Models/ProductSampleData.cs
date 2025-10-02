namespace Demo.Models
{
    
    public class ProductSampleData
    {
        List<Product> products;
        public ProductSampleData()
        {
            products = new List<Product>();
            products.Add(new Product() { Id = 1, Name = "amany", Price = 3000, Description = "Developer" });
            products.Add(new Product() { Id = 2, Name = "mohamed", Price = 4000, Description = "Tester" });
            products.Add(new Product() { Id = 3, Name = "mohamed", Price = 5000, Description = "manager" });
            products.Add(new Product() { Id = 4, Name = "mohamed", Price = 6000, Description = "senior" });
            products.Add(new Product() { Id = 5, Name = "mohamed", Price = 7000, Description = "semi-senior" });
        }
        

    }
}
