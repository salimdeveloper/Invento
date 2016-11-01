using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Strado.InVento.Core.Validations;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Core.ViewModels
{
    public class PartsFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string PartName { get; set; }

        
        [Display(Name = "Image")]
        [UploadImage(ErrorMessage ="Enter a valid image type.")]
        public HttpPostedFileBase PartImage { get; set; }

        [Required]
        [Display(Name = "Details")]
        public string PartDetails { get; set; }

        public bool IsDelete { get; private set; }
        [Display(Name = "Category")]
        public int CategoriesId { get; set; }

        public IEnumerable<Categories> Categories { get; set; }

        [Display(Name = "Brand")]
        public int BrandId { get; set; }

        public IEnumerable<Brand> Brands { get; set; }

        public string Heading { get; set; }

        public string ImageUrl { get; set; }


        public string Action
        {
            get
            {
                Expression<Func<Controllers.PartsController, ActionResult>>
                    update = (c => c.Update(this));

                Expression<Func<Controllers.PartsController, ActionResult>>
                    create = (c => c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;


            }
        }
    }
}