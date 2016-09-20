using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class Suppliers
    {
        public int Id { get; set; }
        public string SupplierName { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}