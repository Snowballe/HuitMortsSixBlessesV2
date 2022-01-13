
using Geometrie.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses.Web.Controllers
{
    public class TrianglesController : Controller
    {
        private IHuitMortsSixBlessesService service;

        public TrianglesController(IHuitMortsSixBlessesService srv)
        {
            service = srv;
        }

        public IActionResult Index()
        {
            var triangles = service.GetAllTriangles();
            return View(triangles);
        }

        public IActionResult Ajouter()
        {
            return View(new TriangleVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Ajouter([Bind("X1,Y1,X2,Y2,X3,Y3")]TriangleVM vm)
        {
            if (ModelState.IsValid)
            {
                //je transforme mon viewmodel en objet métier
                var tri = new Panier_Fournisseur(
                        new Ligne(vm.X1.Value,vm.Y1.Value)
                        ,new Ligne(vm.X2.Value, vm.Y2.Value)
                        ,new Ligne(vm.X3.Value, vm.Y3.Value)
                    );
                //j'appelle le service
                service.Insert(tri);

                //je retourne à la liste des triangles
                return RedirectToAction("Index");
            }

            return View(vm);
        }
    }
}
