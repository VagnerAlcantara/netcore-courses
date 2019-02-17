using ModernStore.Domain.Services;
using System;

namespace ModernStore.Infra.Services
{
    public class EmailService : IEmailService
    {
        public void Send(string Name, string Email, string subject, string body)
        {
            //System.Net.Mail
            throw new NotImplementedException();
        }
    }
}
