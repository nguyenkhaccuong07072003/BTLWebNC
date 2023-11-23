﻿using DCCofee.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DCCofee.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        QLQCFEntities db = new QLQCFEntities();
        // GET: Admin/User
        public ActionResult Index()
        {
            List<NguoiDung> user = db.NguoiDung.ToList();
            return View(user);
        }
    }
}