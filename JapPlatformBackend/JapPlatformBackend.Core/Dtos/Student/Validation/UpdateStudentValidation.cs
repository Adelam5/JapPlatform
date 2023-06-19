using FluentValidation;
using JapPlatformBackend.Core.Dtos.Student;

namespace JapPlatformBackend.Core.Dtos.Selection.Validation
{
    public class UpdateStudentValidation : AbstractValidator<UpdateStudentDto>
    {
        public UpdateStudentValidation()
        {
            RuleFor(student => student.FirstName)
                .NotEmpty()
                .WithMessage("'FirstName' is required.")
                .Length(2, 15);

            RuleFor(student => student.LastName)
                .NotEmpty()
                .WithMessage("'LastName' is required.")
                .Length(2, 25);

            RuleFor(student => student.BirthDate)
                .Must(date => date != default(DateTime))
                .WithMessage("'BirthDate' is required.");

            RuleFor(student => student.Status)
                .IsInEnum()
                .WithMessage("'Status' is required.");
        }
    }
}
