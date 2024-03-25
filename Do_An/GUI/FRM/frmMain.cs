using DAO;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using GUI.UC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GUI.FRM
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        UserControl uc;
        public Account account;
        frmSystem frm;
        bool checkClose;
        
        public frmMain(frmSystem frm, Account account)
        {
            InitializeComponent();

            this.account = account;
            this.frm = frm;
            lbAccount.Caption = "Nhân viên: " + account.Staff.name;
            openUC(typeof(uc_home));
            checkClose = true;
            if (!account.Role.name.ToLower().Equals("admin"))
                btnManagerment.Visible = btnStatistical.Visible = btnRestore.Enabled = btnBackup.Enabled = false;
        }
        public void _close()
        {
            mainContainer.Controls.Remove(uc);
            mainContainer.BringToFront();
        }

        private void openUC(Type typeUC)
        {
            splashScreenManager1.ShowWaitForm();
            bool check = false;
            foreach (UserControl _uc in mainContainer.Controls)
            {

                if (_uc.GetType() == typeUC)
                {
                    _uc.BringToFront();
                    lbTieuDe.Caption = _uc.Tag.ToString();
                    check = true;
                    continue;
                }
                mainContainer.Controls.Remove(_uc);

            }
            if (!check)
            {
                uc = (UserControl)Activator.CreateInstance(typeUC, this);
                uc.Dock = DockStyle.Fill;
                mainContainer.Controls.Add(uc);
                uc.BringToFront();
                lbTieuDe.Caption = uc.Tag.ToString();
            }
            splashScreenManager1.CloseWaitForm();
        }       
        private void btnBackup_ItemClick(object sender, ItemClickEventArgs e)
        {
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "SQL Backup (*.bak)|*.bak";
            sf.Title = "Backup database";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                new frmBKRS(sf.FileName, 0).ShowDialog();
            }
        }

        private void btnRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "SQL Backup (*.bak)|*.bak";
            op.Title = "Restore database";
            if (op.ShowDialog() == DialogResult.OK)
            {
                new frmBKRS(op.FileName, 1).ShowDialog();

            }
        }
        public void logout(int check = 0)
        {
            checkClose = false;
            if (check == 0)
            {
                if (XtraMessageBox.Show("Bạn chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    Close();
                    frm._show();
                }
            }
            else
            {
                Close();

                frm._show();
            }
            checkClose = true;

        }
        private void btnLogout_ItemClick(object sender, ItemClickEventArgs e)
        {
            logout();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(checkClose)
            e.Cancel = true;
        }

        private void btnChangePass_ItemClick(object sender, ItemClickEventArgs e)
        {
            new frmChangePass(this, account).ShowDialog();
        }

        private void btnContract_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_contract));
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_department));

        }

        private void btnPosition_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_position));

        }

        private void btnLevel_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_level));

        }

        private void btnInsurance_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_insurance));

        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_staff));

        }

        private void btnPunish_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_punish));

        }

        private void btnReward_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_reward));
        }

        private void btnTimekeeping_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_timekeeping));
        }

        private void btnSalary_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_salary));
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_home));

        }

        private void btnRewardPunishInsurance_Click(object sender, EventArgs e)
        {
            openUC(typeof(uc_statistic_staff));
        }
    }
}
