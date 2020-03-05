namespace QuanLyKhachSan
{
    partial class FRoomType
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
            this.comboBoxRoomType = new System.Windows.Forms.ComboBox();
            this.textRoomTypeID = new DevExpress.XtraEditors.TextEdit();
            this.textNumberMin = new DevExpress.XtraEditors.TextEdit();
            this.textRoomPrices = new DevExpress.XtraEditors.TextEdit();
            this.textNumberMax = new DevExpress.XtraEditors.TextEdit();
            this.Root = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.gridControlRoomTypeList = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButtonDelete = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonAdd = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButtonExit = new DevExpress.XtraEditors.SimpleButton();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textRoomTypeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumberMin.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRoomPrices.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumberMax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRoomTypeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(233)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.simpleButtonEdit);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.gridControlRoomTypeList);
            this.panel1.Controls.Add(this.simpleButtonDelete);
            this.panel1.Controls.Add(this.simpleButtonAdd);
            this.panel1.Controls.Add(this.simpleButtonExit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(972, 569);
            this.panel1.TabIndex = 1;
            // 
            // simpleButtonEdit
            // 
            this.simpleButtonEdit.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(174)))), ((int)(((byte)(210)))));
            this.simpleButtonEdit.Appearance.Options.UseBackColor = true;
            this.simpleButtonEdit.Location = new System.Drawing.Point(53, 330);
            this.simpleButtonEdit.Name = "simpleButtonEdit";
            this.simpleButtonEdit.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonEdit.TabIndex = 14;
            this.simpleButtonEdit.Text = "Sửa";
            this.simpleButtonEdit.Click += new System.EventHandler(this.simpleButtonEdit_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.layoutControl1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 281);
            this.panel2.TabIndex = 13;
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.comboBoxRoomType);
            this.layoutControl1.Controls.Add(this.textRoomTypeID);
            this.layoutControl1.Controls.Add(this.textNumberMin);
            this.layoutControl1.Controls.Add(this.textRoomPrices);
            this.layoutControl1.Controls.Add(this.textNumberMax);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.Root;
            this.layoutControl1.Size = new System.Drawing.Size(252, 281);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // comboBoxRoomType
            // 
            this.comboBoxRoomType.FormattingEnabled = true;
            this.comboBoxRoomType.Location = new System.Drawing.Point(12, 80);
            this.comboBoxRoomType.Name = "comboBoxRoomType";
            this.comboBoxRoomType.Size = new System.Drawing.Size(228, 25);
            this.comboBoxRoomType.TabIndex = 8;
            // 
            // textRoomTypeID
            // 
            this.textRoomTypeID.Location = new System.Drawing.Point(12, 32);
            this.textRoomTypeID.Name = "textRoomTypeID";
            this.textRoomTypeID.Size = new System.Drawing.Size(228, 24);
            this.textRoomTypeID.StyleController = this.layoutControl1;
            this.textRoomTypeID.TabIndex = 4;
            // 
            // textNumberMin
            // 
            this.textNumberMin.Location = new System.Drawing.Point(12, 173);
            this.textNumberMin.Name = "textNumberMin";
            this.textNumberMin.Size = new System.Drawing.Size(228, 24);
            this.textNumberMin.StyleController = this.layoutControl1;
            this.textNumberMin.TabIndex = 5;
            // 
            // textRoomPrices
            // 
            this.textRoomPrices.Location = new System.Drawing.Point(12, 125);
            this.textRoomPrices.Name = "textRoomPrices";
            this.textRoomPrices.Size = new System.Drawing.Size(228, 24);
            this.textRoomPrices.StyleController = this.layoutControl1;
            this.textRoomPrices.TabIndex = 10;
            // 
            // textNumberMax
            // 
            this.textNumberMax.Location = new System.Drawing.Point(12, 221);
            this.textNumberMax.Name = "textNumberMax";
            this.textNumberMax.Size = new System.Drawing.Size(228, 24);
            this.textNumberMax.StyleController = this.layoutControl1;
            this.textNumberMax.TabIndex = 5;
            // 
            // Root
            // 
            this.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.Root.GroupBordersVisible = false;
            this.Root.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3,
            this.layoutControlItem5,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.Root.Name = "Root";
            this.Root.Size = new System.Drawing.Size(252, 281);
            this.Root.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.textRoomTypeID;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(232, 48);
            this.layoutControlItem1.Text = "Mã Loại:";
            this.layoutControlItem1.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(120, 17);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.textRoomPrices;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 93);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(232, 48);
            this.layoutControlItem3.Text = "Giá Phòng:";
            this.layoutControlItem3.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem3.TextSize = new System.Drawing.Size(120, 17);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.comboBoxRoomType;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 48);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(232, 45);
            this.layoutControlItem5.Text = "Loại Phòng:";
            this.layoutControlItem5.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem5.TextSize = new System.Drawing.Size(120, 17);
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.textNumberMin;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 141);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(232, 48);
            this.layoutControlItem2.Text = "Số Người Tối Thiểu:";
            this.layoutControlItem2.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem2.TextSize = new System.Drawing.Size(120, 17);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.textNumberMax;
            this.layoutControlItem4.CustomizationFormText = "Số Người Tối Đa:";
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 189);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(232, 72);
            this.layoutControlItem4.Text = "Số Người Tối Đa:";
            this.layoutControlItem4.TextLocation = DevExpress.Utils.Locations.Top;
            this.layoutControlItem4.TextSize = new System.Drawing.Size(120, 17);
            // 
            // gridControlRoomTypeList
            // 
            this.gridControlRoomTypeList.Location = new System.Drawing.Point(258, 3);
            this.gridControlRoomTypeList.MainView = this.gridView1;
            this.gridControlRoomTypeList.Name = "gridControlRoomTypeList";
            this.gridControlRoomTypeList.Size = new System.Drawing.Size(711, 563);
            this.gridControlRoomTypeList.TabIndex = 12;
            this.gridControlRoomTypeList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5});
            this.gridView1.GridControl = this.gridControlRoomTypeList;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã Loại";
            this.gridColumn1.FieldName = "Room_Type_Id";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 79;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Loại Phòng";
            this.gridColumn2.FieldName = "Room_Type_Name";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 220;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Giá";
            this.gridColumn3.DisplayFormat.FormatString = "#,#";
            this.gridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn3.FieldName = "Room_Prices";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 127;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Số Người Tối Đa";
            this.gridColumn4.FieldName = "Number_Max";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 4;
            this.gridColumn4.Width = 123;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Số Người Tối Thiểu";
            this.gridColumn5.FieldName = "Number_Min";
            this.gridColumn5.MinWidth = 22;
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 3;
            this.gridColumn5.Width = 141;
            // 
            // simpleButtonDelete
            // 
            this.simpleButtonDelete.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(204)))), ((int)(((byte)(0)))));
            this.simpleButtonDelete.Appearance.Options.UseBackColor = true;
            this.simpleButtonDelete.Location = new System.Drawing.Point(53, 373);
            this.simpleButtonDelete.Name = "simpleButtonDelete";
            this.simpleButtonDelete.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonDelete.TabIndex = 9;
            this.simpleButtonDelete.Text = "Xóa";
            this.simpleButtonDelete.Click += new System.EventHandler(this.simpleButtonDelete_Click);
            // 
            // simpleButtonAdd
            // 
            this.simpleButtonAdd.Appearance.BackColor = DevExpress.LookAndFeel.DXSkinColors.FillColors.Primary;
            this.simpleButtonAdd.Appearance.Options.UseBackColor = true;
            this.simpleButtonAdd.Location = new System.Drawing.Point(53, 287);
            this.simpleButtonAdd.Name = "simpleButtonAdd";
            this.simpleButtonAdd.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonAdd.TabIndex = 10;
            this.simpleButtonAdd.Text = "Thêm Loại Phòng";
            this.simpleButtonAdd.Click += new System.EventHandler(this.simpleButtonAdd_Click);
            // 
            // simpleButtonExit
            // 
            this.simpleButtonExit.Appearance.BackColor = System.Drawing.Color.Red;
            this.simpleButtonExit.Appearance.Options.UseBackColor = true;
            this.simpleButtonExit.Location = new System.Drawing.Point(53, 416);
            this.simpleButtonExit.Name = "simpleButtonExit";
            this.simpleButtonExit.Size = new System.Drawing.Size(142, 37);
            this.simpleButtonExit.TabIndex = 11;
            this.simpleButtonExit.Text = "Thoát";
            this.simpleButtonExit.Click += new System.EventHandler(this.simpleButtonExit_Click);
            // 
            // FRoomType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 569);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FRoomType";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh Sách Loại Phòng:";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textRoomTypeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumberMin.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textRoomPrices.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textNumberMax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Root)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlRoomTypeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButtonEdit;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private System.Windows.Forms.ComboBox comboBoxRoomType;
        private DevExpress.XtraEditors.TextEdit textRoomTypeID;
        private DevExpress.XtraEditors.TextEdit textNumberMin;
        private DevExpress.XtraEditors.TextEdit textRoomPrices;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraGrid.GridControl gridControlRoomTypeList;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraEditors.SimpleButton simpleButtonDelete;
        private DevExpress.XtraEditors.SimpleButton simpleButtonAdd;
        private DevExpress.XtraEditors.SimpleButton simpleButtonExit;
        private DevExpress.XtraEditors.TextEdit textNumberMax;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}