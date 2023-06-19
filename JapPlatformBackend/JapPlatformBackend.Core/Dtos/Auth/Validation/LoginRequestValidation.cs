using FluentValidation;

namespace JapPlatformBackend.Core.Dtos.Auth.Validation
{
    public class LoginRequestValidation : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestValidation()
        {
            RuleFor(x => x.Username).NotEmpty().MinimumLength(2);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(4);
        }

    }
}
