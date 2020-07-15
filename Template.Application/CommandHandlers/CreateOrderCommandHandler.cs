using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Template.Application.Commands;
using Template.Domain.Repositories;

namespace Template.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        private readonly IOrderRepository _orderRepository;

        public CreateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = _orderRepository.FindAsync(Guid.Empty);

            return Task.FromResult(true);
        }
    }
}