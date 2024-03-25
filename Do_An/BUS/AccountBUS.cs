using DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class AccountBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();       
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Accounts select item).ToList();
            gv.DataSource = Support.ToDataTable<Account>(lst);
        }
        public static int Insert(Account model)
        {
            if (db.Accounts.SingleOrDefault(x => x.username.ToLower().Equals(model.username.ToLower())) != null)
                return 0;
            if (db.Accounts.SingleOrDefault(x => x.staffId == model.staffId) != null)
                return -2;
            try
            {
                model.password = Support.EndCodeMD5("12345");
                db.Accounts.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Account model)
        {
            var modelUpdate = db.Accounts.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.Role = db.Roles.Single(x => x.id == model.roleId);
                modelUpdate.roleId = model.roleId;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Delete(int id)
        {
            try
            {
                var model = db.Accounts.FirstOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Accounts.DeleteOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int ResetPassword(int id)
        {

            var modelUpdate = db.Accounts.FirstOrDefault(x => x.id == id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.password = Support.EndCodeMD5("12345");
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int ChangePassword(int id, string oldPass, string newPass)
        {
            oldPass = Support.EndCodeMD5(oldPass);
            newPass = Support.EndCodeMD5(newPass);
            var modelUpdate = db.Accounts.SingleOrDefault(x => x.id == id && x.password.Equals(oldPass));
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.password = newPass;
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static Account Login(string username, string password, ref int errorCode)
        {
            password = Support.EndCodeMD5(password.Trim());
            Account account = null;
            try
            {
                account = db.Accounts.SingleOrDefault(x => x.username.Trim().Equals(username.Trim()) && x.password.Equals(password));
            }
            catch (SqlException ex)
            {
                errorCode = ex.ErrorCode;
            }

            return account;
        }
    }
}
