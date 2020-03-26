using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Projeto.Models;
namespace Projeto.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> lista = new List<Department>();
            lista.Add(new Department { Id = 1, Name = "Opa" });
            lista.Add(new Department { Id = 2, Name = "Opa2" });
            return View(lista);
        }
    }
}