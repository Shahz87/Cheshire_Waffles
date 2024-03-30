namespace Cheshire_Waffles.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        // Name of the item in the cart.
        public string Name { get; set; }

        // Quantity of the item in the cart.
        public int Quantity { get; set; }

        // Price of the item in the cart.
        public decimal Price { get; set; }
    }
}