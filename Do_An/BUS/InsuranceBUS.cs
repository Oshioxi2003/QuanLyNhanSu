using DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class InsuranceBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        public static void GetDataLk(RepositoryItemLookUpEdit lk)
        {
            lk.DataSource = from item in db.Insurances select item;
            lk.DisplayMember = "name";
            lk.ValueMember = "id";
        }
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Insurances select item).ToList();
            gv.DataSource = Support.ToDataTable<Insurance>(lst);
        }
        public static int Insert(Insurance model)
        {
            if (db.Insurances.FirstOrDefault(x => x.name.ToLower() == model.name.ToLower() && x.staffId == model.staffId) != null)
                return 0;
            try
            {
                db.Insurances.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Insurance model)
        {
            if (db.Insurances.FirstOrDefault(x => x.id != model.id && x.name.ToLower() == model.name.ToLower() && x.staffId == model.staffId) != null)
                return 0;
            var modelUpdate = db.Insurances.SingleOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.name = model.name;
                modelUpdate.startDate = model.startDate;
                modelUpdate.endDate = model.endDate;
                modelUpdate.money = model.money;
                modelUpdate.Staff = db.Staffs.Single(x => x.id == model.staffId);
                modelUpdate.staffId = model.staffId;
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
                var model = db.Insurances.SingleOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Insurances.DeleteOnSubmit(model);
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
