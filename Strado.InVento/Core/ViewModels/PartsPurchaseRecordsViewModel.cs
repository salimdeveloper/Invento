using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.ViewModels
{
    public class PartsPurchaseRecordsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Part")]
        public int PartsId { get; set; }

        public IEnumerable<Parts> Parts { get; set; }

        [Display(Name = "Price")]
        public double PurchasePrice { get; set; }

        [Display(Name = "Quantity")]
        public int PurchaseQty { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Supplier")]
        public int SuppliersId { get; set; }

        public IEnumerable<Suppliers> Suppliers { get; set; }
    }
}