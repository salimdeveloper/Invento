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
    public class PartsWithdrawHistoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartsWithdrawHistoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: PartsSaleHistories
        [Authorize]
        public ActionResult WithdrawlHistory()
        {
            var partsWithdrawl = _unitOfWork.PartsWithdrawHistories.GetAllPartsWithdrawl();
            return View(partsWithdrawl);
        }

        [Authorize]
        public ActionResult Withdraw()
        {
            var _partsSalesHistory = new PartsWithdrawHistoryViewModel
            {
                Heading = "Withdraw Parts",
                Parts = _unitOfWork.Parts.GetAllParts()
            };
            return View(_partsSalesHistory);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Withdraw(PartsWithdrawHistoryViewModel model)
        {
            if (!ModelState.IsValid)
            {
               model.Heading = "Withdraw Parts";
                model.Parts = _unitOfWork.Parts.GetAllParts();
                return View(model);
            }
            var _partsSaleHistory = new PartsWithdrawHistory
            {
                PartsId = model.PartsId,
                SoldDate = DateTime.Now,
                WithdrawlReason = model.WithdrawlReason,
                QtyWithdrawn = model.QtyWithdrawn,
                SoldPrice = model.SoldPrice
            };

            _unitOfWork.PartsWithdrawHistories.AddPartWithdrawl(_partsSaleHistory);
            var _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(model.PartsId);
            if (_inventory != null)
            {
                _inventory.DeleteStockQuantity(model.PartsId, model.QtyWithdrawn, DateTime.Now);
            }
            _unitOfWork.Complete();


            return RedirectToAction("WithdrawlHistory", "PartsWithdrawHistories");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            PartsWithdrawHistory _histoy = _unitOfWork.PartsWithdrawHistories.GetPartsWithdrawlByWithdrawalId(id);
            var viewModel = new PartsWithdrawHistoryViewModel
            {
                Id = _histoy.Id,
                Parts=_unitOfWork.Parts.GetAllPartsExcludeDeleted(),
                PartsId=_histoy.PartsId,
                QtyWithdrawn=_histoy.QtyWithdrawn,
                SoldDate=_histoy.SoldDate,
                SoldPrice=_histoy.SoldPrice,
                WithdrawlReason=_histoy.WithdrawlReason
            };
            return View("Withdraw",viewModel);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Update(PartsWithdrawHistoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Parts = _unitOfWork.Parts.GetAllParts();
               return View("Withdraw", viewModel);
            }
            var partsWithdrawHistory = _unitOfWork.PartsWithdrawHistories.GetPartsWithdrawlByWithdrawalId(viewModel.Id);
            int initailQty = partsWithdrawHistory.QtyWithdrawn;
            partsWithdrawHistory.Modify(viewModel.PartsId,viewModel.QtyWithdrawn,viewModel.WithdrawlReason,viewModel.SoldPrice,viewModel.SoldDate);
            var _inventory = _unitOfWork.Inventory.GetInventoryByPartsId(viewModel.PartsId);
            if (_inventory != null)
            {
                _inventory.UpdateStockQuantity(viewModel.PartsId, viewModel.QtyWithdrawn,initailQty);
            }
            _unitOfWork.Complete();
            return RedirectToAction("WithdrawlHistory", "PartsWithdrawHistories");
        }
    }
}