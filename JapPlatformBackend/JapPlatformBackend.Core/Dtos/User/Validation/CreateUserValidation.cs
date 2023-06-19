using FluentValidation;

namespace JapPlatformBackend.Core.Dtos.User.Validation
{
    public class CreateUserValidation : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidation()
        {
            RuleFor(s => s.FirstName)
                .NotEmpty()
                .WithMessage("'FirstName' is required.")
                .Length(2, 15);

            RuleFor(s => s.LastName)
                .NotEmpty()
                .WithMessage("'LastName' is required.")
                .Length(2, 25);
        }

    }
}
