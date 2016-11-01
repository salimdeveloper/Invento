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
    public class BrandsViewModel
    {
        public int Id { get; set; }

        [Required]
        public string BrandName { get; set; }

        //Implement Valid Upload Image Extension
        
        [UploadImage(ErrorMessage ="Select Valid Image Type")]
        public HttpPostedFileBase BrandLogo { get; set; }

        public string Heading { get; set; }

        public string ImageUrl { get; set; }

        public string Action
        {
            get
            {
                Expression<Func<Controllers.BrandsController, ActionResult>>
                    update = (c=>c.Update(this));
                Expression<Func<Controllers.BrandsController, ActionResult>>
                    create = (c=>c.Create(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;
            }
        }





        #region Commented Code
            //public string Action
            //{
            //    get
            //    {
            //        //Expression<Func<Controllers.BrandsController, ActionResult>>
            //        //    update = (c => c.Update(this));

            //        Expression<Func<Controllers.BrandsController, ActionResult>>
            //            create = (c => c.Create(this));

            //        var action = (Id != 0) ? update : create;
            //        return (action.Body as MethodCallExpression).Method.Name;
            //    }
            //}
            #endregion
        }
}