namespace QuanLyKhachSan
{
    partial class FServicesList
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.simpleButtonEdit = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.comboBoxServCategory = new System.Windows.Forms.ComboBox();
            this.textServ = new DevExpress.XtraEditors.TextEdit();
            this.textServID = new DevExpress.XtraEditors.TextEdit();
            this.textPrices = new DevExpress.XtraEditors.TextEdit();
            this.textUnit = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonExit = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlServ = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textServ.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textServID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPrices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUnit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlServ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.simpleButtonEdit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.simpleButtonDelete);
            this.panel1.Controls.Add(this.simpleButtonAdd);
            this.panel1.Controls.Add(this.simpleButtonExit);
            this.panel1.Controls.Add(this.gridControlServ);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 569);
            this.panel1.TabIndex = 8;
            // 
            // simpleButtonEdit
            // 
            this.simpleButtonEdit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(174)))), ((int)(((byte)(210)))));
            this.simpleButtonEdit.Appearance.Options.UseBackColor = true;
            this.simpleButtonEdit.Location = new System.Drawing.Point(50, 368);
            this.simpleButtonEdit.Name = "simpleButtonEdit";
            this.simpleButtonEdit.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonEdit.TabIndex = 15;
            this.simpleButtonEdit.Text = "Sửa";
            this.simpleButtonEdit.Click += new System.EventHandler(this.simpleButtonEdit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.layoutControl1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 303);
            this.panel2.TabIndex = 14;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.comboBoxServCategory);
            this.layoutControl1.Controls.Add(this.textServ);
            this.layoutControl1.Controls.Add(this.textServID);
            this.layoutControl1.Controls.Add(this.textPrices);
            this.layoutControl1.Controls.Add(this.textUnit);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(252, 303);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboBoxServCategory
            // 
            this.comboBoxServCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxServCategory.FormattingEnabled = true;
            this.comboBoxServCategory.Location = new System.Drawing.Point(12, 128);
            this.comboBoxServCategory.Name = "comboBoxServCategory";
            this.comboBoxServCategory.Size = new System.Drawing.Size(228, 25);
            this.comboBoxServCategory.TabIndex = 13;
            // 
            // textServ
            // 
            this.textServ.Location = new System.Drawing.Point(12, 80);
            this.textServ.Name = "textServ";
            this.textServ.Size = new System.Drawing.Size(228, 24);
            this.textServ.StyleController = this.layoutControl1;
            this.textServ.TabIndex = 4;
            // 
            // textServID
            // 
            this.textServID.Location = new System.Drawing.Point(12, 32);
            this.textServID.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textServID.Name = "textServID";
            this.textServID.Size = new System.Drawing.Size(228, 24);
            this.textServID.StyleController = this.layoutControl1;
            this.textServID.TabIndex = 12;
            // 
            // textPrices
            // 
            this.textPrices.Location = new System.Drawing.Point(12, 173);
            this.textPrices.Name = "textPrices";
            this.textPrices.Size = new System.Drawing.Size(228, 24);
            this.textPrices.StyleController = this.layoutControl1;
            this.textPrices.TabIndex = 14;
            // 
            // textUnit
            // 
            this.textUnit.Location = new System.Drawing.Point(12, 221);
            this.textUnit.Name = "textUnit";
            this.textUnit.Size = new System.Drawing.Size(228, 24);
            this.textUnit.StyleController = this.layoutControl1;
            this.textUnit.TabIndex = 15;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(252, 303);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textServ;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(232, 48);
            this.layoutControlItem1.Text = "Dịch Vụ:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(80, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.textServID;
            this.layoutControlItem5.CustomizationFormText = "Tên Đăng Nhập:";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(232, 48);
            this.layoutControlItem5.Text = "Mã Dịch Vụ:";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(80, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.comboBoxServCategory;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 96);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(232, 45);
            this.layoutControlItem2.Text = "Loại Dịch Vụ:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(80, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textPrices;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 141);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(232, 48);
            this.layoutControlItem3.Text = "Giá:";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(80, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textUnit;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 189);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(232, 94);
            this.layoutControlItem4.Text = "Đơn Vị:";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(80, 17);
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.simpleButtonDelete.Appearance.Options.UseBackColor = true;
            this.simpleButtonDelete.Location = new System.Drawing.Point(50, 412);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonDelete.TabIndex = 6;
            this.simpleButtonDelete.Text = "Xóa Dịch Vụ";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButtonAdd.Appearance.Options.UseBackColor = true;
            this.simpleButtonAdd.Location = new System.Drawing.Point(50, 325);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonAdd.TabIndex = 7;
            this.simpleButtonAdd.Text = "Thêm Dịch Vụ";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // simpleButtonExit
            // 
            this.simpleButtonExit.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButtonExit.Appearance.Options.UseBackColor = true;
            this.simpleButtonExit.Location = new System.Drawing.Point(50, 456);
            this.simpleButtonExit.Name = "simpleButtonExit";
            this.simpleButtonExit.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonExit.TabIndex = 8;
            this.simpleButtonExit.Text = "Thoát";
            this.simpleButtonExit.Click += new System.EventHandler(this.simpleButtonExit_Click);
            // 
            // gridControlServ
            // 
            this.gridControlServ.Location = new System.Drawing.Point(261, 0);
            this.gridControlServ.MainView = this.gridView1;
            this.gridControlServ.Name = "gridControlServ";
            this.gridControlServ.Size = new System.Drawing.Size(711, 563);
            this.gridControlServ.TabIndex = 9;
            this.gridControlServ.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumnName,
            this.gridColumnPhone,
            this.gridColumn2,
            this.gridColumn3});
            this.gridView1.GridControl = this.gridControlServ;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã Dịch Vụ";
            this.gridColumn1.FieldName = "ServID";
            this.gridColumn1.MinWidth = 22;
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 95;
            // 
            // gridColumnName
            // 
            this.gridColumnName.Caption = "Dịch Vụ";
            this.gridColumnName.FieldName = "ServName";
            this.gridColumnName.Name = "gridColumnName";
            this.gridColumnName.OptionsColumn.AllowEdit = false;
            this.gridColumnName.OptionsColumn.ReadOnly = true;
            this.gridColumnName.Visible = true;
            this.gridColumnName.VisibleIndex = 1;
            this.gridColumnName.Width = 179;
            // 
            // gridColumnPhone
            // 
            this.gridColumnPhone.Caption = "Loại Dịch Vụ";
            this.gridColumnPhone.FieldName = "CategoryName";
            this.gridColumnPhone.Name = "gridColumnPhone";
            this.gridColumnPhone.OptionsColumn.AllowEdit = false;
            this.gridColumnPhone.OptionsColumn.ReadOnly = true;
            this.gridColumnPhone.Visible = true;
            this.gridColumnPhone.VisibleIndex = 2;
            this.gridColumnPhone.Width = 152;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Giá";
            this.gridColumn2.DisplayFormat.FormatString = "#,#";
            this.gridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn2.FieldName = "ServPrices";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 3;
            this.gridColumn2.Width = 128;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Đơn Vị";
            this.gridColumn3.FieldName = "Unit";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 136;
            // 
            // FServicesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 569);
            this.Controls.Add(this.panel1);
            this.Name = "FServicesList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Dịch Vụ";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textServ.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textServID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textPrices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textUnit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlServ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEdit;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ComboBox comboBoxServCategory;
        private DevExpress.XtraEditors.TextEdit textServ;
        private DevExpress.XtraEditors.TextEdit textServID;
        private DevExpress.XtraEditors.TextEdit textPrices;
        private DevExpress.XtraEditors.TextEdit textUnit;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExit;
        private DevExpress.XtraGrid.GridControl gridControlServ;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}