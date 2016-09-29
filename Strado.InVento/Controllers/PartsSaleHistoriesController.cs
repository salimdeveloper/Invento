using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using Strado.InVento.Core.ViewModels;
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
            var _partsSalesHistory = new PartsSaleHistoryViewModel {
                
                Parts = _unitOfWork.Parts.GetAllParts()
            };
            return View(_partsSalesHistory);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Sales(PartsSaleHistoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
                
                model.Parts = _unitOfWork.Parts.GetAllParts();
                return View(model);
            }
            var _partsSaleHistory = new PartsSaleHistory
            {
                PartsId = model.PartsId,
                SoldDate = DateTime.Now,
                WithdrawlReason=model.WithdrawlReason,
                QtyWithdrawn=model.QtyWithdrawn,
                SoldPrice=model.SoldPrice
            };
             
            _unitOfWork.PartsSaleHistories.AddPartWithdrawl(_partsSaleHistory);
            var _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(model.PartsId);
            if (_inventory != null)
            {
                _inventory.DeleteStockQuantity(model.PartsId, model.QtyWithdrawn, DateTime.Now);
            }
            _unitOfWork.Complete();
          

            return RedirectToAction("PartsSalesList", "PartsSaleHistories");
        }
    }
}