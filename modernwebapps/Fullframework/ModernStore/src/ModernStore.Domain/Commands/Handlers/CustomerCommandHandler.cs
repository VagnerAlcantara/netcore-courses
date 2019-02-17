using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Domain.Services;
using ModernStore.Domain.ValueObjects;
using ModernStore.Shared.Commands;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Commands.Handlers
{
    public class CustomerCommandHandler : Notification, ICommandHandler<RegisterCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;

        public CustomerCommandHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            _customerRepository = customerRepository;
            _emailService = emailService;
        }

        public ICommandResult Handle(RegisterCustomerCommand command)
        {
            //Passo 1. Verificar se CPF já existe
            if (_customerRepository.DocumentExists(command.Document))
            {
                AddNotification("Documento", "Este CPF já está em uso.");
                return null;
            }

            //Passo 2. Gerar novo cliente
            var name = new Name(command.FirstName, command.LastName);
            var email = new Email(command.Email);
            var document = new Document(command.Document);
            var password = new Password(command.Password);
            var confimPassword = new Password(command.ConfirmPassword);
            var user = new User(command.Username, password, confimPassword);
            var customer = new Customer(name, email, document, user);

            //Passo 3. Adicionando notificações
            AddNotification(name.Notifications);
            AddNotification(email.Notifications);
            AddNotification(document.Notifications);
            AddNotification(password.Notifications);
            AddNotification(confimPassword.Notifications);
            AddNotification(user.Notifications);
            AddNotification(customer.Notifications);

            if (!IsValid())
                return null;

            //Passo 4.  Inserir no banco
            _customerRepository.Save(customer);

            //Passo 5. Enviar e-mail de boas vindas
            _emailService.Send(
                customer.Name.ToString(),
                customer.Email.Address,
                /*string.Format(EmailTemplates.WelcomeEmailTitle, customer.Name),
                string.Format(EmailTemplates.WelcomeEmailBody, customer.Name)*/
                customer.Name.ToString(),
                "Bem vindo"
                );

            //Passo 6. Retornar
            return new RegisterCustomerCommandResult(customer.Id, customer.Name.ToString());
        }
    }
}
