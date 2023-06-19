using FluentValidation;

namespace JapPlatformBackend.Core.Dtos.Student.Validation
{
    public class CreateStudentValidation : AbstractValidator<CreateStudentDto>
    {
        private List<string> studentStatus = new()
        {
            "InProgram", "Success", "Failed", "Extended"
        };
        public CreateStudentValidation()
        {

            RuleFor(s => s.BirthDate)
                .Must(date => date != default(DateTime))
                .WithMessage("'BirthDate' is required.");

            RuleFor(s => s.Status)
                .Must(s => studentStatus.Contains(s.ToString()))
                .WithMessage("Valid 'Status' must be one of: InProgram, Success, Failed, Extended.");
        }

    }
}
