using ModernStore.Shared.Entities;

namespace ModernStore.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        protected Email()
        {

        }
        public Email(string address)
        {
            Address = address;

            if (Address.Length < 5)
                AddNotification("Email", "E-mail inválido");
        }

        public string Address { get; private set; }

    }
}
