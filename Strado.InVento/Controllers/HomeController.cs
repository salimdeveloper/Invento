using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Index()
        {
            var dashBoardViewModel = new DashbordViewModel
            {
                Inventories = _unitOfWork.Inventory.GetAllInventories().OrderBy(x=>x.QtyInStock).Take(8),
                PartsWithdrawls = _unitOfWork.PartsWithdrawHistories.GetAllPartsWithdrawl().Take(4),
                PartsPurchases= _unitOfWork.PartsPurchaseRecords.GetAllPartsPurchaseRecords().Take(4)
                
            };
            return View(dashBoardViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}