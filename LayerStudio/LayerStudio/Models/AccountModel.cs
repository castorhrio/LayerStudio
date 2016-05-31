using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace LayerStudio.Models
{
    public class AccountModel
    {
        [Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入用户名</span>")]
        [RegularExpression(@"(^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$)|(^1\d{10}$)"
, ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">手机号或邮箱格式不对</span>")]
        [Remote("VarifyAccount", "Account", ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">该账号已注册</span>")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入密码</span>")]
        public string PassWord { get; set; }

        public string VerifyCode { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入手机号或邮箱</span>")]
        [RegularExpression(@"(^[a-z0-9]+([._\\-]*[a-z0-9])*@([a-z0-9]+[-a-z0-9]*[a-z0-9]+.){1,63}[a-z0-9]+$)|(^1\d{10}$)"
, ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">手机号或邮箱格式不对</span>")]
        [Remote("ValidateAccount", "Account", ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">该账号已注册</span>")]
        public string Account { get; set; }

        //[Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入昵称</span>")]
        //public string NickName { get; set; }

        [Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入密码</span>")]
        [Remote("ValidatePassword", "Account", ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">密码6-20位，由字母，数字和符号组合</span>")]
        [DataType(DataType.Password)]
        public string PassWord { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("PassWord", ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">密码输入不一致</span>")]
        [Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入确认密码</span>")]
        [DataType(DataType.Password)]
        public string ConfirmPwd { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "<span><img src=\"/Themes/img/tishi.png\">请输入验证码</span>")]
        [DisplayName("验证码")]
        public string Code { get; set; }
    }
}