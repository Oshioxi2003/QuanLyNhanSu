namespace GUI.UC
{
    partial class uc_level
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(uc_level));
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnExcel = new DevExpress.XtraBars.BarButtonItem();
            this.btnWord = new DevExpress.XtraBars.BarButtonItem();
            this.btnPdf = new DevExpress.XtraBars.BarButtonItem();
            this.btnDong = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.gcLevel = new DevExpress.XtraGrid.GridControl();
            this.gvLevel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage4 = new DevExpress.XtraTab.XtraTabPage();
            this.gcEnglishLevel = new DevExpress.XtraGrid.GridControl();
            this.gvEnglishLevel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage5 = new DevExpress.XtraTab.XtraTabPage();
            this.gcITLevel = new DevExpress.XtraGrid.GridControl();
            this.gvITLevel = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLevel)).BeginInit();
            this.xtraTabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcEnglishLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnglishLevel)).BeginInit();
            this.xtraTabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gcITLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvITLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnDelete,
            this.btnDong,
            this.btnExcel,
            this.btnWord,
            this.btnPdf});
            this.barManager1.MainMenu = this.bar1;
            this.barManager1.MaxItemId = 8;
            // 
            // bar1
            // 
            this.bar1.BarName = "Main menu";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnExcel, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnWord, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnPdf, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.btnDong, true)});
            this.bar1.OptionsBar.MultiLine = true;
            this.bar1.OptionsBar.UseWholeRow = true;
            this.bar1.Text = "Main menu";
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xoá";
            this.btnDelete.Id = 1;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.LargeImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnExcel
            // 
            this.btnExcel.Caption = "Xuất excel";
            this.btnExcel.Id = 5;
            this.btnExcel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.Image")));
            this.btnExcel.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnExcel.ImageOptions.LargeImage")));
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExcel_ItemClick);
            // 
            // btnWord
            // 
            this.btnWord.Caption = "Xuất word";
            this.btnWord.Id = 6;
            this.btnWord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnWord.ImageOptions.Image")));
            this.btnWord.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnWord.ImageOptions.LargeImage")));
            this.btnWord.Name = "btnWord";
            this.btnWord.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnWord.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnWord_ItemClick);
            // 
            // btnPdf
            // 
            this.btnPdf.Caption = "Xuất pdf";
            this.btnPdf.Id = 7;
            this.btnPdf.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPdf.ImageOptions.Image")));
            this.btnPdf.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPdf.ImageOptions.LargeImage")));
            this.btnPdf.Name = "btnPdf";
            this.btnPdf.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnPdf.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPdf_ItemClick);
            // 
            // btnDong
            // 
            this.btnDong.Caption = "Đóng";
            this.btnDong.Id = 3;
            this.btnDong.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.Image")));
            this.btnDong.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDong.ImageOptions.LargeImage")));
            this.btnDong.Name = "btnDong";
            this.btnDong.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.btnDong.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDong_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(952, 40);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 494);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(952, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 40);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 454);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(952, 40);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 454);
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 40);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage2;
            this.xtraTabControl1.Size = new System.Drawing.Size(952, 454);
            this.xtraTabControl1.TabIndex = 15;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2,
            this.xtraTabPage4,
            this.xtraTabPage5});
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.gcLevel);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(944, 416);
            this.xtraTabPage2.Text = "Trình độ";
            // 
            // gcLevel
            // 
            this.gcLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcLevel.Location = new System.Drawing.Point(0, 0);
            this.gcLevel.MainView = this.gvLevel;
            this.gcLevel.MenuManager = this.barManager1;
            this.gcLevel.Name = "gcLevel";
            this.gcLevel.Size = new System.Drawing.Size(944, 416);
            this.gcLevel.TabIndex = 2;
            this.gcLevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvLevel});
            this.gcLevel.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcLevel_ProcessGridKey);
            // 
            // gvLevel
            // 
            this.gvLevel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gvLevel.DetailHeight = 368;
            this.gvLevel.GridControl = this.gcLevel;
            this.gvLevel.Name = "gvLevel";
            this.gvLevel.OptionsDetail.EnableMasterViewMode = false;
            this.gvLevel.OptionsFind.AlwaysVisible = true;
            this.gvLevel.OptionsFind.Condition = DevExpress.Data.Filtering.FilterCondition.Contains;
            this.gvLevel.OptionsFind.FindDelay = 100;
            this.gvLevel.OptionsFind.FindNullPrompt = "Tìm kiếm tại đây...";
            this.gvLevel.OptionsFind.ShowFindButton = false;
            this.gvLevel.OptionsView.ShowGroupPanel = false;
            this.gvLevel.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvLevel_CustomDrawRowIndicator);
            this.gvLevel.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvLevel_InvalidRowException);
            this.gvLevel.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvLevel_ValidateRow);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên trình độ";
            this.gridColumn1.FieldName = "name";
            this.gridColumn1.MinWidth = 30;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 112;
            // 
            // xtraTabPage4
            // 
            this.xtraTabPage4.Controls.Add(this.gcEnglishLevel);
            this.xtraTabPage4.Name = "xtraTabPage4";
            this.xtraTabPage4.Size = new System.Drawing.Size(944, 416);
            this.xtraTabPage4.Text = "Trình độ ngoại ngữ";
            // 
            // gcEnglishLevel
            // 
            this.gcEnglishLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcEnglishLevel.Location = new System.Drawing.Point(0, 0);
            this.gcEnglishLevel.MainView = this.gvEnglishLevel;
            this.gcEnglishLevel.MenuManager = this.barManager1;
            this.gcEnglishLevel.Name = "gcEnglishLevel";
            this.gcEnglishLevel.Size = new System.Drawing.Size(944, 416);
            this.gcEnglishLevel.TabIndex = 2;
            this.gcEnglishLevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvEnglishLevel});
            this.gcEnglishLevel.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcEnglishLevel_ProcessGridKey);
            // 
            // gvEnglishLevel
            // 
            this.gvEnglishLevel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12});
            this.gvEnglishLevel.DetailHeight = 368;
            this.gvEnglishLevel.GridControl = this.gcEnglishLevel;
            this.gvEnglishLevel.Name = "gvEnglishLevel";
            this.gvEnglishLevel.OptionsDetail.EnableMasterViewMode = false;
            this.gvEnglishLevel.OptionsFind.AlwaysVisible = true;
            this.gvEnglishLevel.OptionsFind.Condition = DevExpress.Data.Filtering.FilterCondition.Contains;
            this.gvEnglishLevel.OptionsFind.FindDelay = 100;
            this.gvEnglishLevel.OptionsFind.FindNullPrompt = "Tìm kiếm tại đây...";
            this.gvEnglishLevel.OptionsFind.ShowFindButton = false;
            this.gvEnglishLevel.OptionsView.ShowGroupPanel = false;
            this.gvEnglishLevel.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvEnglishLevel_CustomDrawRowIndicator);
            this.gvEnglishLevel.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvEnglishLevel_InvalidRowException);
            this.gvEnglishLevel.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvEnglishLevel_ValidateRow);
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tên trình độ ngoại ngữ";
            this.gridColumn12.FieldName = "name";
            this.gridColumn12.MinWidth = 30;
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            this.gridColumn12.Width = 112;
            // 
            // xtraTabPage5
            // 
            this.xtraTabPage5.Controls.Add(this.gcITLevel);
            this.xtraTabPage5.Name = "xtraTabPage5";
            this.xtraTabPage5.Size = new System.Drawing.Size(944, 416);
            this.xtraTabPage5.Text = "Trình độ tin học";
            // 
            // gcITLevel
            // 
            this.gcITLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gcITLevel.Location = new System.Drawing.Point(0, 0);
            this.gcITLevel.MainView = this.gvITLevel;
            this.gcITLevel.MenuManager = this.barManager1;
            this.gcITLevel.Name = "gcITLevel";
            this.gcITLevel.Size = new System.Drawing.Size(944, 416);
            this.gcITLevel.TabIndex = 3;
            this.gcITLevel.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gvITLevel});
            this.gcITLevel.ProcessGridKey += new System.Windows.Forms.KeyEventHandler(this.gcITLevel_ProcessGridKey);
            // 
            // gvITLevel
            // 
            this.gvITLevel.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2});
            this.gvITLevel.DetailHeight = 368;
            this.gvITLevel.GridControl = this.gcITLevel;
            this.gvITLevel.Name = "gvITLevel";
            this.gvITLevel.OptionsDetail.EnableMasterViewMode = false;
            this.gvITLevel.OptionsFind.AlwaysVisible = true;
            this.gvITLevel.OptionsFind.Condition = DevExpress.Data.Filtering.FilterCondition.Contains;
            this.gvITLevel.OptionsFind.FindDelay = 100;
            this.gvITLevel.OptionsFind.FindNullPrompt = "Tìm kiếm tại đây...";
            this.gvITLevel.OptionsFind.ShowFindButton = false;
            this.gvITLevel.OptionsView.ShowGroupPanel = false;
            this.gvITLevel.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gvITLevel_CustomDrawRowIndicator);
            this.gvITLevel.InvalidRowException += new DevExpress.XtraGrid.Views.Base.InvalidRowExceptionEventHandler(this.gvITLevel_InvalidRowException);
            this.gvITLevel.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gvITLevel_ValidateRow);
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên trình độ tin học";
            this.gridColumn2.FieldName = "name";
            this.gridColumn2.MinWidth = 30;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            this.gridColumn2.Width = 112;
            // 
            // uc_level
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.xtraTabControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "uc_level";
            this.Size = new System.Drawing.Size(952, 494);
            this.Tag = "Danh sách trình độ";
            this.Load += new System.EventHandler(this.uc_staff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvLevel)).EndInit();
            this.xtraTabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcEnglishLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvEnglishLevel)).EndInit();
            this.xtraTabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gcITLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvITLevel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private DevExpress.XtraBars.BarButtonItem btnDong;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.BarButtonItem btnExcel;
        private DevExpress.XtraBars.BarButtonItem btnWord;
        private DevExpress.XtraBars.BarButtonItem btnPdf;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage4;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage5;
        private DevExpress.XtraGrid.GridControl gcLevel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvLevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl gcEnglishLevel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvEnglishLevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.GridControl gcITLevel;
        private DevExpress.XtraGrid.Views.Grid.GridView gvITLevel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
