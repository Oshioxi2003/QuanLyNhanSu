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
    public class ChartTopStaffBUS
    {
        private static ManagementHRMDataContext db = new ManagementHRMDataContext();

        public static DataTable loadTopReward(int n, bool checkType, DateTime date)
        {
            var list = from reward in db.Rewards
                       join staff in db.Staffs
                       on reward.staffId equals staff.id
                       where checkType == true ? reward.createDate.Value.Year == date.Year : reward.createDate.Value.Month == date.Month && reward.createDate.Value.Year == date.Year
                       group new { staff, reward } by new { staff.id, staff.name } into staffNew
                       orderby staffNew.Sum(x => x.reward.money) descending
                       select new { name = staffNew.Key.name, money = staffNew.Sum(x => x.reward.money) };
            return Support.ToDataTable(list.Take(n).ToList());
        }
        public static DataTable loadTopPunish(int n,bool checkType, DateTime date)
        {
            var list = from punish in db.Punishes
                       join staff in db.Staffs
                       on punish.staffId equals staff.id
                       where checkType == true ? punish.createDate.Value.Year == date.Year : punish.createDate.Value.Month == date.Month && punish.createDate.Value.Year == date.Year
                       group new { staff, punish } by new { staff.id, staff.name } into staffNew
                       orderby staffNew.Sum(x => x.punish.money) descending
                       select new { name = staffNew.Key.name, money = staffNew.Sum(x => x.punish.money) };
            return Support.ToDataTable(list.Take(n).ToList());
        }
        public static DataTable loadTopInsurance(int n, bool checkType, DateTime date)
        {
            var list = from insurance in db.Insurances
                       join staff in db.Staffs
                       on insurance.staffId equals staff.id
                       where checkType == true ? insurance.startDate.Value.Year == date.Year : insurance.startDate.Value.Month == date.Month && insurance.startDate.Value.Year == date.Year
                       group new { staff, insurance } by new { staff.id, staff.name } into staffNew
                       orderby staffNew.Sum(x => x.insurance.money) descending
                       select new { name = staffNew.Key.name, money = staffNew.Sum(x => x.insurance.money) };
            return Support.ToDataTable(list.Take(n).ToList());
        }
    }
}
