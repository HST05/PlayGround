using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.Validations.FluentValidation
{
    public class TissueValidator:AbstractValidator<Tissue>
    {
        public TissueValidator()
        {
            RuleFor(p => p.Name).MinimumLength(2);
            RuleFor(p => p.Name).Must(StartsWithN).WithMessage("Ürün adı N ile başlamalı");
        }

        private bool StartsWithN(string arg)
        {
            return arg.StartsWith("N");
        }
    }
}
