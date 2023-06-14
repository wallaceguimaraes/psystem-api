using api.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace api.Validations
{
    public class JsonFile : ValidationAttribute
    {
        public JsonFile(params string[] values)
        {
            FileTypes = values.ToList();
            var stringTypes = new StringBuilder();

            if(FileTypes.Any())
                stringTypes.Append($"{{0}}: {FileTypes[0]}");

            for (int i = 1; i < FileTypes.Count; i++)
                stringTypes.Append($" {FileTypes[i]} or");

            ErrorMessage = stringTypes.ToString();
        }

        public List<string> FileTypes { get; set; }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is IFormFile file)
            {             
                return file.ContentType.In(FileTypes.ToArray());
            }

            throw new ArgumentException("This property must to return a Microsoft.AspNetCore.Http.IFormFile.");
        }
    }
}