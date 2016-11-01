using Strado.InVento.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Controllers
{
    public class InventoriesController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public InventoriesController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Inventories
        [Authorize]
        public ActionResult Details()
        {
            var _inventory = _unitOfWork.Inventory.GetAllInventories();
            return View(_inventory);
        }
    }
}