using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LayerStudio.Common.Helper;
using LayerStudio.Data.BLL;
using LayerStudio.Models;

namespace LayerStudio.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(AccountModel model)
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult GetValidateCode()
        {
            Captcha vCode = new Captcha();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        public ActionResult ValidateAccount(RegisterModel Model)
        {
            return Json(true, JsonRequestBehavior.AllowGet);
        }
    }
}