using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class OrderTests
    {
        private readonly User _user;
        private readonly Customer _customer;
        private readonly Password password;
        private readonly Password confimPassword;


        public OrderTests()
        {
            password = new Password("vagner");
            confimPassword = new Password("vagner");
            _user = new User("vagner", password, confimPassword);
            Name name = new Name("Vagner", "Alcantara");
            Email email = new Email("email@email.com");
            Document document = new Document("08101630392");
            _customer = new Customer(name, email, document, _user);
        }

        [TestMethod]
        [TestCategory("Order - new order")]
        public void GivenAnOutOfStockProductIdShouldReturnAnError()
        {

            var mouse = new Product("Mouse", 299, "mouse.jpg", 0);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsFalse(order.IsValid());
        }

        [TestMethod]
        [TestCategory("Order - new order")]
        public void GivenAnInStockProductIdShouldUpdateQuantityOnHand()
        {
            var mouse = new Product("Mouse", 299, "mouse.jpg", 20);

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        [TestCategory("Order - new order")]
        public void GivenAValidOrderTheTotalShouldBe310()
        {
            var mouse = new Product("Mouse", 300, "mouse.jpg", 20);

            var order = new Order(_customer, 12, 2);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        }
    }
}
