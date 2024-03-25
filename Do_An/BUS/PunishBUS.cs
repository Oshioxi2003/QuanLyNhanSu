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
    public class PunishBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Punishes select item).ToList();
            gv.DataSource = Support.ToDataTable<Punish>(lst);
        }
        public static int Insert(Punish model)
        {
            
            try
            {
                db.Punishes.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Punish model)
        {
         
            var modelUpdate = db.Punishes.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.Staff = db.Staffs.Single(x => x.id == model.staffId);
                modelUpdate.staffId = model.staffId;
                modelUpdate.RegulationPunish = db.RegulationPunishes.Single(x => x.id == model.regulationPunishId);
                modelUpdate.regulationPunishId = model.regulationPunishId;
                modelUpdate.mission = model.mission;
                modelUpdate.createDate = DateTime.Now;
                modelUpdate.money = model.money;
                modelUpdate.note = model.note;

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
                var model = db.Punishes.SingleOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Punishes.DeleteOnSubmit(model);
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
