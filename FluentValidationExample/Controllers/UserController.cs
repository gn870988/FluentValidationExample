﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FluentValidationExample.Models;

namespace FluentValidationExample.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(User data)
        {
            if (ModelState.IsValid)
            {
                // To do your application logic
            }

            return View(data);
        }
    }
}