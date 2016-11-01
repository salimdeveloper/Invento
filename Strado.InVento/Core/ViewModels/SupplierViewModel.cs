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
    public class SupplierViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255,ErrorMessage ="Maximum caharater cannot be more than 255")]
        [Display(Name = "Supplier Name")]
        public string SupplierName { get; set; }

        [Display(Name = "Address")]
        [Required]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        public string Heading { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<Controllers.SupplierController, ActionResult>>
                    update = (c => c.Update(this));

                Expression<Func<Controllers.SupplierController, ActionResult>>
                    create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;


            }
        }
    }
}