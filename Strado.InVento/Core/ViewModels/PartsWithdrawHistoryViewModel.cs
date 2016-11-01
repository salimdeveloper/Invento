using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Core.ViewModels
{
    public class PartsWithdrawHistoryViewModel
    {
        public int Id { get; set; }
        public int PartsId { get; set; }
        public IEnumerable<Parts> Parts { get; set; }
        public DateTime SoldDate { get; set; }
        public double SoldPrice { get; set; }
        public int QtyWithdrawn { get; set; }
        public PartWithdrawlReason WithdrawlReason { get; set; }
        public string Heading { get; set; }
        public string Action
        {
            get
            {
                Expression<Func<Controllers.PartsWithdrawHistoriesController, ActionResult>>
                    update = (c => c.Update(this));

                Expression<Func<Controllers.PartsWithdrawHistoriesController, ActionResult>>
                    create = (c => c.Withdraw(this));
                var action = (Id != 0) ? update : create;
                return (action.Body as MethodCallExpression).Method.Name;


            }
        }
    }
}