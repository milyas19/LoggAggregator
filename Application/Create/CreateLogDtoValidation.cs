using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Create
{
    public class CreateLogDtoValidation : AbstractValidator<CreateLogDto>
    {
        public CreateLogDtoValidation()
        {
            RuleFor(h => h.HostName).NotEmpty().WithMessage("Hostname cannot be empty");
            RuleFor(s => s.Severity).NotEmpty().WithMessage("Severity cannot be empty");
            RuleFor(m => m.Severity).NotEmpty().WithMessage("Message cannot be empty");
        }
    }
}
