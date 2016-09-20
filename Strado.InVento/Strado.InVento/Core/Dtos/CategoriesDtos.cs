using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Dtos
{
    public class CategoriesDtos
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool IsDelete { get; set; }
    }
}