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
    public class TimekeepingBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        public static void GetDataGV(GridControl gv, DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day);
            InsertRangeByDate(date);
            var lst = (from item in db.Timekeepings where item.createDate.Value.CompareTo(date) == 0 select item).ToList();
            gv.DataSource = Support.ToDataTable<Timekeeping>(lst);
        }
        public static List<Timekeeping> GetList(DateTime date)
        {
            date = new DateTime(date.Year, date.Month, date.Day);
            return db.Timekeepings.Where(item => item.createDate.Value.CompareTo(date) == 0).ToList();
        }
        private static void InsertRangeByDate(DateTime date)
        {
            var list = db.Timekeepings.Where(x => x.createDate.Value.CompareTo(date) == 0).ToList();
            var timekeepings = new List<Timekeeping>();
            var staffs = db.Staffs.Where(x => x.status == true).ToList();
            foreach (var staff in staffs)
            {
                if (list.FirstOrDefault(x => x.staffId == staff.id) == null)
                    timekeepings.Add(new Timekeeping
                    {
                        createDate = date,
                        departmentId = staff.departmentId,
                        staffId = staff.id,
                        status = true,
                    });
            }

            db.Timekeepings.InsertAllOnSubmit(timekeepings);
            db.SubmitChanges();
        }
        public static int Update(Timekeeping model)
        {
            var modelUpdate = db.Timekeepings.FirstOrDefault(x => x.id == model.id);
            try
            {
                if (modelUpdate == null)
                    return -1;
                modelUpdate.status = model.status;
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
