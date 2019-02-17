namespace ModernStore.Domain.Services
{
    public interface IEmailService
    {
        void Send(string Name, string Email, string subject, string body);
        //Sendgrid pesquisar sobre
        //Zurb Foundation - Templates para corpo de e-mail.
    }
}
