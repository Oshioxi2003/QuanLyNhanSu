using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GUI.FRM;
using DevExpress.XtraCharts;
using BUS;
using System.Data;
using System.Globalization;
using DAO;

namespace GUI.UC
{
    public partial class uc_home : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        public uc_home(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }

        private void uc_home_Load(object sender, EventArgs e)
        {
            loadRewardAndPunishMonth();
            loadStatisticalLevel();
            loadStatisticalDepartment();
            loadTopStaffSalary();
        }

        private void loadStatisticalDepartment()
        {
            Series _seri = new Series("Phòng ban", ViewType.Area);
            ChartTitle title = new ChartTitle();
            title.Text = "Số lượng nhân viên từng phòng ban";
            chartStatisticalDeparment.Titles.Add(title);
            chartStatisticalDeparment.Series.Add(_seri);
            foreach (DataRow dr in ChartBUS.loadStatisticalDepartment().Rows)
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString()));
        }

        private void loadTopStaffSalary()
        {
            int n = 5;
            Series _seri = new Series("Tiền", ViewType.Bar);
            ChartTitle title = new ChartTitle();
            title.Text = "Top " + n + " lương nhân viên tháng " + (DateTime.Now.Month - 1) + "/" + DateTime.Now.Year;
            _seri.ShowInLegend = true;
            chartTopStaffSalary.Titles.Add(title);
            chartTopStaffSalary.Series.Add(_seri);
            foreach (DataRow dr in ChartBUS.loadTopStaffSalary(n).Rows)
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString()));
            foreach (Series series in chartTopStaffSalary.Series)
            {
                series.CrosshairLabelPattern = "{A}: {V:N0}";
            }
        }

        private void loadStatisticalLevel()
        {
            Series _seri = new Series("Trình độ", ViewType.Doughnut);
            ChartTitle title = new ChartTitle();
            title.Text = "Số lượng nhân viên từng trình độ";
            chartStatisticalLevel.Titles.Add(title);
            chartStatisticalLevel.Series.Add(_seri);
            foreach (DataRow dr in ChartBUS.loadStatisticalLevel().Rows)
            {
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString().Equals("") ? "0" : dr[1].ToString()));
            }
            _seri.Label.TextPattern = "{A}: {V}";
        }

        private void loadRewardAndPunishMonth()
        {
            Series _seri = new Series("Thưởng, phạt", ViewType.Pie);
            ChartTitle title = new ChartTitle();
            title.Text = "Thưởng phạt tháng " + DateTime.Now.Month+"/"+DateTime.Now.Year;
            chartRewardPunish.Titles.Add(title);
            foreach (DataRow dr in ChartBUS.loadRewardAndPunishMonth().Rows)
                _seri.Points.Add(new SeriesPoint(dr[0].ToString(), dr[1].ToString().Equals("") ? "0" : dr[1].ToString()));
            _seri.ShowInLegend = true;
            _seri.Label.TextPattern = "{A}: {V: N0}";
            chartRewardPunish.Series.Add(_seri);
        }
    }
}
