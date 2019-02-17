using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Entities;
using System;

namespace ModernStore.Domain.Entities
{
    public class User : Entity
    {
        protected User()
        {

        }
        public User(string username, Password password, Password confirmPassword)
        {
            Username = username;
            Password = password;
            Active = true;

            if (!string.Equals(password, confirmPassword))
                AddNotification("Password", "As senhas não coincidem");
        }

        public string Username { get; private set; }
        public Password Password { get; private set; }
        public bool Active { get; private set; }

        public void Activate() => Active = true; // Arrow function

        //Function padrão
        public void Inactivate()
        {
            Active = false;
        }
        public bool Authenticate(string username, string password)
        {
            var passEnc = Password.Encrypt(password);

            if (Username == username && Password.Pass == passEnc)
                return true;

            AddNotification("User", "Usuário ou senha inválido");

            return false;
        }
    }
}
