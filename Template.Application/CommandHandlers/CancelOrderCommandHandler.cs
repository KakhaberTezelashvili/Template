using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Template.Application.Commands;

namespace Template.Application.CommandHandlers
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, bool>
    {
        public Task<bool> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            return Task.FromResult(true);
        }
    }
}