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
using DevExpress.XtraPrinting;

namespace GUI.UC
{
    public partial class uc_staff : DevExpress.XtraEditors.XtraUserControl
    {
        private frmMain frm;
        private ImageCollection images = new ImageCollection(); //{ ImageSize=new Size(20, 20) };
        private OpenFileDialog open;
        public uc_staff(frmMain frm)
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
            StaffBUS.GetDataGV(gcStaff);
            AccountBUS.GetDataGV(gcAccount);
            RoleBUS.GetDataLk(lkRole);
            StaffBUS.GetDataLk(lkStaff);
            RoleBUS.GetDataGV(gcRole);
            ContractBUS.GetDataLk(lkContract);
            PositionBUS.GetDataLk(lkPosition);
            DepartmentBUS.GetDataLk(lkDepartment);
            ITLevelBUS.GetDataLk(lkITLevel);
            LevelBUS.GetDataLk(lkLevel);
            EnglishLevelBUS.GetDataLk(lkEnglishLevel);
            gvStaff.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvAccount.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
            gvRole.IndicatorWidth = 50;
            gvAccount.IndicatorWidth = 50;
            gvStaff.IndicatorWidth = 50;
        }
        #region nhân viên       
        //load hình ảnh
        private void gvStaff_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.Column.FieldName == "image")
            {

                try
                {

                    Image img = Image.FromFile("../../Images/" + gvStaff.GetDataRow(e.RowHandle)["image"].ToString());
                    images.Images.Clear();
                    images.Images.Add(img);
                }
                catch (Exception ex)
                {

                    Image img = Image.FromFile("../../Images/loadImg.png");
                    images.Images.Clear();
                    //    images.ImageSize = new Size(100, 100);

                    images.Images.Add(img);
                }

                imageStaff.Images = images;
            }
        }
        //thay đổi hình ảnh nhân viên
        private void imageStaff_Click(object sender, EventArgs e)
        {
            open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(open.FileName);
                if (!File.Exists("../../Images/" + open.SafeFileName))
                {
                    pictureBox1.Image.Save("../../Images/" + open.SafeFileName);
                }
                try
                {
                    DataRow dr = gvStaff.GetFocusedDataRow();
                    var model = new Staff
                    {
                        id = int.Parse(dr["id"].ToString().Trim()),
                        name = dr["name"].ToString().Trim(),
                        address = dr["address"].ToString().Trim(),
                        identityCard = dr["address"].ToString().Trim(),
                        image = open.SafeFileName,
                        dateOfBirth = DateTime.Parse(dr["dateOfBirth"].ToString().Trim()),
                        phone = dr["phone"].ToString().Trim(),
                        contractId = int.Parse(dr["contractId"].ToString().Trim()),
                        dateOfWork = DateTime.Parse(dr["dateOfWork"].ToString().Trim()),
                        departmentId = int.Parse(dr["departmentId"].ToString().Trim()),
                        englishLevelId = dr["englishLevelId"].ToString().Trim() == "" ? null : (int?)int.Parse(dr["englishLevelId"].ToString().Trim()),
                        itLevelId = dr["itLevelId"].ToString().Trim() == "" ? null : (int?)int.Parse(dr["itLevelId"].ToString().Trim()),
                        levelId = int.Parse(dr["levelId"].ToString().Trim()),
                        positionId = int.Parse(dr["positionId"].ToString().Trim()),
                        sex = bool.Parse(dr["sex"].ToString().Trim()),
                        status = bool.Parse(dr["status"].ToString().Trim()),

                    };
                    int i = StaffBUS.Update(model);
                    if (i == 1)
                        StaffBUS.GetDataGV(gcStaff);
                    else
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    open = null;
                }
                catch (Exception ex)
                {

                }
            }
        }
        //phím delete xoá nhân viên
        private void gcStaff_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvStaff.State != GridState.Editing)
            {
                DataRow dr = gvStaff.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá nhân viên " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        int i = StaffBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            StaffBUS.GetDataGV(gcStaff);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //ngăn ko cho chuyển dòng khi sai dữ liệu nhân viên
        private void gvStaff_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa dữ liệu nhân viên
        private void gvStaff_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvStaff.GetRowCellValue(e.RowHandle, "name").ToString().Trim() == "")
            {
                bVali = false;
                sErr = "Vui lòng điền tên nhân viên.\n";
            }

            if (gvStaff.GetRowCellValue(e.RowHandle, "phone").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền số điện thoại.\n";
            }

            if (gvStaff.GetRowCellValue(e.RowHandle, "address").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền địa chỉ.\n";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "dateOfBirth").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền ngày sinh.\n";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "dateOfWork").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền ngày vào làm.\n";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "identityCard").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng điền căn cước công dân.\n";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "contractId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn hợp đồng.";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "positionId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn chức vụ.";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "departmentId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn phòng ban.";
            }
            if (gvStaff.GetRowCellValue(e.RowHandle, "levelId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn trình độ.";
            }

            if (bVali)
            {
                if (DateTime.Parse(gvStaff.GetRowCellValue(e.RowHandle, "dateOfBirth").ToString()) >= DateTime.Now)
                {
                    bVali = false;
                    sErr += "Ngày sinh phải nhở hơn ngày hiện tại.";
                }
                if (DateTime.Parse(gvStaff.GetRowCellValue(e.RowHandle, "dateOfWork").ToString()) >= DateTime.Now)
                {
                    bVali = false;
                    sErr += "Ngày vào làm phải nhở hơn ngày hiện tại.";
                }
                if (!bVali)
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
                        var model = new Staff
                        {
                            sex = gvStaff.GetRowCellValue(e.RowHandle, "sex") == null || gvStaff.GetRowCellValue(e.RowHandle, "sex").ToString() == "" ? false : bool.Parse(gvStaff.GetRowCellValue(e.RowHandle, "sex").ToString().Trim()),
                            status = gvStaff.GetRowCellValue(e.RowHandle, "status") == null || gvStaff.GetRowCellValue(e.RowHandle, "status").ToString() == "" ? false : bool.Parse(gvStaff.GetRowCellValue(e.RowHandle, "status").ToString().Trim()),
                            name = gvStaff.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            address = gvStaff.GetRowCellValue(e.RowHandle, "address").ToString().Trim(),
                            image = open == null || open.SafeFileName == null ? gvStaff.GetRowCellValue(e.RowHandle, "image").ToString() : open.SafeFileName,
                            dateOfBirth = DateTime.Parse(gvStaff.GetRowCellValue(e.RowHandle, "dateOfBirth").ToString().Trim()),
                            positionId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "positionId").ToString().Trim()),
                            levelId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "levelId").ToString().Trim()),
                            departmentId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "departmentId").ToString().Trim()),
                            dateOfWork = DateTime.Parse(gvStaff.GetRowCellValue(e.RowHandle, "dateOfWork").ToString().Trim()),
                            contractId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "contractId").ToString().Trim()),
                            itLevelId = gvStaff.GetRowCellValue(e.RowHandle, "itLevelId") == null || gvStaff.GetRowCellValue(e.RowHandle, "itLevelId").ToString() == "" ? null : (int?)int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "itLevelId").ToString().Trim()),
                            englishLevelId = gvStaff.GetRowCellValue(e.RowHandle, "englishLevelId") == null || gvStaff.GetRowCellValue(e.RowHandle, "englishLevelId").ToString() == "" ? null : (int?)int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "englishLevelId").ToString().Trim()),
                            phone = gvStaff.GetRowCellValue(e.RowHandle, "phone").ToString().Trim(),
                            identityCard = gvStaff.GetRowCellValue(e.RowHandle, "identityCard").ToString().Trim(),

                        };
                        int i = StaffBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    StaffBUS.GetDataGV(gcStaff);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Staff
                        {
                            id = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            sex = gvStaff.GetRowCellValue(e.RowHandle, "sex") == null || gvStaff.GetRowCellValue(e.RowHandle, "sex").ToString() == "" ? false : bool.Parse(gvStaff.GetRowCellValue(e.RowHandle, "sex").ToString().Trim()),
                            status = gvStaff.GetRowCellValue(e.RowHandle, "status") == null || gvStaff.GetRowCellValue(e.RowHandle, "status").ToString() == "" ? false : bool.Parse(gvStaff.GetRowCellValue(e.RowHandle, "status").ToString().Trim()),
                            name = gvStaff.GetRowCellValue(e.RowHandle, "name").ToString().Trim(),
                            address = gvStaff.GetRowCellValue(e.RowHandle, "address").ToString().Trim(),
                            image = open == null || open.SafeFileName == null ? gvStaff.GetRowCellValue(e.RowHandle, "image").ToString() : open.SafeFileName,
                            dateOfBirth = DateTime.Parse(gvStaff.GetRowCellValue(e.RowHandle, "dateOfBirth").ToString().Trim()),
                            positionId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "positionId").ToString().Trim()),
                            levelId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "levelId").ToString().Trim()),
                            departmentId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "departmentId").ToString().Trim()),
                            dateOfWork = DateTime.Parse(gvStaff.GetRowCellValue(e.RowHandle, "dateOfWork").ToString().Trim()),
                            contractId = int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "contractId").ToString().Trim()),
                            itLevelId = gvStaff.GetRowCellValue(e.RowHandle, "itLevelId") == null || gvStaff.GetRowCellValue(e.RowHandle, "itLevelId").ToString() == "" ? null : (int?)int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "itLevelId").ToString().Trim()),
                            englishLevelId = gvStaff.GetRowCellValue(e.RowHandle, "englishLevelId") == null || gvStaff.GetRowCellValue(e.RowHandle, "englishLevelId").ToString() == "" ? null : (int?)int.Parse(gvStaff.GetRowCellValue(e.RowHandle, "englishLevelId").ToString().Trim()),
                            phone = gvStaff.GetRowCellValue(e.RowHandle, "phone").ToString().Trim(),
                            identityCard = gvStaff.GetRowCellValue(e.RowHandle, "identityCard").ToString().Trim(),
                        };
                        i = StaffBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    StaffBUS.GetDataGV(gcStaff);

                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //đánh số thứ tự bảng nhân viên
        private void gvStaff_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        #endregion        
        #region quyền
        //đánh số thứ tự
        private void gvRole_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }

        #endregion
        #region tài khoản
        //phím delete
        private void gcAccount_ProcessGridKey(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete && gvAccount.State != GridState.Editing)
            {
                DataRow dr = gvAccount.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá tài khoản " + dr["username"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        if (frm.account.id == id)
                        {
                            XtraMessageBox.Show("Tài khoản đang đăng nhập không được phép xoá.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        int i = AccountBUS.Delete(id);
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            AccountBUS.GetDataGV(gcAccount);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
        }
        //đánh số thứ tự
        private void gvAccount_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            if (!e.Info.IsRowIndicator || e.RowHandle < 0)
                return;
            e.Info.DisplayText = (e.RowHandle + 1) + "";
        }
        //en || disable các cột tương ứng
        private void gvAccount_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            //dòng mới:<0 
            var check = e.FocusedRowHandle < 0;
            colUsername.OptionsColumn.AllowEdit = colStaff.OptionsColumn.AllowEdit = check;
        }
        //ngăn không cho chuyển dữ liệu
        private void gvAccount_InvalidRowException(object sender, InvalidRowExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.NoAction;
        }
        //thêm sửa
        private void gvAccount_ValidateRow(object sender, ValidateRowEventArgs e)
        {
            string sErr = "";
            bool bVali = true;
            if (gvAccount.GetRowCellValue(e.RowHandle, "roleId").ToString() == "")
            {
                bVali = false;
                sErr += "Vui lòng chọn quyền.";
            }
            if (bVali)
            {

                //thêm mới
                if (e.RowHandle < 0)
                {
                    if (gvAccount.GetRowCellValue(e.RowHandle, "username").ToString() == "")
                    {
                        bVali = false;
                        sErr += "Vui lòng điền tài khoản.";
                    }
                    if (gvAccount.GetRowCellValue(e.RowHandle, "staffId").ToString() == "")
                    {
                        bVali = false;
                        sErr += "Vui lòng chọn nhân viên.";
                    }
                    if (!bVali)
                    {
                        e.Valid = false;
                        XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    try
                    {
                        var model = new Account
                        {
                            username = gvAccount.GetRowCellValue(e.RowHandle, "username").ToString().Trim(),
                            roleId = int.Parse(gvAccount.GetRowCellValue(e.RowHandle, "roleId").ToString().Trim()),
                            staffId = int.Parse(gvAccount.GetRowCellValue(e.RowHandle, "staffId").ToString().Trim()),

                        };
                        int i = AccountBUS.Insert(model);
                        open = null;
                        if (i == 1)
                            XtraMessageBox.Show("Thêm thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (i == 0)
                            XtraMessageBox.Show("Trùng tên tài khoản.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else if (i == -2)
                            XtraMessageBox.Show("Nhân viên này đã có tài khoản rồi.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                    catch (Exception ex)
                    {

                    }
                    AccountBUS.GetDataGV(gcAccount);
                }
                //sửa 
                else
                {
                    int i = -1;
                    try
                    {
                        var model = new Account
                        {
                            id = int.Parse(gvAccount.GetRowCellValue(e.RowHandle, "id").ToString().Trim()),
                            roleId = int.Parse(gvAccount.GetRowCellValue(e.RowHandle, "roleId").ToString().Trim()),
                        };
                        i = AccountBUS.Update(model);
                        open = null;
                    }
                    catch (Exception)
                    {

                    }
                    if (i == -1)
                        XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    AccountBUS.GetDataGV(gcAccount);

                }
            }
            else
            {

                e.Valid = false;

                XtraMessageBox.Show(sErr, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
        #region nhân viên, tài khoản, quyền
        //xoá
        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 0)
            {
                DataRow dr = gvStaff.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá nhân viên " + dr["name"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = StaffBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            StaffBUS.GetDataGV(gcStaff);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }
            else if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                DataRow dr = gvAccount.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn xoá tài khoản " + dr["username"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        int i = AccountBUS.Delete(int.Parse(dr["id"].ToString()));
                        if (i == 1)
                        {
                            XtraMessageBox.Show("Xoá thành công", "Thông báo");
                            AccountBUS.GetDataGV(gcAccount);
                        }
                        else
                            XtraMessageBox.Show("Có lỗi xảy ra.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
            }

        }
        //reset mật khẩu
        private void btnReset_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPageIndex == 1)
            {
                DataRow dr = gvAccount.GetFocusedDataRow();
                if (dr != null)
                {
                    if (XtraMessageBox.Show("Bạn có muốn reset mật khẩu tài khoản " + dr["username"].ToString() + " ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        int id = int.Parse(dr["id"].ToString());
                        int i = AccountBUS.ResetPassword(id);
                        if (i == 1)
                        {
                            if (id == frm.account.id)
                            {
                                XtraMessageBox.Show("Reset mật khẩu thành công. Mật khẩu mới là 12345", "Thông báo");
                                XtraMessageBox.Show("Vui lòng đăng nhập lại.", "Thông báo");
                                frm.logout(1);
                            }
                            else
                                XtraMessageBox.Show("Reset mật khẩu thành công. Mật khẩu mới là 12345", "Thông báo");
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
                string str = "nhân viên";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvStaff.ExportToXls(sf.FileName, new XlsExportOptions { SheetName = "nhân viên", ShowGridLines = true });
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvAccount.ExportToXls(sf.FileName);
                    str = "tài khoản";
                }
                else
                {
                    gvRole.ExportToXls(sf.FileName);
                    str = "quyền";
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
                string str = "nhân viên";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvStaff.ExportToDocx(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvAccount.ExportToDocx(sf.FileName);
                    str = "tài khoản";
                }
                else
                {
                    gvRole.ExportToDocx(sf.FileName);
                    str = "quyền";
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
                string str = "nhân viên";
                if (xtraTabControl1.SelectedTabPageIndex == 0)
                    gvStaff.ExportToPdf(sf.FileName);
                else if (xtraTabControl1.SelectedTabPageIndex == 1)
                {
                    gvAccount.ExportToPdf(sf.FileName);
                    str = "tài khoản";
                }
                else
                {
                    gvRole.ExportToPdf(sf.FileName);
                    str = "quyền";
                }
                XtraMessageBox.Show("Xuất file pdf " + str + " thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        #endregion
    }
}
