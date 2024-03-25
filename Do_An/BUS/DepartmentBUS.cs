using DAO;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class DepartmentBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        public static void GetDataLk(RepositoryItemLookUpEdit lk)
        {
            lk.DataSource = from item in db.Departments select item;
            lk.DisplayMember = "name";
            lk.ValueMember = "id";
        }
        public static void GetDataLk(LookUpEdit lk)
        {
            lk.Properties.DataSource = from item in db.Departments select item;
            lk.Properties.DisplayMember = "name";
            lk.Properties.ValueMember = "id";
        }
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Departments select item).ToList();
            gv.DataSource = Support.ToDataTable<Department>(lst);
        }
        public static int Insert(Department model)
        {
            if (db.Departments.SingleOrDefault(x => x.name.ToLower().Equals(model.name.ToLower())) != null)
                return 0;
            try
            {
                db.Departments.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Department model)
        {
            if (db.Departments.SingleOrDefault(x =>x.id!=model.id&& x.name.ToLower().Equals(model.name.ToLower())) != null)
                return 0;
            var modelUpdate = db.Departments.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.name = model.name;         
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
                var model = db.Departments.SingleOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Departments.DeleteOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
    }
}
