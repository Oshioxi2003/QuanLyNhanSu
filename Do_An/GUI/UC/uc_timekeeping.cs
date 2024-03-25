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

namespace GUI.UC
{
    public partial class uc_timekeeping : DevExpress.XtraEditors.XtraUserControl
    {
        frmMain frm;
        public uc_timekeeping(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;
        }
        //load form khi chạy lần đầu
        private void uc_order_employee_Load(object sender, EventArgs e)
        {
            TimekeepingBUS.GetDataGV(gcTimekeeping, dtpTimekeeping.Value);
            gvTimekeeping.IndicatorWidth = 50;
        }
        //đóng user control
        private void btnClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }
        private void dtpTimekeeping_ValueChanged(object sender, EventArgs e)
        {
            var date = dtpTimekeeping.Value;
            if (date > DateTime.Now)
            {
                XtraMessageBox.Show("Ngày chấm công phải nhỏ hơn ngày hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            TimekeepingBUS.GetDataGV(gcTimekeeping, date);
        }
        //đánh số thứ tự
        private void gvTimekeeping_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        private void gvTimekeeping_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            //sửa 
            if (e.RowHandle >= 0)
            {
                int i = -1;
                try
                {
                    var model = new Timekeeping
                    {
                        id = int.Parse(gvTimekeeping.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                        status = bool.Parse(gvTimekeeping.GetRowCellValue(e.RowHandle, "status").ToString().Trim()),
                    };
                    i = TimekeepingBUS.Update(model);
                }
                catch (Exception)
                {

                }
                TimekeepingBUS.GetDataGV(gcTimekeeping, dtpTimekeeping.Value);
            }
        }

        private void btnPrint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            var list = TimekeepingBUS.GetList(dtpTimekeeping.Value);
            if (list.Count != 0)
            {
                var rp = new rpTimekeeping();
                rp.DataSource = list;
                rp.lbNguoiLap.Value = frm.account.Staff.name;
                rp.lbTitle.Value = "Ngày: " + dtpTimekeeping.Value.ToShortDateString();
                rp.lbDatePrint.Value = DateTime.Now;
                rp.ShowPreviewDialog();
            }
        }
    }
}
