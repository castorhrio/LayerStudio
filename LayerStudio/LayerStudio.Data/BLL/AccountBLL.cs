using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LayerStudio.Common.Helper;
using LayerStudio.Data.DAL;
using LayerStudio.Data.Model;

namespace LayerStudio.Data.BLL
{
    public class AccountBLL
    {
        public Account user = new Account();

        public bool Insert(Account model)
        {
            model.ID = StringHelper.ConvertGuid();
            model.CreateTime = DateTime.Now;
            model.CreateBy = model.Username;
            model.UpdateBy = model.Username;
            model.UpdateTime = DateTime.Now;
            model.Status = 1;
            model.Password = StringHelper.GetMd5Str(model.Password);
            return new CommonUserDAL().Insert(model);
        }

        public bool Update(Account model)
        {
            return new CommonUserDAL().Update(model);
        }

        public bool ChangePwd(Account model)
        {
            var user = new CommonUserDAL().GetUser(model.ID);
            if (user != null)
            {
                user.Password = StringHelper.GetMd5Str(model.Password);
                return new CommonUserDAL().Update(user);
            }

            return false;
        }

        public bool VerifyAccount(string account)
        {
            return new CommonUserDAL().VerifyAccount(account);
        }

        public bool VerifyPassword(string account, string pwd)
        {
            CommonUserDAL dal = new CommonUserDAL();
            user = dal.GetUserByAccount(account);
            if (user != null)
            {
                var md5 = StringHelper.GetMd5Str(pwd);
                if (user.Password == md5)
                {
                    return true;
                }
            }

            return false;
        }

        public Account GetUser(string account)
        {
            return new CommonUserDAL().GetUserByAccount(account);
        }
    }
}
