using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }

        [Display(Name = "Brand Logo")]
        public string LogoImgSrc { get; set; }

        
    }
}