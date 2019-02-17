using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class Customer : Entity
    {
        protected Customer()
        {

        }
        public Customer(Name name, Email email, Document document, User user)
        {
            Name = name;
            Active = false; //definido por regra, não precisa ser recebido no construtor
            User = user;
            Email = email;
            Document = document;

            AddNotification(Name.Notifications);
            AddNotification(email.Notifications);
            AddNotification(Document.Notifications);
        }

        public Name Name { get; private set; }
        public DateTime BirthDate { get; private set; }
        public bool Active { get; private set; }
        public User User { get; private set; }
        public Email Email { get; private set; }
        public Document Document { get; private set; }

        public void Update(Name name, DateTime birthDate)
        {
            Name = name;
            BirthDate = birthDate;
        }

        public override string ToString()
        {
            return Name.ToString();
        }

    }
}
