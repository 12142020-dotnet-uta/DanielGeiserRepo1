using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ModelLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace project_1.Controllers
{
    public class CartController : Controller
    {
        private readonly ILogger<CartController> _logger;
        private StoreLevelPrograms _storeLevelPrograms;
        public CartController(StoreLevelPrograms storeLevelPrograms, ILogger<CartController> logger)
        {
            _storeLevelPrograms = storeLevelPrograms;
            _logger = logger;
        }
        // GET: CartController
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult ViewCart(int id)
        {
            return View();
        }

        public ActionResult AddToCart(StoreViewModel svm)
        {
            _storeLevelPrograms.AddToCart(svm, HttpContext);
            return View();
        }

        // POST: CartController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CartController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CartController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CartController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
