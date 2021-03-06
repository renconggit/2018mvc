﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AuthenticationController : Controller
    {
        //
        // GET: /Authentication/
        public ActionResult Login()
        {
            return View();
        }
         [HttpPost]
        public ActionResult DoLogin(UserDetails u)
        {
            EmployeeBusinessLayer bal = new EmployeeBusinessLayer();
            if (bal.IsValidUser(u))
            {
                //写cookie
                FormsAuthentication.SetAuthCookie(u.UserName,false);
                return RedirectToAction("Index", "Employee");
            }
            else {
                ModelState.AddModelError("CredentialError","Invalid Username or Password");
                return View("Login");
            }
        }
	}
}