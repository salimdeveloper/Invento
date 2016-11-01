using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Strado.InVento.Core.Models
{
    public class Categories
    {
        public int Id { get; set; }

        [Display(Name = "Category Name")]
        [Required]
        public string CategoryName { get; set; }

        public bool IsDelete { get; private set; }

        public void Deleted()
        {
            IsDelete = true;
        }
        internal void Modify(string categoryName)
        {
            this.CategoryName = categoryName;
        }
    }
}