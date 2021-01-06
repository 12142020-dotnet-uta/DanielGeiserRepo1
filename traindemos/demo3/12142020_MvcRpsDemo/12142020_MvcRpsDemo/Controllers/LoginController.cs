using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelsLayer.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _12142020_MvcRpsDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        //[ActionName("Login")]
        public ActionResult Login()
        {
            return View();
        }
        [ActionName("LoginPlayer")]
        public ActionResult Login(LoginPlayerViewModel loginPlayerViewModel)
        {
            Player newPlayer = new Player()
            {
                Fname = loginPlayerViewModel.Fname,
                Lname = loginPlayerViewModel.Lname,
                numLosses = 2,
                numWins =10
            };

            return View("DisplayPlayerDetails",newPlayer);
        }

        // GET: LoginController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: LoginController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginController/Create
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

        // GET: LoginController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LoginController/Edit/5
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

        // GET: LoginController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LoginController/Delete/5
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
