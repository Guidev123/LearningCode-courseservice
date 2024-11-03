using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities.Validations
{
    public class CourseValidation : AbstractValidator<Course>
    {
        public CourseValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("The {PropertyName} field must be provided").Length(2, 50)
                .WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");
            RuleFor(x => x.Description).NotEmpty().WithMessage("The {PropertyName} field must be provided").Length(2, 255)
                .WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters");
        }

    }
}
