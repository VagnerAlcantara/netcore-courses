using ModernStore.Shared.Entities;

namespace ModernStore.Domain.ValueObjects
{
    public class Name : ValueObject
    {
        protected Name()
        {

        }
        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            if (string.IsNullOrEmpty(FirstName))
                AddNotification("FirstName", "Nome é obrigatório");

            if (string.IsNullOrEmpty(LastName))
                AddNotification("LastName", "Sobrenome é obrigatório");
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
