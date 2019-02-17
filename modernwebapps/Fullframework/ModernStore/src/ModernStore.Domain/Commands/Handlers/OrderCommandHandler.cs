using ModernStore.Domain.Command.Results;
using ModernStore.Domain.Commands.Inputs;
using ModernStore.Domain.Entities;
using ModernStore.Domain.Repositories;
using ModernStore.Shared.Commands;
using ModernStore.Shared.Entities;

namespace ModernStore.Domain.Commands.Handlers
{
    public class OrderCommandHandler : Notification, ICommandHandler<RegisterOrderCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderCommandHandler(ICustomerRepository customerRepository, IProductRepository productRepository, IOrderRepository orderRepository)
        {
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _orderRepository = orderRepository;
        }

        public ICommandResult Handle(RegisterOrderCommand command)
        {
            var customer = _customerRepository.Get(command.Customer);
            var order = new Order(customer, command.DeliveryFee, command.Discount);

            foreach (var item in command.Items)
            {
                var product = _productRepository.Get(item.Product);
                order.AddItem(new OrderItem(product, item.Quantity));
            }

            AddNotification(customer.Notifications);
            AddNotification(order.Notifications);

            if (IsValid())
                _orderRepository.Save(order);

            return new RegisterOrderCommandResult(order.Number);
        }
    }
}
