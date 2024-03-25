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
using BUS;
using DAO;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.Controls;
using System.Globalization;
using GUI.FRM;
using GUI.Report;
using DevExpress.XtraReports.UI;
using DevExpress.Utils.Extensions;

namespace GUI.UC
{
    public partial class uc_salary : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        public uc_salary(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        //load form khi chạy lần đầu
        private void uc_order_employee_Load(object sender, EventArgs e)
        {
            loadCBB();
            SalaryBUS.GetDataGV(gcSalary, int.Parse(cbbMonth.SelectedItem.ToString()), int.Parse(cbbYear.SelectedItem.ToString()));
            gvSalary.IndicatorWidth = 50;
        }
        private void loadCBB()
        {
            for (int i = 1; i < 13; i++)
                cbbMonth.Properties.Items.Add(i);
            for (int i = DateTime.Now.Year; i >= 1990; i--)
                cbbYear.Properties.Items.Add(i);
            cbbMonth.SelectedIndex = 0;
            cbbYear.SelectedIndex = 0;
        }
        //đóng user control
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }
        //đánh số thứ tự
        private void gvSalary_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        private void SelectMonthYear()
        {
            try
            {
                var date = DateTime.Now;
                var month = int.Parse(cbbMonth.SelectedItem.ToString());
                var year = int.Parse(cbbYear.SelectedItem.ToString());
                if (year > date.Year)
                    XtraMessageBox.Show("Năm phải nhỏ hơn năm hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    if (month > date.Month && year == date.Year)
                    XtraMessageBox.Show("Tháng phải nhỏ hơn tháng hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    SalaryBUS.GetDataGV(gcSalary, month, year);
            }
            catch (Exception ex)
            {
                
            }
        }
        private void cbbMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMonthYear();
        }

        private void cbbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMonthYear();
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int month = int.Parse(cbbMonth.SelectedItem.ToString());
            int year = int.Parse(cbbYear.SelectedItem.ToString());
            var list = SalaryBUS.GetList(month, year);
            if (list.Count != 0)
            {
                var rp = new rpSalary();
                rp.DataSource = list;
                rp.lbNguoiLap.Value = frm.account.Staff.name;
                rp.lbTitle.Value = "Kỳ: T." + month + "/" + year;
                rp.lbDatePrint.Value = DateTime.Now;
                rp.lbDate.Value = list[0].createDate.Value;
                rp.ShowPreviewDialog();
            }
        }
    }
}
