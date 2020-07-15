using MediatR;

namespace Template.Application.Commands
{
    public class CancelOrderCommand : IRequest<bool>
    {
        public int OrderNumber { get; private set; }
    }
}