using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
using Projeto.Services;

namespace Projeto.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _service;

        public SellersController(SellerService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var list = _service.FindAll();
            return View(list);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller obj)
        {
            _service.Insert(obj);
            return RedirectToAction(nameof(Index));
        }
    }
}