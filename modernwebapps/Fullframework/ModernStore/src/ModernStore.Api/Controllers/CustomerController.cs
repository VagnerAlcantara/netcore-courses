using Microsoft.AspNetCore.Mvc;
using ModernStore.Domain.Commands.Handlers;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Infra.Transations;
using System.Threading.Tasks;

namespace ModernStore.Api.Controllers
{
    public class CustomerController : BaseController
    {
        private readonly CustomerCommandHandler _handler;

        public CustomerController(IUow uow, CustomerCommandHandler handler)
            : base(uow)
        {
            _handler = handler;
            //_customerRepository = customerRepository;
        }

        [HttpPost]
        //[FromBody] diz que os dados vem do corpo e não da url
        [Route("v1/customers")]
        public async Task<IActionResult> Post([FromBody] RegisterCustomerCommand command)
        {
            /* Post válido
             {
	            "FirstName": "Vagner",
	            "LastName": "Alcantara",
	            "Email": "vagneralcantara15@gmail.com",
	            "Document": "55373466050",
	            "Username": "vferreira",
	            "Password": "12345",
	            "ConfirmPassword": "12345"
            }
             */
            var result = _handler.Handle(command);

            return await Response(result, _handler.Notifications);
        }
    }
}
