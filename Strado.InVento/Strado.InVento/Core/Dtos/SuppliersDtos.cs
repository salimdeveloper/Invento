using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Dtos
{
    public class SuppliersDtos
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public AddressDtos Address { get; set; }
    }
}