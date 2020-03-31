using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Models.ViewModels;
using Projeto.Services;
using Projeto.Services.Exceptions;

namespace Projeto.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _service;
        private readonly DepartmentService _DepartmentService;
        public SellersController(SellerService service, DepartmentService departmentService)
        {
            _DepartmentService = departmentService;
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
        
        public IActionResult Create()
        {
            var departments = _DepartmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _service.Insert(seller);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var obj = _service.FindById(id.Value);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _service.Remove(id);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _service.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);

        }
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();

            var obj = _service.FindById(id.Value);

            if (obj == null) return NotFound();

            List<Department> departments = _DepartmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
            if(id != seller.Id)
            {
                return BadRequest(); 
            }

            try
            {
                _service.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch(NotFoundException)
            {
                return NotFound();
            }
            catch(DBConcurrencyException)
            {
                return BadRequest();
            }
            
        }
    }
}