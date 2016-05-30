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
    }
}
