using FluentValidation;
using MediatR;

namespace Template.Application.Commands
{
    public class CreateOrderCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
        {
            RuleFor(i => i.Id)
                .GreaterThan(0).WithMessage("Id should be greater than zero");

            RuleFor(i => i.FirstName)
                .NotNull().WithMessage("FirstName is null")
                .NotEmpty().WithMessage("FirstName is empty");

            RuleFor(i => i.LastName)
                .NotNull().WithMessage("LastName is null")
                .NotEmpty().WithMessage("LastName is empty");
        }
    }
}