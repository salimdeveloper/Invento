using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Core.ViewModels
{
    public class CategoriesViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public string CategoryName { get; set; }

        public bool IsDelete { get; set; }


        public string Heading { get; set; }


        public string Action
        {
            get
            {
                Expression<Func<Controllers.CategoriesController, ActionResult>>
                    update = (c => c.Update(this));
                Expression<Func<Controllers.CategoriesController, ActionResult>>
                    create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }


    }
}