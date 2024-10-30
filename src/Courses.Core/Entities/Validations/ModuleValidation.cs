﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Courses.Core.Entities.Validations
{
    public class ModuleValidation : AbstractValidator<Module>
    {
        public ModuleValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("The {PropertyName} field must be provided.").Length(2, 50)
                .WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.");

            RuleFor(x => x.Description).NotEmpty().WithMessage("The {PropertyName} field must be provided.").Length(2, 255)
                .WithMessage("The {PropertyName} field must be between {MinLength} and {MaxLength} characters.");
        }
    }
}
