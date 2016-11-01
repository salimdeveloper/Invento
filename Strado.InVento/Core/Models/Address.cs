using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class Address
    {
        public int Id { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Pin { get; set; }

        public string ContactNo { get; set; }

        public string ContactName { get; set; }

        internal void Modify(Address address)
        {
            this.Address1 = address.Address1;
            this.Address2 = address.Address2;
            this.City = address.City;
            this.ContactName = address.ContactName;
            this.ContactNo = address.ContactNo;
            this.State = address.State;
            this.Pin = address.Pin;
        }


    }
}