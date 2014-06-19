using Landeeyo.Pizza.AccountControl.Interfaces;
using Landeeyo.Pizza.AuthorizationLayer.Interfaces.Implementations;
using Landeeyo.Pizza.Common.Models.AccountControl;
using Landeeyo.Pizza.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Landeeyo.Pizza.Controllers
{
    public class AccountControlController : Controller
    {
        IUnitOfWork _unitOfWork;
        IDataAccess _dataAccess;
        IAccountControl _controller;

        public AccountControlController()
        {
            //TODO This should be DI container managed
            _unitOfWork = new UnitOfWork();
            _dataAccess = new SQLDataAccess(_unitOfWork);
            _controller = new SimpleAccountControl(_dataAccess);
        }

        //
        // GET: /AccountControl/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        //
        // POST: /AccountControl/
        [HttpPost]
        public ActionResult Index(string s)
        {
            return View();
        }

        //
        // GET: /AccountControl/Register
        [HttpGet]
        public ActionResult Register(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        
        //
        // POST: /AccountControl/Register

        [HttpPost]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                _controller.AddUser(model);
                _controller.Save();
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

    }
}
