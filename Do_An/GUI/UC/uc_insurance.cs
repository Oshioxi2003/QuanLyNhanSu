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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;
using System.IO;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraEditors.ViewInfo;
using System.Reflection;
using DevExpress.Utils.Menu;
using GUI.FRM;
using DAO;

namespace GUI.UC
{
    public partial class uc_insurance : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_insurance(frmMain frm)
        {
            InitializeComponent();
            this.frm = frm;

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frm._close();
        }

        private void uc_staff_Load(object sender, EventArgs e)
        {
            InsuranceBUS.GetDataGV(gcInsurance);
            StaffBUS.GetDataLk(lkStaff);
            gvInsurance.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvInsurance.IndicatorWidth = 50;
        }
        #region phòng ban                 
        //phím delete
        private void gcInsurance_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvInsurance.State != GridState.Editing)
            {
                DataRow dr = gvInsurance.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá bảo hiểm" + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = InsuranceBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            InsuranceBUS.GetDataGV(gcInsurance);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvInsurance_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvInsurance_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvInsurance_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvInsurance.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên bảo hiểm.\n";
            }
            if (gvInsurance.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn nhân viên.\n";
            }
            if (gvInsurance.GetRowCellValue(e.RowHandle, "startDate").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền ngày bắt đầu.\n";
            }
            if (gvInsurance.GetRowCellValue(e.RowHandle, "endDate").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền ngày kết thúc.\n";
            }
            if (gvInsurance.GetRowCellValue(e.RowHandle, "money").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tổng tiền.\n";
            }
            
            if (bVali)
            {
                var dateStart = DateTime.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "startDate").ToString().Trim());
                var dateEnd = DateTime.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "endDate").ToString().Trim());
                if (dateStart>=dateEnd)
                {
                    bVali = false;
                    sErr = "Ngày bắt đầu không được lớn hơn ngày kết thúc.\n";
                }
                if(!bVali)
                {
                    e.Valid = false;
                    XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new Insurance
                        {
                            name = gvInsurance.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            endDate = DateTime.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "endDate").ToString().Trim()),
                            startDate = DateTime.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "startDate").ToString().Trim()),
                            staffId = int.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),
                            money=double.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "money").ToString().Trim())
                        };
                        int i = InsuranceBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        if (i == 0)
                            XtraMessageBox.Show("Trùng tên bảo hiểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    InsuranceBUS.GetDataGV(gcInsurance);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Insurance
                        {
                            id = int.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvInsurance.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            endDate = DateTime.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "endDate").ToString().Trim()),
                            startDate = DateTime.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "startDate").ToString().Trim()),
                            staffId = int.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),
                            money = double.Parse(gvInsurance.GetRowCellValue(e.RowHandle, "money").ToString().Trim())
                        };
                        i = InsuranceBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (i == 0)
                        XtraMessageBox.Show("Trùng tên bảo hiểm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    InsuranceBUS.GetDataGV(gcInsurance);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //xuất ra file Pdf
        private void btnPdf_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Pdf Files (*.pdf)|*.pdf";
            sf.Title = "Xuất ra file pdf";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                string str = "bảo hiểm";
                gvInsurance.ExportToPdf(sf.FileName);
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //xoá 
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataRow dr = gvInsurance.GetFocusedDataRow();
            if (dr != null)
            {
                if (XtraMessageBox.Show("Bạn có muốn xoá bảo hiểm " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int i = InsuranceBUS.Delete(int.Parse(dr["id"].ToString()));
                    if (i == 1)
                    {
                        XtraMessageBox.Show("Xoá thành công", "Thông báo");
                        InsuranceBUS.GetDataGV(gcInsurance);
                    }
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }
        //xuất ra file excel
        private void btnExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Excel Files (*.xlsx)|*.xls";
            sf.Title = "Xuất ra file excel";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                gvInsurance.ExportToXls(sf.FileName);
                string str = "bảo hiểm";
                XtraMessageBox.Show("Xuất file excel " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        //xuất ra file word
        private void btnWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Word Files (*.docx)|*.docx";
            sf.Title = "Xuất ra file word";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                gvInsurance.ExportToDocx(sf.FileName);
                string str = "bảo hiểm";
                XtraMessageBox.Show("Xuất file word " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

       
    }
}
