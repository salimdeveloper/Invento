using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Validations
{
    public class FutureDate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                  "dd/mm/yyyy", CultureInfo.InvariantCulture,
                  DateTimeStyles.None,
                  out dateTime);
            return (isValid && dateTime > DateTime.Now);

        }
    }

    public class UploadImage : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var file = value as HttpPostedFileBase;

            var validImageTypes = new string[]
                           {
                     "image/gif",
                     "image/jpeg",
                     "image/pjpeg",
                     "image/png"
                           };

            if (file == null)
            {
                return false;
            }
            //if (file.ContentLength > 1 * 1024 * 1024)
            //{
            //    return false;
            //}

            var isValid = validImageTypes.Contains(file.ContentType);
            return (isValid);
        }
    }
  
}