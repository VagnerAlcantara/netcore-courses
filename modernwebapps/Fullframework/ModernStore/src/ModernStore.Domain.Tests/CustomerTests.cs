using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;
using System;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly Password password;
        private readonly Password confimPassword;
        private readonly User user;

        public CustomerTests()
        {
            password = new Password("vagner");
            confimPassword = new Password("vagner");
            user = new User("Vagner", password, confimPassword);
        }


        [TestMethod]
        [TestCategory("Customer - New Customer")]
        //public void Dado_um_nome_invalido_deve_retornar_uma_notificacao()
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
            Name name = new Name("", "Alcantara");
            Email email = new Email("email@email.com");
            Document document = new Document("08101630392");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }
        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
            Name name = new Name("Vagner", "");
            Email email = new Email("email@email.com");
            Document document = new Document("08101630392");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }
        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailShouldReturnANotification()
        {
            Name name = new Name("Vagner", "Alcantara");
            Email email = new Email("em");
            Document document = new Document("08101630392");
            var customer = new Customer(name, email, document, user);

            Assert.IsFalse(customer.IsValid());
        }
    }
}
