using FluentValidation;

namespace JapPlatformBackend.Core.Dtos.Selection.Validation
{
    public class CreateSelectionValidation : AbstractValidator<CreateSelectionDto>
    {
        private List<string> studentStatus = new()
        {
            "Active", "Complete"
        };
        public CreateSelectionValidation()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("'Name' is required.")
                .Length(2, 15);
            RuleFor(s => s.StartDate)
                .Must(date => date != default(DateTime))
                .WithMessage("'StartDate' is required.");
            RuleFor(s => s.Status)
                .Must(s => studentStatus.Contains(s.ToString()))
                .WithMessage("Valid 'Status' must be one of: Active, Complete");
            RuleFor(s => s.ProgramId).NotEmpty().WithMessage("'ProgramId' is required.");
        }

    }
}
