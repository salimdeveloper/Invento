using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Dtos
{
    public class PartsDtos
    {
        public int Id { get; set; }

        public string PartName { get; set; }

        public string PartImageUrl { get; set; }

        public string PartDetails { get; set; }

        public bool IsDelete { get; private set; }


        public CategoriesDtos Categories { get; set; }

        public BrandsDto Brands { get; set; }

    }
}