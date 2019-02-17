using ModernStore.Shared.Entities;
using System.Text;

namespace ModernStore.Domain.ValueObjects
{
    public class Password : ValueObject
    {
        private string _pass = string.Empty;

        protected Password()
        {

        }
        public Password(string pass)
        {
            _pass = pass;

            if (string.IsNullOrEmpty(pass))
                AddNotification("Password", "Senha é obrigatória");
        }

        public string Pass
        {
            get
            {
                return Encrypt(Pass);
            }
            private set
            {
                Pass = value;
            }
        }

        internal static string Encrypt(string password)
        {
            if (!string.IsNullOrEmpty(password))
                return "";

            var pass = string.Empty;

            pass = (pass += "|2d331cca-f6c0-40c0-bb43-6e32989c2881"); //Trocar hash
            var mD5 = System.Security.Cryptography.MD5.Create(pass);
            var data = mD5.ComputeHash(Encoding.Default.GetBytes(pass));
            var sbString = new StringBuilder();

            foreach (var item in data)
                sbString.Append(item.ToString("x2"));

            return sbString.ToString();
        }
    }
}
