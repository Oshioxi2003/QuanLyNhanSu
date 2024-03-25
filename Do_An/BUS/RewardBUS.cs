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
    public class RewardBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

      
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Rewards select item).ToList();
            gv.DataSource = Support.ToDataTable<Reward>(lst);
        }
        public static int Insert(Reward model)
        {
            
            try
            {
                db.Rewards.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Reward model)
        {
         
            var modelUpdate = db.Rewards.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.Staff = db.Staffs.Single(x => x.id == model.staffId);
                modelUpdate.staffId = model.staffId;
                modelUpdate.RegulationReward = db.RegulationRewards.Single(x => x.id == model.regulationRewardId);
                modelUpdate.regulationRewardId = model.regulationRewardId;
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
                var model = db.Rewards.SingleOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Rewards.DeleteOnSubmit(model);
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
