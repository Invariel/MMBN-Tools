namespace Deck_Builder
{
    partial class frm_DeckBuilder
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tbl_MainLayout = new TableLayoutPanel();
            grp_SelectFolder = new GroupBox();
            cmb_SelectFolder = new ComboBox();
            tbl_SaveLoadEtc = new TableLayoutPanel();
            btn_NewFolder = new Button();
            btn_DeleteFolder = new Button();
            btn_Save = new Button();
            btn_LoadFolders = new Button();
            tbl_Cards = new TableLayoutPanel();
            grp_FilterChips = new GroupBox();
            tbl_Filters = new TableLayoutPanel();
            lbl_FilterByName = new Label();
            txt_FilterByName = new TextBox();
            lbl_FilterByElement = new Label();
            cmb_FilterByElement = new ComboBox();
            tbl_ChipView = new TableLayoutPanel();
            lbl_ChipDataView_Right = new Label();
            lbl_Error = new Label();
            dgv_ChipList = new DataGridView();
            grp_SelectGame = new GroupBox();
            cmb_SelectGame = new ComboBox();
            tbl_Folder = new TableLayoutPanel();
            lbl_ChipDataView_Left = new Label();
            lbl_FolderContents = new Label();
            dgv_Folder = new DataGridView();
            tbl_MainLayout.SuspendLayout();
            grp_SelectFolder.SuspendLayout();
            tbl_SaveLoadEtc.SuspendLayout();
            tbl_Cards.SuspendLayout();
            grp_FilterChips.SuspendLayout();
            tbl_Filters.SuspendLayout();
            tbl_ChipView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ChipList).BeginInit();
            grp_SelectGame.SuspendLayout();
            tbl_Folder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Folder).BeginInit();
            SuspendLayout();
            // 
            // tbl_MainLayout
            // 
            tbl_MainLayout.AutoScroll = true;
            tbl_MainLayout.AutoSize = true;
            tbl_MainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_MainLayout.ColumnCount = 2;
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.0106F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.9894F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbl_MainLayout.Controls.Add(grp_SelectFolder, 0, 0);
            tbl_MainLayout.Controls.Add(tbl_SaveLoadEtc, 1, 0);
            tbl_MainLayout.Controls.Add(tbl_Cards, 1, 1);
            tbl_MainLayout.Controls.Add(tbl_Folder, 0, 1);
            tbl_MainLayout.Dock = DockStyle.Fill;
            tbl_MainLayout.Location = new Point(0, 0);
            tbl_MainLayout.Name = "tbl_MainLayout";
            tbl_MainLayout.RowCount = 2;
            tbl_MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 12.1835442F));
            tbl_MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 87.81645F));
            tbl_MainLayout.Size = new Size(1132, 745);
            tbl_MainLayout.TabIndex = 0;
            // 
            // grp_SelectFolder
            // 
            grp_SelectFolder.AutoSize = true;
            grp_SelectFolder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            grp_SelectFolder.Controls.Add(cmb_SelectFolder);
            grp_SelectFolder.Dock = DockStyle.Fill;
            grp_SelectFolder.Location = new Point(3, 3);
            grp_SelectFolder.Name = "grp_SelectFolder";
            grp_SelectFolder.Size = new Size(379, 84);
            grp_SelectFolder.TabIndex = 0;
            grp_SelectFolder.TabStop = false;
            grp_SelectFolder.Text = "Select &Folder";
            // 
            // cmb_SelectFolder
            // 
            cmb_SelectFolder.Dock = DockStyle.Fill;
            cmb_SelectFolder.FormattingEnabled = true;
            cmb_SelectFolder.ItemHeight = 15;
            cmb_SelectFolder.Location = new Point(3, 19);
            cmb_SelectFolder.Name = "cmb_SelectFolder";
            cmb_SelectFolder.Size = new Size(373, 23);
            cmb_SelectFolder.TabIndex = 0;
            // 
            // tbl_SaveLoadEtc
            // 
            tbl_SaveLoadEtc.AutoSize = true;
            tbl_SaveLoadEtc.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_SaveLoadEtc.ColumnCount = 3;
            tbl_SaveLoadEtc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_SaveLoadEtc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_SaveLoadEtc.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_SaveLoadEtc.Controls.Add(btn_NewFolder, 0, 0);
            tbl_SaveLoadEtc.Controls.Add(btn_DeleteFolder, 0, 1);
            tbl_SaveLoadEtc.Controls.Add(btn_Save, 1, 0);
            tbl_SaveLoadEtc.Controls.Add(btn_LoadFolders, 1, 1);
            tbl_SaveLoadEtc.Dock = DockStyle.Fill;
            tbl_SaveLoadEtc.Location = new Point(388, 3);
            tbl_SaveLoadEtc.Name = "tbl_SaveLoadEtc";
            tbl_SaveLoadEtc.RowCount = 2;
            tbl_SaveLoadEtc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_SaveLoadEtc.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_SaveLoadEtc.Size = new Size(741, 84);
            tbl_SaveLoadEtc.TabIndex = 2;
            // 
            // btn_NewFolder
            // 
            btn_NewFolder.Dock = DockStyle.Fill;
            btn_NewFolder.Location = new Point(3, 3);
            btn_NewFolder.Name = "btn_NewFolder";
            btn_NewFolder.Size = new Size(179, 36);
            btn_NewFolder.TabIndex = 0;
            btn_NewFolder.Text = "&New Folder";
            btn_NewFolder.UseVisualStyleBackColor = true;
            // 
            // btn_DeleteFolder
            // 
            btn_DeleteFolder.Dock = DockStyle.Fill;
            btn_DeleteFolder.Location = new Point(3, 45);
            btn_DeleteFolder.Name = "btn_DeleteFolder";
            btn_DeleteFolder.Size = new Size(179, 36);
            btn_DeleteFolder.TabIndex = 1;
            btn_DeleteFolder.Text = "&Delete Folder";
            btn_DeleteFolder.UseVisualStyleBackColor = true;
            // 
            // btn_Save
            // 
            btn_Save.Dock = DockStyle.Fill;
            btn_Save.Location = new Point(188, 3);
            btn_Save.Name = "btn_Save";
            btn_Save.Size = new Size(179, 36);
            btn_Save.TabIndex = 2;
            btn_Save.Text = "&Save Folders";
            btn_Save.UseVisualStyleBackColor = true;
            // 
            // btn_LoadFolders
            // 
            btn_LoadFolders.Dock = DockStyle.Fill;
            btn_LoadFolders.Location = new Point(188, 45);
            btn_LoadFolders.Name = "btn_LoadFolders";
            btn_LoadFolders.Size = new Size(179, 36);
            btn_LoadFolders.TabIndex = 3;
            btn_LoadFolders.Text = "&Load Folders";
            btn_LoadFolders.UseVisualStyleBackColor = true;
            // 
            // tbl_Cards
            // 
            tbl_Cards.ColumnCount = 1;
            tbl_Cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Cards.Controls.Add(grp_FilterChips, 0, 1);
            tbl_Cards.Controls.Add(tbl_ChipView, 0, 2);
            tbl_Cards.Controls.Add(grp_SelectGame, 0, 0);
            tbl_Cards.Dock = DockStyle.Fill;
            tbl_Cards.Location = new Point(388, 93);
            tbl_Cards.Name = "tbl_Cards";
            tbl_Cards.RowCount = 3;
            tbl_Cards.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6575594F));
            tbl_Cards.RowStyles.Add(new RowStyle(SizeType.Percent, 16.575592F));
            tbl_Cards.RowStyles.Add(new RowStyle(SizeType.Percent, 71.7668457F));
            tbl_Cards.Size = new Size(741, 649);
            tbl_Cards.TabIndex = 3;
            // 
            // grp_FilterChips
            // 
            grp_FilterChips.Controls.Add(tbl_Filters);
            grp_FilterChips.Location = new Point(3, 78);
            grp_FilterChips.Name = "grp_FilterChips";
            grp_FilterChips.Size = new Size(735, 82);
            grp_FilterChips.TabIndex = 0;
            grp_FilterChips.TabStop = false;
            grp_FilterChips.Text = "Filter Chips";
            // 
            // tbl_Filters
            // 
            tbl_Filters.ColumnCount = 4;
            tbl_Filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_Filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_Filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_Filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_Filters.Controls.Add(lbl_FilterByName, 0, 0);
            tbl_Filters.Controls.Add(txt_FilterByName, 1, 0);
            tbl_Filters.Controls.Add(lbl_FilterByElement, 0, 1);
            tbl_Filters.Controls.Add(cmb_FilterByElement, 1, 1);
            tbl_Filters.Dock = DockStyle.Fill;
            tbl_Filters.Location = new Point(3, 19);
            tbl_Filters.Name = "tbl_Filters";
            tbl_Filters.RowCount = 2;
            tbl_Filters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Filters.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_Filters.Size = new Size(729, 60);
            tbl_Filters.TabIndex = 0;
            // 
            // lbl_FilterByName
            // 
            lbl_FilterByName.Anchor = AnchorStyles.Right;
            lbl_FilterByName.AutoSize = true;
            lbl_FilterByName.Location = new Point(124, 7);
            lbl_FilterByName.Name = "lbl_FilterByName";
            lbl_FilterByName.Size = new Size(55, 15);
            lbl_FilterByName.TabIndex = 0;
            lbl_FilterByName.Text = "By Name";
            // 
            // txt_FilterByName
            // 
            txt_FilterByName.Dock = DockStyle.Fill;
            txt_FilterByName.Location = new Point(185, 3);
            txt_FilterByName.Name = "txt_FilterByName";
            txt_FilterByName.Size = new Size(176, 23);
            txt_FilterByName.TabIndex = 1;
            // 
            // lbl_FilterByElement
            // 
            lbl_FilterByElement.Anchor = AnchorStyles.Right;
            lbl_FilterByElement.AutoSize = true;
            lbl_FilterByElement.Location = new Point(113, 37);
            lbl_FilterByElement.Name = "lbl_FilterByElement";
            lbl_FilterByElement.Size = new Size(66, 15);
            lbl_FilterByElement.TabIndex = 2;
            lbl_FilterByElement.Text = "By Element";
            // 
            // cmb_FilterByElement
            // 
            cmb_FilterByElement.Dock = DockStyle.Fill;
            cmb_FilterByElement.FormattingEnabled = true;
            cmb_FilterByElement.Location = new Point(185, 33);
            cmb_FilterByElement.Name = "cmb_FilterByElement";
            cmb_FilterByElement.Size = new Size(176, 23);
            cmb_FilterByElement.TabIndex = 3;
            // 
            // tbl_ChipView
            // 
            tbl_ChipView.ColumnCount = 1;
            tbl_ChipView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_ChipView.Controls.Add(lbl_ChipDataView_Right, 0, 1);
            tbl_ChipView.Controls.Add(lbl_Error, 0, 2);
            tbl_ChipView.Controls.Add(dgv_ChipList, 0, 0);
            tbl_ChipView.Dock = DockStyle.Fill;
            tbl_ChipView.Location = new Point(3, 185);
            tbl_ChipView.Name = "tbl_ChipView";
            tbl_ChipView.RowCount = 3;
            tbl_ChipView.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tbl_ChipView.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tbl_ChipView.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tbl_ChipView.Size = new Size(735, 461);
            tbl_ChipView.TabIndex = 1;
            // 
            // lbl_ChipDataView_Right
            // 
            lbl_ChipDataView_Right.AutoSize = true;
            lbl_ChipDataView_Right.Dock = DockStyle.Fill;
            lbl_ChipDataView_Right.Location = new Point(3, 276);
            lbl_ChipDataView_Right.Name = "lbl_ChipDataView_Right";
            lbl_ChipDataView_Right.Size = new Size(729, 161);
            lbl_ChipDataView_Right.TabIndex = 1;
            // 
            // lbl_Error
            // 
            lbl_Error.AutoSize = true;
            lbl_Error.Dock = DockStyle.Fill;
            lbl_Error.Location = new Point(3, 437);
            lbl_Error.Name = "lbl_Error";
            lbl_Error.Size = new Size(729, 24);
            lbl_Error.TabIndex = 2;
            // 
            // dgv_ChipList
            // 
            dgv_ChipList.AllowUserToDeleteRows = false;
            dgv_ChipList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ChipList.Dock = DockStyle.Fill;
            dgv_ChipList.Location = new Point(3, 3);
            dgv_ChipList.Name = "dgv_ChipList";
            dgv_ChipList.ReadOnly = true;
            dgv_ChipList.Size = new Size(729, 270);
            dgv_ChipList.TabIndex = 3;
            // 
            // grp_SelectGame
            // 
            grp_SelectGame.Controls.Add(cmb_SelectGame);
            grp_SelectGame.Dock = DockStyle.Fill;
            grp_SelectGame.Location = new Point(3, 3);
            grp_SelectGame.Name = "grp_SelectGame";
            grp_SelectGame.Size = new Size(735, 69);
            grp_SelectGame.TabIndex = 2;
            grp_SelectGame.TabStop = false;
            grp_SelectGame.Text = "Select Game";
            // 
            // cmb_SelectGame
            // 
            cmb_SelectGame.Dock = DockStyle.Fill;
            cmb_SelectGame.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_SelectGame.FormattingEnabled = true;
            cmb_SelectGame.Location = new Point(3, 19);
            cmb_SelectGame.Name = "cmb_SelectGame";
            cmb_SelectGame.Size = new Size(729, 23);
            cmb_SelectGame.TabIndex = 0;
            // 
            // tbl_Folder
            // 
            tbl_Folder.ColumnCount = 1;
            tbl_Folder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Folder.Controls.Add(lbl_ChipDataView_Left, 0, 1);
            tbl_Folder.Controls.Add(lbl_FolderContents, 0, 2);
            tbl_Folder.Controls.Add(dgv_Folder, 0, 0);
            tbl_Folder.Dock = DockStyle.Fill;
            tbl_Folder.Location = new Point(3, 93);
            tbl_Folder.Name = "tbl_Folder";
            tbl_Folder.RowCount = 3;
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Percent, 53.1147537F));
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Percent, 46.8852463F));
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tbl_Folder.Size = new Size(379, 649);
            tbl_Folder.TabIndex = 4;
            // 
            // lbl_ChipDataView_Left
            // 
            lbl_ChipDataView_Left.AutoSize = true;
            lbl_ChipDataView_Left.Dock = DockStyle.Fill;
            lbl_ChipDataView_Left.Location = new Point(3, 324);
            lbl_ChipDataView_Left.Name = "lbl_ChipDataView_Left";
            lbl_ChipDataView_Left.Size = new Size(373, 286);
            lbl_ChipDataView_Left.TabIndex = 1;
            // 
            // lbl_FolderContents
            // 
            lbl_FolderContents.AutoSize = true;
            lbl_FolderContents.Dock = DockStyle.Fill;
            lbl_FolderContents.Location = new Point(3, 610);
            lbl_FolderContents.Name = "lbl_FolderContents";
            lbl_FolderContents.Size = new Size(373, 39);
            lbl_FolderContents.TabIndex = 2;
            // 
            // dgv_Folder
            // 
            dgv_Folder.AllowUserToAddRows = false;
            dgv_Folder.AllowUserToDeleteRows = false;
            dgv_Folder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_Folder.Dock = DockStyle.Fill;
            dgv_Folder.Location = new Point(3, 3);
            dgv_Folder.Name = "dgv_Folder";
            dgv_Folder.ReadOnly = true;
            dgv_Folder.Size = new Size(373, 318);
            dgv_Folder.TabIndex = 3;
            // 
            // frm_DeckBuilder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 745);
            Controls.Add(tbl_MainLayout);
            Name = "frm_DeckBuilder";
            Text = "Folder Builder";
            tbl_MainLayout.ResumeLayout(false);
            tbl_MainLayout.PerformLayout();
            grp_SelectFolder.ResumeLayout(false);
            tbl_SaveLoadEtc.ResumeLayout(false);
            tbl_Cards.ResumeLayout(false);
            grp_FilterChips.ResumeLayout(false);
            tbl_Filters.ResumeLayout(false);
            tbl_Filters.PerformLayout();
            tbl_ChipView.ResumeLayout(false);
            tbl_ChipView.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ChipList).EndInit();
            grp_SelectGame.ResumeLayout(false);
            tbl_Folder.ResumeLayout(false);
            tbl_Folder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Folder).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tbl_MainLayout;
        private GroupBox grp_SelectFolder;
        private ComboBox cmb_SelectFolder;
        private Button btn_NewFolder;
        private Button btn_DeleteFolder;
        private TableLayoutPanel tbl_SaveLoadEtc;
        private Button btn_Save;
        private Button btn_LoadFolders;
        private TableLayoutPanel tbl_Cards;
        private GroupBox grp_FilterChips;
        private TableLayoutPanel tbl_Filters;
        private Label lbl_FilterByName;
        private TextBox txt_FilterByName;
        private Label lbl_FilterByElement;
        private ComboBox cmb_FilterByElement;
        private TableLayoutPanel tbl_ChipView;
        private GroupBox grp_SelectGame;
        private ComboBox cmb_SelectGame;
        private TableLayoutPanel tbl_Folder;
        private Label lbl_ChipDataView_Right;
        private Label lbl_ChipDataView_Left;
        private Label lbl_Error;
        private Label lbl_FolderContents;
        private DataGridView dgv_ChipList;
        private DataGridView dgv_Folder;
    }
}
