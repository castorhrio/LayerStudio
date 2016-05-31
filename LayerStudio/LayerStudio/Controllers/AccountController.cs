using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using LayerStudio.Common.Helper;
using LayerStudio.Data.BLL;
using LayerStudio.Data.DAL;
using LayerStudio.Data.Model;
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
            if (ModelState.IsValid)
            {
                AccountBLL bll = new AccountBLL();
                if (bll.VerifyPassword(model.UserName, model.PassWord))
                {
                    return Json(new
                    {
                        Result = true,
                        Message = "登陆成功",
                        retUrl = Url.Action("Success", "Account")
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(new
            {
                Result = false,
                Message = "账号或密码错误"
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var acccountReg =
                    new Regex(@"(^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$)|(^1\d{10}$)");
                if (!acccountReg.IsMatch(model.Account))
                {
                    return Json(new
                    {
                        Result = false,
                        Message = "账号格式错误"
                    }, JsonRequestBehavior.AllowGet);
                }

                if (model.Code != Session["ValidateCode"].ToString())
                {
                    return Json(new
                    {
                        Result = false,
                        Message = "验证码错误"
                    }, JsonRequestBehavior.AllowGet);
                }

                Account user = new Account();
                //user.Username = model.NickName;
                user.Password = model.PassWord;
                user.Phone = model.Account.Contains("@") ? null:model.Account;
                user.Email = model.Account.Contains("@") ? model.Account : null;
                user.CreateBy = model.Account;
                user.UpdateBy = model.Account;

                var result = new AccountBLL().Insert(user);
                if (result)
                {
                    Session["ValidateCode"] = null;
                    return Json(new
                    {
                        Result = true,
                        Message = "注册成功",
                        retUrl = Url.Action("Login", "Account")
                    }, JsonRequestBehavior.AllowGet);
                }
            }

            return Json(new
            {
                Result = false,
                Message = "注册失败"
            }, JsonRequestBehavior.AllowGet);
        }


        public ActionResult GetValidateCode()
        {
            Captcha vCode = new Captcha();
            string code = vCode.CreateValidateCode(5);
            Session["ValidateCode"] = code;
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return File(bytes, @"image/jpeg");
        }

        public ActionResult ValidateAccount(RegisterModel model)
        {
            var user = new AccountBLL().VerifyAccount(model.Account);
            if (user)
            {
                return Json("<span><img src=\"/Themes/img/tishi.png\">该账号已注册</span>", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ValidatePassword(RegisterModel model)
        {
            if (model.PassWord.IsNullOrEmpty() || model.PassWord.Length < 6 || model.PassWord.Length > 20 ||
                !new Regex("[0-9]+?").IsMatch(model.PassWord) || !new Regex("[a-zA-Z]+?").IsMatch(model.PassWord))
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }

        public ActionResult VarifyAccount(AccountModel model)
        {
            var user = new AccountBLL().VerifyAccount(model.UserName);
            if (user)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json("<span><img src=\"/Themes/img/tishi.png\">该账号尚未注册</span>", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}