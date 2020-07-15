using MediatR;

namespace Template.Application.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public int OrderNumber { get; private set; }
    }
}