using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Dtos
{
    public class AddressDtos
    {
        public int Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pin { get; set; }

        public string ContactNo { get; set; }

        public string ContactName { get; set; }
    }
}