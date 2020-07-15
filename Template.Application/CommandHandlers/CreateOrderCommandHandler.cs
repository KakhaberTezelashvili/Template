using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Template.Application.Commands;

namespace Template.Application.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, bool>
    {
        public Task<bool> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}