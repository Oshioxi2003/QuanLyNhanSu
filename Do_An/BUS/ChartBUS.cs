using DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class ChartBUS
    {

        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        // thưởng phạt trong tháng hiện tại
        public static DataTable loadRewardAndPunishMonth()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("name");
            tb.Columns.Add("money");
            DataRow dr = tb.NewRow();
            dr[0] = "Thưởng";
            dr[1] = db.Punishes.Where(x => x.createDate.Value.Month == DateTime.Now.Month && x.createDate.Value.Year == DateTime.Now.Year).Sum(x => x.money);
            tb.Rows.Add(dr);
            dr = tb.NewRow();
            dr[0] = "Phạt";
            dr[1] = db.Rewards.Where(x => x.createDate.Value.Month == DateTime.Now.Month && x.createDate.Value.Year == DateTime.Now.Year).Sum(x => x.money);
            tb.Rows.Add(dr);
            return tb;
        }

        //top nhân viên nhận lương cao nhất trong tháng trước
        public static DataTable loadTopStaffSalary(int n)
        {
            int month = DateTime.Now.Month - 1;
            var list = from staff in db.Staffs
                       join salary in db.Salaries
                       on staff.id equals salary.staffId
                       where salary.month == month
                       group new { staff, salary } by new { id = staff.id, name = staff.name } into staffNew
                       orderby staffNew.Sum(x => x.salary.numberOfWorkDay * x.salary.basicSalary + x.salary.allowance + x.salary.moneyReward - x.salary.moneyPunish - x.salary.moneyInsurance) descending
                       select new { name = staffNew.Key.name, salary = staffNew.Sum(x => x.salary.numberOfWorkDay * x.salary.basicSalary + x.salary.allowance + x.salary.moneyReward - x.salary.moneyPunish - x.salary.moneyInsurance) };
            return Support.ToDataTable(list.Take(n).ToList());
        }
        //thống kê trình độ
        public static DataTable loadStatisticalLevel()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("name");
            tb.Columns.Add("quantity");
            foreach (var item in db.Levels)
            {
                DataRow dr = tb.NewRow();
                dr[0] = item.name;
                dr[1] = item.Staffs.Count;
                tb.Rows.Add(dr);
            }
            return tb;
        }
        //thống kê phòng ban
        public static DataTable loadStatisticalDepartment()
        {
            DataTable tb = new DataTable();
            tb.Columns.Add("name");
            tb.Columns.Add("quantity");
            foreach (var item in db.Departments)
            {
                DataRow dr = tb.NewRow();
                dr[0] = item.name;
                dr[1] = item.Staffs.Count;
                tb.Rows.Add(dr);
            }
            return tb;
        }
    }
}
