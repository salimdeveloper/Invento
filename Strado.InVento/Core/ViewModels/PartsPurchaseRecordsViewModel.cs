using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Core.ViewModels
{
    public class PartsPurchaseRecordsViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Part")]
        public int PartsId { get; set; }

        public IEnumerable<Parts> Parts { get; set; }

        [Display(Name = "Price")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:#.#}")]
        public double PurchasePrice { get; set; }

        [Display(Name = "Quantity")]
        public int PurchaseQty { get; set; }

        [Display(Name = "Purchase Date")]
        public DateTime PurchaseDate { get; set; }

        [Display(Name = "Supplier")]
        public int SuppliersId { get; set; }

        public IEnumerable<Suppliers> Suppliers { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<Controllers.PartsPurchaseRecordsController, ActionResult>>
                    update = (c => c.Update(this));

                Expression<Func<Controllers.PartsPurchaseRecordsController, ActionResult>>
                    create = (c => c.AddRecords(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;


            }
        }
    }
}