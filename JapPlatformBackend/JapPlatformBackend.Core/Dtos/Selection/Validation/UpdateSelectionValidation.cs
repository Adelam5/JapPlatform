using FluentValidation;

namespace JapPlatformBackend.Core.Dtos.Selection.Validation
{
    public class UpdateSelectionValidation : AbstractValidator<UpdateSelectionDto>
    {
        public UpdateSelectionValidation()
        {
            RuleFor(student => student.Name)
                .NotEmpty()
                .WithMessage("'Name' is required.")
                .Length(2, 15);

            RuleFor(student => student.StartDate)
                .Must(date => date != default(DateTime))
                .WithMessage("'StartDate' is required.");

            RuleFor(student => student.Status)
                .IsInEnum()
                .WithMessage("'Status' is required.");

            RuleFor(student => student.ProgramId)
                .NotEmpty()
                .WithMessage("'ProgramId' is required.");
        }
    }
}
