﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage
{
    public class CreateProgrammingLanguageCommandValidator:AbstractValidator<CreateProgrammingLanguageCommand>
    {
        public CreateProgrammingLanguageCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Programlama dili ismi boş geçilemez");
        }
    }
}