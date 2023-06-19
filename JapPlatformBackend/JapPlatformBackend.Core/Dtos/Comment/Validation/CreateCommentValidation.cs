using FluentValidation;

namespace JapPlatformBackend.Core.Dtos.Comment.Validation
{
    public class CreateCommentValidation : AbstractValidator<CreateCommentDto>
    {
        public CreateCommentValidation()
        {
            RuleFor(c => c.Text).NotEmpty().WithMessage("'Text' is required.").Length(2, 500);
            RuleFor(c => c.StudentId).NotNull().WithMessage("'StudentId' is required.").GreaterThan(0);

        }
    }
}
