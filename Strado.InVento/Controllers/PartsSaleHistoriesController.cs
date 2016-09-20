using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Controllers
{
    public class PartsSaleHistoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartsSaleHistoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: PartsSaleHistories
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult Sales()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sales(PartsSaleHistory model)
        {
            var _partsSaleHistory = new PartsSaleHistory
            {
                PartsId = model.PartsId,
                SoldDate = DateTime.Now,
                WithdrawlReason=model.WithdrawlReason,
                QtyWithdrawn=model.QtyWithdrawn,
                SoldPrice=model.SoldPrice
            };
            return RedirectToAction("PartsSalesList", "PartsSaleHistories");
        }
    }
}