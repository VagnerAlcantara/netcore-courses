using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Entities
{
    public class OrderItem : Entity
    {
        protected OrderItem()
        {

        }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = Product.Price;

            if (Quantity == 0)
                AddNotification("Quantity", "Quantidade não pode ser 0");

            if (Product.QuantityOnHand < Quantity)
                AddNotification("QuantityOnHand", $"Não temos {Product.Title} em estoque");

            Product.DeacreaseQuantity(quantity);
        }

        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public decimal Total() => Price * Quantity;


    }
}