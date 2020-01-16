﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CMSShoppingCart.Infrastructure
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var context = (CMSShoppingCartContext)validationContext.GetService(typeof(CMSShoppingCartContext));

            var file = value as IFormFile;

            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName);

                string[] extensions = { "jpg", "png" };
                bool result = extensions.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Allowed extensions are: " + string.Join(", ", extensions));

                }

            }

            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return "Allowed extensions are jpg and png.";
        }
    }
}