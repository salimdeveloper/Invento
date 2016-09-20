using Strado.InVento.Core.Interfaces;
using Strado.InVento.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Strado.InVento.Controllers
{
    public class SupplierController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public SupplierController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        // GET: Supplier
        public ActionResult SupplierList()
        {
            var _supplier = _unitOfWork.Suppliers.GetAllSuppliers();
            return View(_supplier);
        }
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(Suppliers model)
        {
            var _supplier = new Suppliers
            {
                SupplierName = model.SupplierName,
                AddressId = model.AddressId,
                Address = new Address
                {
                    Address1 = model.Address.Address1,
                    Address2 = model.Address.Address2,
                    City = model.Address.City,
                    ContactName = model.Address.ContactName,
                    ContactNo = model.Address.ContactNo,
                    State = model.Address.State,
                    Pin = model.Address.Pin
                }
            };
            _unitOfWork.Suppliers.AddSupplier(_supplier);
            _unitOfWork.Complete();

            return RedirectToAction("SupplierList", "Suppliers");
        }
        
       
    }
}