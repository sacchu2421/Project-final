using Shopping_Cart.Models;

namespace Shopping_Cart.Repository
{
    public interface IProductRepository
    {
        public Product GetProductById(int id);
        public IEnumerable<Product> GetAllProducts();
        public bool AddProduct(Product product);
        public bool UpdateProduct(int id, Product product);
        public bool DeleteProduct(int id);
        public IEnumerable<Product> SortingByPrice();
        public IEnumerable<Product> SortingByCategory(string category);
    }
}
