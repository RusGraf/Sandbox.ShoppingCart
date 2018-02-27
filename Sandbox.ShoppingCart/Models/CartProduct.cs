namespace Sandbox.ShoppingCart.Models
{
    public class CartProduct : Product
    {
        public CartProduct(Product product)
        {
            ProductId = product.ProductId;
            Name = product.Name;
            Description = product.Description;
            Price = product.Price;
            QtyAvailable = product.QtyAvailable;
            CategoryName = product.CategoryName;
        }

        public int QuantityToOrder { get; set; } = 1;
    }
}