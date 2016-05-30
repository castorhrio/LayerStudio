using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace LayerStudio.Models
{
    public class AccountModel
    {
        public string UserName { get; set; }


        public string PassWord { get; set; }

        public string VerifyCode { get; set; }
    }

    public class RegisterModel
    {
        [RegularExpression(@"(^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$)|(^1\d{10}$)"
, ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">账号格式不正确</span>")]
        [Remote("ValidateAccount", "Account", ErrorMessage = "<span class=\"tishi\"><img src=\"/Themes/image/tishi.png\" />该账号已注册</span>")]
        public string Account { get; set; }

        public string NickName { get; set; }

        public string PassWord { get; set; }

        public string ConfirmPwd { get; set; }

        public string Code { get; set; }
    }
}