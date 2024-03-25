using DAO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public static class SalaryBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();
        public static void ClearCache(this ManagementHRMDataContext context)
        {
            const BindingFlags FLAGS = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
            var method = context.GetType().GetMethod("ClearCache", FLAGS);
            method.Invoke(context, null);
        }
        public static void GetDataGV(GridControl gv, int month, int year)
        {
            InsertRangeByMonthYear(month, year);
            var lst = (from item in db.Salaries where item.month == month && item.year == year select item).ToList();
            gv.DataSource = Support.ToDataTable<Salary>(lst);
        }
        public static List<Salary> GetList(int month, int year)
        {
            return db.Salaries.Where(item => item.month == month && item.year == year).ToList();
        }
        private static void InsertRangeByMonthYear(int month, int year)
        {
            var date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            var list = db.Salaries.Where(x => x.month == month && x.year == year);
            var salaries = new List<Salary>();
            var staffs = db.Staffs.Where(x => x.status == true).ToList();
            foreach (var staff in staffs)
            {
                var numberOfWorkDay = staff.Timekeepings.Where(x => x.createDate.Value.Month == month && x.createDate.Value.Year == year && x.status == true).Count();
                if (numberOfWorkDay > 0)
                    salaries.Add(new Salary
                    {
                        createDate = date,
                        allowance = staff.Contract.allowance,
                        basicSalary = staff.Contract.basicSalary,
                        departmentId = staff.departmentId,
                        moneyInsurance = staff.Insurances.Where(x => x.endDate >= date).Sum(x => x.money),
                        moneyPunish = staff.Punishes.Where(x => x.createDate.Value.Month == month && x.createDate.Value.Year == year).Sum(x => x.money),
                        moneyReward = staff.Rewards.Where(x => x.createDate.Value.Month == month && x.createDate.Value.Year == year).Sum(x => x.money),
                        month = month,
                        year = year,
                        staffId = staff.id,
                        numberOfWorkDay = numberOfWorkDay
                    });
            }
            db.Salaries.DeleteAllOnSubmit(list);
            db.SubmitChanges();
            ClearCache(db);
            db.Salaries.InsertAllOnSubmit(salaries);
            db.SubmitChanges();
        }
    }
}
