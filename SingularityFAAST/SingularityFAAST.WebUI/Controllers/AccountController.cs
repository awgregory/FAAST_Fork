﻿using SingularityFAAST.Core.Entities;
using SingularityFAAST.DataAccess.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SingularityFAAST.WebUI.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]

        // GET: Account
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        //A login method
        [HttpPost]
        public ActionResult LogIn(User user, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (var context = new SingularityDBContext())
                {
                    var username = user.Username;
                    var password = user.Password;

                    var userIsValid = context.UserLogIns.Any(dbUser => dbUser.Username == username
                                                                && dbUser.Password == password);

                    if (userIsValid)
                    {
                        FormsAuthentication.SetAuthCookie(user.Username, false);

                        if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "username or password is incorrect");
                    }
                }
            }

            return View(user);
        }

        //Log off method
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}