using api.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonImageOrPdf : ValidationAttribute
    {
        public JsonImageOrPdf()
        {
            ErrorMessage = "{0}: image/jpeg or image/png or application/pdf.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is IFormFile file)
            {
                return file.ContentType.In("image/jpeg", "image/png", "application/pdf");
            }

            throw new ArgumentException("This property must to return a Microsoft.AspNetCore.Http.IFormFile.");
        }
    }
}
