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
    public partial class uc_punish : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_punish(frmMain frm)
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
            PunishBUS.GetDataGV(gcPunish);
            RegulationPunishBUS.GetDataGV(gcRegulationPunish);
            RegulationPunishBUS.GetDataLk(lkRegulationPunish);
            StaffBUS.GetDataLk(lkStaff);

            gvPunish.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvRegulationPunish.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvPunish.IndicatorWidth = 50;
            gvRegulationPunish.IndicatorWidth = 50;
        }

        #region phạt, quy định phạt
        //xoá 
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                DataRow dr = gvRegulationPunish.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá quy định phạt " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = RegulationPunishBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            RegulationPunishBUS.GetDataGV(gcRegulationPunish);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
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
                string str = "phạt";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvPunish.ExportToXls(sf.FileName);
                else
                {
                    gvRegulationPunish.ExportToXls(sf.FileName);
                    str = "quy định phạt";
                }
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
                string str = "phạt";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvPunish.ExportToDocx(sf.FileName);
                else
                {
                    gvRegulationPunish.ExportToDocx(sf.FileName);
                    str = "quy định phạt";
                }
                XtraMessageBox.Show("Xuất file word " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
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
                string str = "phạt";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvPunish.ExportToPdf(sf.FileName);
                else
                {
                    gvRegulationPunish.ExportToPdf(sf.FileName);
                    str = "quy định phạt";
                }
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

        #region quy định phạt
        //phím delete xoá
        private void gcRegulationPunish_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvRegulationPunish.State != GridState.Editing)
            {
                DataRow dr = gvRegulationPunish.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá quy định phạt " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = RegulationPunishBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            RegulationPunishBUS.GetDataGV(gcRegulationPunish);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvRegulationPunish_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvRegulationPunish_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvRegulationPunish_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvRegulationPunish.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên quy định.\n";
            }
            if (gvRegulationPunish.GetRowCellValue(e.RowHandle, "money").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tiền phạt.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new RegulationPunish
                        {
                            name = gvRegulationPunish.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            money = double.Parse(gvRegulationPunish.GetRowCellValue(e.RowHandle, "money").ToString().Trim()),
                        };
                        int i = RegulationPunishBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        if (i == 0)
                            XtraMessageBox.Show("Trùng tên quy định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    RegulationPunishBUS.GetDataGV(gcRegulationPunish);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new RegulationPunish
                        {
                            id = int.Parse(gvRegulationPunish.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            money = double.Parse(gvRegulationPunish.GetRowCellValue(e.RowHandle, "money").ToString().Trim()),
                            name = gvRegulationPunish.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                        };
                        i = RegulationPunishBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (i == 0)
                        XtraMessageBox.Show("Trùng tên quy định.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    RegulationPunishBUS.GetDataGV(gcRegulationPunish);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region phạt      
        //đánh số thứ tự
        private void gvPunish_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvPunish_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvPunish_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvPunish.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn nhân viên.\n";
            }
            if (gvPunish.GetRowCellValue(e.RowHandle, "mission").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền lý do.\n";
            }
            if (gvPunish.GetRowCellValue(e.RowHandle, "regulationPunishId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn mức phạt.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    var regulationPunishId = int.Parse(gvPunish.GetRowCellValue(e.RowHandle, "regulationPunishId").ToString().Trim());
                    try
                    {
                        var model = new Punish
                        {
                            regulationPunishId = regulationPunishId,
                            money = RegulationPunishBUS.FindById(regulationPunishId).money,
                            createDate = DateTime.Now,
                            mission = gvPunish.GetRowCellValue(e.RowHandle, "mission").ToString().Trim(),
                            note = gvPunish.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                            staffId = int.Parse(gvPunish.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),
                        };
                        int i = PunishBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                        
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    PunishBUS.GetDataGV(gcPunish);
                }
                //sửa 
                else
                {
                    int i = -1;
                    var regulationPunishId = int.Parse(gvPunish.GetRowCellValue(e.RowHandle, "regulationPunishId").ToString().Trim());
                    try
                    {
                        var model = new Punish
                        {
                            id = int.Parse(gvPunish.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            regulationPunishId = regulationPunishId,
                            money = RegulationPunishBUS.FindById(regulationPunishId).money,
                            createDate = DateTime.Now,
                            mission = gvPunish.GetRowCellValue(e.RowHandle, "mission").ToString().Trim(),
                            note = gvPunish.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                            staffId = int.Parse(gvPunish.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),
                        };
                        i = PunishBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);                                       
                    PunishBUS.GetDataGV(gcPunish);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion




    }
}
