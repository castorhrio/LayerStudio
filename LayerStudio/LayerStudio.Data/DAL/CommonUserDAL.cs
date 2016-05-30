using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using LayerStudio.Data.Model;
using LayerStudio.Logging;

namespace LayerStudio.Data.DAL
{
    public class CommonUserDAL
    {
        public bool Insert(Account model)
        {
            try
            {
                using (var entities = new LayerStudioEntities())
                {
                    entities.Accounts.Add(model);
                    return entities.SaveChanges() == 1;
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message, e);
            }
            return false;
        }

        public bool Update(Account model)
        {
            try
            {
                using (var entities = new LayerStudioEntities())
                {
                    var search = entities.Accounts.Where(a => a.Status == 1 && a.ID == model.ID);
                    if (search.Any())
                    {
                        var result = search.FirstOrDefault();
                        result.UpdateBy = model.UpdateBy;
                        result.UpdateTime = DateTime.Now;
                        result.Username = model.Username;
                        result.Sex = model.Sex;
                        result.Phone = model.Phone;
                        result.Email = model.Email;
                        return entities.SaveChanges() == 1;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message,e);
            }

            return false;
        }

        public bool ChangePassword(Account model)
        {
            try
            {
                using (var entities = new LayerStudioEntities())
                {
                    var search = entities.Accounts.Where(a => a.Status == 1 && a.ID == model.ID);
                    if (search.Any())
                    {
                        var result = search.FirstOrDefault();
                        result.Password = model.Password;
                        return entities.SaveChanges() == 1;
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message,e);
            }

            return false;
        }

        public Account GetUser(string id)
        {
            try
            {
                using (var entities = new LayerStudioEntities())
                {
                    var search = entities.Accounts.Where(a => a.Status == 1 && a.ID == id);
                    if (search.Any())
                    {
                        return search.FirstOrDefault();
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e.Message,e);
            }

            return null;
        }
    }
}
