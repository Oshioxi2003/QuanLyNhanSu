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
    public partial class uc_reward : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_reward(frmMain frm)
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
            RewardBUS.GetDataGV(gcReward);
            RegulationRewardBUS.GetDataGV(gcRegulationReward);
            RegulationRewardBUS.GetDataLk(lkRegulationWard);
            StaffBUS.GetDataLk(lkStaff);

            gvReward.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvRegulationReward.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvReward.IndicatorWidth = 50;
            gvRegulationReward.IndicatorWidth = 50;
        }

        #region thưởng, quy định thưởng
        //xoá 
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                DataRow dr = gvRegulationReward.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá quy định thưởng " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = RegulationRewardBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            RegulationRewardBUS.GetDataGV(gcRegulationReward);
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
                string str = "thưởng";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvReward.ExportToXls(sf.FileName);
                else
                {
                    gvRegulationReward.ExportToXls(sf.FileName);
                    str = "quy định thưởng";
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
                string str = "thưởng";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvReward.ExportToDocx(sf.FileName);
                else
                {
                    gvRegulationReward.ExportToDocx(sf.FileName);
                    str = "quy định thưởng";
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
                string str = "thưởng";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvReward.ExportToPdf(sf.FileName);
                else
                {
                    gvRegulationReward.ExportToPdf(sf.FileName);
                    str = "quy định thưởng";
                }
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion

        #region quy định thưởng
        //phím delete xoá
        private void gcRegulationReward_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvRegulationReward.State != GridState.Editing)
            {
                DataRow dr = gvRegulationReward.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá quy định thưởng " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());

                        int i = RegulationRewardBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            RegulationRewardBUS.GetDataGV(gcRegulationReward);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvRegulationReward_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvRegulationReward_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvRegulationReward_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvRegulationReward.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên quy định.\n";
            }
            if (gvRegulationReward.GetRowCellValue(e.RowHandle, "money").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tiền thưởng.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    try
                    {
                        var model = new RegulationReward
                        {
                            name = gvRegulationReward.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            money = double.Parse(gvRegulationReward.GetRowCellValue(e.RowHandle, "money").ToString().Trim()),
                        };
                        int i = RegulationRewardBUS.Insert(model);
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
                    RegulationRewardBUS.GetDataGV(gcRegulationReward);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new RegulationReward
                        {
                            id = int.Parse(gvRegulationReward.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            money = double.Parse(gvRegulationReward.GetRowCellValue(e.RowHandle, "money").ToString().Trim()),
                            name = gvRegulationReward.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                        };
                        i = RegulationRewardBUS.Update(model);
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
                    RegulationRewardBUS.GetDataGV(gcRegulationReward);
                }
            }
            else
            {
                e.Valid = false;
                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region thưởng      
        //đánh số thứ tự
        private void gvReward_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //ngăn không cho chuyển dòng khi dữ liệu sai
        private void gvReward_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvReward_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvReward.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn nhân viên.\n";
            }
            if (gvReward.GetRowCellValue(e.RowHandle, "mission").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền lý do.\n";
            }
            if (gvReward.GetRowCellValue(e.RowHandle, "regulationRewardId").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng chọn mức thưởng.\n";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    var regulationRewardId = int.Parse(gvReward.GetRowCellValue(e.RowHandle, "regulationRewardId").ToString().Trim());
                    try
                    {
                        var model = new Reward
                        {
                            regulationRewardId = regulationRewardId,
                            money = RegulationRewardBUS.FindById(regulationRewardId).money,
                            createDate = DateTime.Now,
                            mission = gvReward.GetRowCellValue(e.RowHandle, "mission").ToString().Trim(),
                            note = gvReward.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                            staffId = int.Parse(gvReward.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),
                        };
                        int i = RewardBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);                        
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    RewardBUS.GetDataGV(gcReward);
                }
                //sửa 
                else
                {
                    int i = -1;
                    var regulationRewardId = int.Parse(gvReward.GetRowCellValue(e.RowHandle, "regulationRewardId").ToString().Trim());
                    try
                    {
                        var model = new Reward
                        {
                            id = int.Parse(gvReward.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            regulationRewardId = regulationRewardId,
                            money = RegulationPunishBUS.FindById(regulationRewardId).money,
                            createDate = DateTime.Now,
                            mission = gvReward.GetRowCellValue(e.RowHandle, "mission").ToString().Trim(),
                            note = gvReward.GetRowCellValue(e.RowHandle, "note").ToString().Trim(),
                            staffId = int.Parse(gvReward.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),
                        };
                        i = RewardBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    RewardBUS.GetDataGV(gcReward);
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
