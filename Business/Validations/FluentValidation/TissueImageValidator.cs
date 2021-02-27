using System;
using System.Collections.Generic;
using System.Text;
using Core.Abstract;
using Entities.Concrete;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.Validations.FluentValidation
{
    public class TissueImageValidator : AbstractValidator<IFile>
    {
        public TissueImageValidator()
        {
            RuleFor(p => p.File).NotEmpty().WithMessage("Image is empty");
            RuleFor(p => p.File).Must(ExtensionChecker).WithMessage("File extension invalid");
        }

        private bool ExtensionChecker(IFormFile arg)
        {
            string extension = System.IO.Path.GetExtension(arg.FileName);
            if (extension == ".jpg")
            {
                return true;
            }

            return false;
        }
    }
}
