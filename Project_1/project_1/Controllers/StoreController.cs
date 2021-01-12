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
    public class StoreController : Controller
    {
        private StoreLevelPrograms _storeLevelPrograms;
        private readonly ILogger<StoreController> _logger;
        public StoreController(StoreLevelPrograms storeLevelPrograms, ILogger<StoreController> logger)
        {
            _storeLevelPrograms = storeLevelPrograms;
            _logger = logger;
        }

        // GET: StoreController
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStoreInvertory(int id)
        {
            List<StoreViewModel> storViewModels = new List<StoreViewModel>();
            storViewModels = _storeLevelPrograms.ProductSelection(id);
            return View("StoreInventory", storViewModels);
        }

       
        // GET: StoreController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreController/Create
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

        // GET: StoreController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreController/Edit/5
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

        // GET: StoreController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreController/Delete/5
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
