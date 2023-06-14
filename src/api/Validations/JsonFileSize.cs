using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace api.Validations
{
    public class JsonFileSize : ValidationAttribute
    {
        public const long Max10MB = 10485760;
        public const long Max1MB = 1048576;
        public const long Max2MB = 2097152;
        public const long Max3MB = 3145728;

        private long _maxSize;

        public JsonFileSize(long maxSize)
        {
            _maxSize = maxSize;
            ErrorMessage = $"{{0}}: Maxixmum {maxSize} bytes.";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            if (value is IFormFile file)
            {
                return file.Length <= _maxSize;
            }

            throw new ArgumentException("This property must to return a Microsoft.AspNetCore.Http.IFormFile.");
        }
    }
}