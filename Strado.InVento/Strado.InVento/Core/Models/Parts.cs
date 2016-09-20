using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class Parts
    {
        public int Id { get; set; }

        public string PartName { get; set; }

        public string PartImageUrl { get; set; }

        public string PartDetails { get; set; }

        public bool IsDelete { get; private set; }

        public int CategoriesId { get; set; }

        public Categories Categories { get; set; }

        public int BrandId { get; set; }

        public Brand Brands { get; set; }

        public void Deleted()
        {
            IsDelete = true;
        }
    }
}