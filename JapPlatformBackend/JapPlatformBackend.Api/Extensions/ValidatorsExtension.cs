using FluentValidation;
using JapPlatformBackend.Core.Dtos.Selection;
using JapPlatformBackend.Core.Dtos.Selection.Validation;
using JapPlatformBackend.Core.Dtos.Student;
using JapPlatformBackend.Core.Dtos.Student.Validation;

namespace JapPlatformBackend.Api.Extensions
{
    public static class ValidatorsExtension
    {
        public static void RegisterValidators(this IServiceCollection service)
        {
            service.AddScoped<IValidator<CreateStudentDto>, CreateStudentValidation>();
            service.AddScoped<IValidator<UpdateStudentDto>, UpdateStudentValidation>();
            service.AddScoped<IValidator<CreateSelectionDto>, CreateSelectionValidation>();
            service.AddScoped<IValidator<UpdateSelectionDto>, UpdateSelectionValidation>();

        }
    }
}
