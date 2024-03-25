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
    public partial class uc_level : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_level(frmMain frm)
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
            LevelBUS.GetDataGV(gcLevel);
            ITLevelBUS.GetDataGV(gcITLevel);
            EnglishLevelBUS.GetDataGV(gcEnglishLevel);
          
            gvLevel.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvITLevel.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvEnglishLevel.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvLevel.IndicatorWidth = 50;
            gvITLevel.IndicatorWidth = 50;
            gvEnglishLevel.IndicatorWidth = 50;
        }

        #region trình độ, trình độ ngoại ngữ, trình độ tin học
        //xoá 
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                DataRow dr = gvLevel.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá trình độ " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = LevelBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            LevelBUS.GetDataGV(gcLevel);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                DataRow dr = gvEnglishLevel.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá trình độ ngoại ngữ " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = EnglishLevelBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            EnglishLevelBUS.GetDataGV(gcEnglishLevel);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                DataRow dr = gvITLevel.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá trình độ tin học " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = ITLevelBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            ITLevelBUS.GetDataGV(gcITLevel);
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
                string str = "trình độ";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvLevel.ExportToXls(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvEnglishLevel.ExportToXls(sf.FileName);
                    str = "trình độ ngoại ngữ";
                }
                else 
                {
                    gvITLevel.ExportToXls(sf.FileName);
                    str = "trình độ tin học";
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
                string str = "trình độ";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvLevel.ExportToDocx(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvEnglishLevel.ExportToDocx(sf.FileName);
                    str = "trình độ ngoại ngữ";
                }
                else
                {
                    gvITLevel.ExportToDocx(sf.FileName);
                    str = "trình độ tin học";
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
                string str = "trình độ";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvLevel.ExportToPdf(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvEnglishLevel.ExportToPdf(sf.FileName);
                    str = "trình độ ngoại ngữ";
                }
                else
                {
                    gvITLevel.ExportToPdf(sf.FileName);
                    str = "trình độ tin học";
                }
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion
        #region trình độ
        //phím delete xoá
        private void gcLevel_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvLevel.State != GridState.Editing)
            {
                DataRow dr = gvLevel.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá trình độ " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = LevelBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            LevelBUS.GetDataGV(gcLevel);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvLevel_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvLevel_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvLevel_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên trình độ.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new Level
                        {
                            name = gvLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                        };
                        int i = LevelBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        if (i == 0)
                            XtraMessageBox.Show("Trùng tên trình độ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    LevelBUS.GetDataGV(gcLevel);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Level
                        {
                            id = int.Parse(gvLevel.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),

                        };
                        i = LevelBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (i == 0)
                        XtraMessageBox.Show("Trùng tên trình độ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    LevelBUS.GetDataGV(gcLevel);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region trình độ ngoại ngữ
        //phím delete xoá
        private void gcEnglishLevel_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvEnglishLevel.State != GridState.Editing)
            {
                DataRow dr = gvEnglishLevel.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá trình độ ngoại ngữ" + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = EnglishLevelBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            EnglishLevelBUS.GetDataGV(gcEnglishLevel);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvEnglishLevel_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvEnglishLevel_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvEnglishLevel_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvEnglishLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên trình độ ngoại ngữ.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new EnglishLevel
                        {
                            name = gvEnglishLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                        };
                        int i = EnglishLevelBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        if (i == 0)
                            XtraMessageBox.Show("Trùng tên trình độ ngoại ngữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    EnglishLevelBUS.GetDataGV(gcEnglishLevel);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new EnglishLevel
                        {
                            id = int.Parse(gvEnglishLevel.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvEnglishLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),

                        };
                        i = EnglishLevelBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (i == 0)
                        XtraMessageBox.Show("Trùng tên trình độ ngoại ngữ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    EnglishLevelBUS.GetDataGV(gcEnglishLevel);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region trình độ tin học
        //phím delete xoá
        private void gcITLevel_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvITLevel.State != GridState.Editing)
            {
                DataRow dr = gvITLevel.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá trình độ tin học" + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = ITLevelBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            ITLevelBUS.GetDataGV(gcITLevel);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvITLevel_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvITLevel_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvITLevel_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvITLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên trình độ tin học.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new ITLevel
                        {
                            name = gvITLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                        };
                        int i = ITLevelBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                        if (i == 0)
                            XtraMessageBox.Show("Trùng tên trình độ tin học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    ITLevelBUS.GetDataGV(gcITLevel);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new ITLevel
                        {
                            id = int.Parse(gvITLevel.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            name = gvITLevel.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),

                        };
                        i = ITLevelBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    else
                        if (i == 0)
                        XtraMessageBox.Show("Trùng tên trình độ tin học.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    ITLevelBUS.GetDataGV(gcITLevel);
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
