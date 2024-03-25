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
    public class StaffBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        public static void GetDataLk(RepositoryItemLookUpEdit lk)
        {
            lk.DataSource = from item in db.Staffs select item;
            lk.DisplayMember = "name";
            lk.ValueMember = "id";
        }
        public static void GetDataGV(GridControl gv)
        {
            var lst = (from item in db.Staffs select item).ToList();
            gv.DataSource = Support.ToDataTable<Staff>(lst);
        }
        public static int Insert(Staff model)
        {
            try
            {
                db.Staffs.InsertOnSubmit(model);
                db.SubmitChanges();
                return 1;
            }
            catch (Exception ex)
            {

                return -1;
            }

        }
        public static int Update(Staff model)
        {
            var modelUpdate = db.Staffs.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.name = model.name;
                modelUpdate.image = model.image;
                modelUpdate.phone = model.phone;
                modelUpdate.Position = db.Positions.SingleOrDefault(x => x.id == model.positionId);
                modelUpdate.positionId = model.positionId;
                modelUpdate.Contract = db.Contracts.SingleOrDefault(x => x.id == model.contractId);
                modelUpdate.contractId = model.contractId;
                modelUpdate.Level = db.Levels.SingleOrDefault(x => x.id == model.levelId);
                modelUpdate.levelId = model.levelId;
                modelUpdate.Department = db.Departments.SingleOrDefault(x => x.id == model.departmentId);
                modelUpdate.departmentId = model.departmentId;
                modelUpdate.address = model.address;
                modelUpdate.dateOfBirth = model.dateOfBirth;
                modelUpdate.dateOfWork = model.dateOfWork;
                modelUpdate.sex = model.sex;
                modelUpdate.identityCard = model.identityCard;
                modelUpdate.status = model.status;
                if (model.englishLevelId != null)
                {
                    modelUpdate.EnglishLevel = db.EnglishLevels.Single(x => x.id == model.englishLevelId);
                    modelUpdate.englishLevelId = model.englishLevelId;
                }
                if (model.itLevelId != null)
                {
                    modelUpdate.ITLevel = db.ITLevels.Single(x => x.id == model.itLevelId);
                    modelUpdate.itLevelId = model.itLevelId;
                }
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
                var model = db.Staffs.FirstOrDefault(x => x.id == id);
                if (model == null)
                    return -1;
                db.Staffs.DeleteOnSubmit(model);
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
