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
            btn_SaveFolders = new Button();
            btn_LoadFolders = new Button();
            tbl_Cards = new TableLayoutPanel();
            grp_FilterChips = new GroupBox();
            tbl_Filters = new TableLayoutPanel();
            lbl_FilterByName = new Label();
            txt_FilterByName = new TextBox();
            lbl_FilterByElement = new Label();
            cmb_FilterByElement = new ComboBox();
            lbl_ByCodes = new Label();
            txt_FilterByCodes = new TextBox();
            tbl_ChipView = new TableLayoutPanel();
            lbl_ChipDataView_Right = new Label();
            lbl_Error = new Label();
            split_GameChips = new SplitContainer();
            dgv_ChipList = new DataGridView();
            textBox1 = new TextBox();
            btn_5_2 = new Button();
            btn_4_2 = new Button();
            btn_3_2 = new Button();
            btn_2_2 = new Button();
            btn_1_2 = new Button();
            btn_0_2 = new Button();
            btn_5_1 = new Button();
            btn_4_1 = new Button();
            btn_3_1 = new Button();
            btn_2_1 = new Button();
            btn_1_1 = new Button();
            btn_0_1 = new Button();
            btn_5_0 = new Button();
            btn_4_0 = new Button();
            btn_3_0 = new Button();
            btn_2_0 = new Button();
            btn_1_0 = new Button();
            btn_0_0 = new Button();
            grp_SelectGame = new GroupBox();
            cmb_SelectGame = new ComboBox();
            tbl_Folder = new TableLayoutPanel();
            lbl_FolderContents = new Label();
            tabControl1 = new TabControl();
            tab_Folder = new TabPage();
            dgv_Folder = new DataGridView();
            tab_Checklist = new TabPage();
            tab_RandomHand = new TabPage();
            txt_ChipDataView_Left = new TextBox();
            tbl_MainLayout.SuspendLayout();
            grp_SelectFolder.SuspendLayout();
            tbl_SaveLoadEtc.SuspendLayout();
            tbl_Cards.SuspendLayout();
            grp_FilterChips.SuspendLayout();
            tbl_Filters.SuspendLayout();
            tbl_ChipView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)split_GameChips).BeginInit();
            split_GameChips.Panel1.SuspendLayout();
            split_GameChips.Panel2.SuspendLayout();
            split_GameChips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ChipList).BeginInit();
            grp_SelectGame.SuspendLayout();
            tbl_Folder.SuspendLayout();
            tabControl1.SuspendLayout();
            tab_Folder.SuspendLayout();
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
            tbl_SaveLoadEtc.Controls.Add(btn_SaveFolders, 1, 0);
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
            // btn_SaveFolders
            // 
            btn_SaveFolders.Dock = DockStyle.Fill;
            btn_SaveFolders.Location = new Point(188, 3);
            btn_SaveFolders.Name = "btn_SaveFolders";
            btn_SaveFolders.Size = new Size(179, 36);
            btn_SaveFolders.TabIndex = 2;
            btn_SaveFolders.Text = "&Save Folders";
            btn_SaveFolders.UseVisualStyleBackColor = true;
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
            tbl_Filters.Controls.Add(lbl_ByCodes, 2, 0);
            tbl_Filters.Controls.Add(txt_FilterByCodes, 3, 0);
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
            // lbl_ByCodes
            // 
            lbl_ByCodes.Anchor = AnchorStyles.Right;
            lbl_ByCodes.AutoSize = true;
            lbl_ByCodes.Location = new Point(487, 7);
            lbl_ByCodes.Name = "lbl_ByCodes";
            lbl_ByCodes.Size = new Size(56, 15);
            lbl_ByCodes.TabIndex = 4;
            lbl_ByCodes.Text = "By Codes";
            // 
            // txt_FilterByCodes
            // 
            txt_FilterByCodes.Dock = DockStyle.Fill;
            txt_FilterByCodes.Location = new Point(549, 3);
            txt_FilterByCodes.Name = "txt_FilterByCodes";
            txt_FilterByCodes.Size = new Size(177, 23);
            txt_FilterByCodes.TabIndex = 5;
            // 
            // tbl_ChipView
            // 
            tbl_ChipView.ColumnCount = 1;
            tbl_ChipView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_ChipView.Controls.Add(lbl_ChipDataView_Right, 0, 1);
            tbl_ChipView.Controls.Add(lbl_Error, 0, 2);
            tbl_ChipView.Controls.Add(split_GameChips, 0, 0);
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
            // split_GameChips
            // 
            split_GameChips.Dock = DockStyle.Fill;
            split_GameChips.Location = new Point(3, 3);
            split_GameChips.Name = "split_GameChips";
            // 
            // split_GameChips.Panel1
            // 
            split_GameChips.Panel1.Controls.Add(dgv_ChipList);
            // 
            // split_GameChips.Panel2
            // 
            split_GameChips.Panel2.Controls.Add(textBox1);
            split_GameChips.Panel2.Controls.Add(btn_5_2);
            split_GameChips.Panel2.Controls.Add(btn_4_2);
            split_GameChips.Panel2.Controls.Add(btn_3_2);
            split_GameChips.Panel2.Controls.Add(btn_2_2);
            split_GameChips.Panel2.Controls.Add(btn_1_2);
            split_GameChips.Panel2.Controls.Add(btn_0_2);
            split_GameChips.Panel2.Controls.Add(btn_5_1);
            split_GameChips.Panel2.Controls.Add(btn_4_1);
            split_GameChips.Panel2.Controls.Add(btn_3_1);
            split_GameChips.Panel2.Controls.Add(btn_2_1);
            split_GameChips.Panel2.Controls.Add(btn_1_1);
            split_GameChips.Panel2.Controls.Add(btn_0_1);
            split_GameChips.Panel2.Controls.Add(btn_5_0);
            split_GameChips.Panel2.Controls.Add(btn_4_0);
            split_GameChips.Panel2.Controls.Add(btn_3_0);
            split_GameChips.Panel2.Controls.Add(btn_2_0);
            split_GameChips.Panel2.Controls.Add(btn_1_0);
            split_GameChips.Panel2.Controls.Add(btn_0_0);
            split_GameChips.Size = new Size(729, 270);
            split_GameChips.SplitterDistance = 487;
            split_GameChips.TabIndex = 3;
            // 
            // dgv_ChipList
            // 
            dgv_ChipList.AllowUserToDeleteRows = false;
            dgv_ChipList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv_ChipList.Dock = DockStyle.Fill;
            dgv_ChipList.Location = new Point(0, 0);
            dgv_ChipList.Name = "dgv_ChipList";
            dgv_ChipList.ReadOnly = true;
            dgv_ChipList.Size = new Size(487, 270);
            dgv_ChipList.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(11, 150);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(215, 88);
            textBox1.TabIndex = 18;
            // 
            // btn_5_2
            // 
            btn_5_2.Location = new Point(191, 109);
            btn_5_2.Name = "btn_5_2";
            btn_5_2.Size = new Size(35, 35);
            btn_5_2.TabIndex = 17;
            btn_5_2.UseVisualStyleBackColor = true;
            // 
            // btn_4_2
            // 
            btn_4_2.Location = new Point(155, 109);
            btn_4_2.Name = "btn_4_2";
            btn_4_2.Size = new Size(35, 35);
            btn_4_2.TabIndex = 16;
            btn_4_2.UseVisualStyleBackColor = true;
            // 
            // btn_3_2
            // 
            btn_3_2.Location = new Point(119, 109);
            btn_3_2.Name = "btn_3_2";
            btn_3_2.Size = new Size(35, 35);
            btn_3_2.TabIndex = 15;
            btn_3_2.UseVisualStyleBackColor = true;
            // 
            // btn_2_2
            // 
            btn_2_2.Location = new Point(83, 109);
            btn_2_2.Name = "btn_2_2";
            btn_2_2.Size = new Size(35, 35);
            btn_2_2.TabIndex = 14;
            btn_2_2.UseVisualStyleBackColor = true;
            // 
            // btn_1_2
            // 
            btn_1_2.Location = new Point(47, 109);
            btn_1_2.Name = "btn_1_2";
            btn_1_2.Size = new Size(35, 35);
            btn_1_2.TabIndex = 13;
            btn_1_2.UseVisualStyleBackColor = true;
            // 
            // btn_0_2
            // 
            btn_0_2.Location = new Point(11, 109);
            btn_0_2.Name = "btn_0_2";
            btn_0_2.Size = new Size(35, 35);
            btn_0_2.TabIndex = 12;
            btn_0_2.UseVisualStyleBackColor = true;
            // 
            // btn_5_1
            // 
            btn_5_1.Location = new Point(191, 68);
            btn_5_1.Name = "btn_5_1";
            btn_5_1.Size = new Size(35, 35);
            btn_5_1.TabIndex = 11;
            btn_5_1.UseVisualStyleBackColor = true;
            // 
            // btn_4_1
            // 
            btn_4_1.Location = new Point(155, 68);
            btn_4_1.Name = "btn_4_1";
            btn_4_1.Size = new Size(35, 35);
            btn_4_1.TabIndex = 10;
            btn_4_1.UseVisualStyleBackColor = true;
            // 
            // btn_3_1
            // 
            btn_3_1.Location = new Point(119, 68);
            btn_3_1.Name = "btn_3_1";
            btn_3_1.Size = new Size(35, 35);
            btn_3_1.TabIndex = 9;
            btn_3_1.UseVisualStyleBackColor = true;
            // 
            // btn_2_1
            // 
            btn_2_1.Location = new Point(83, 68);
            btn_2_1.Name = "btn_2_1";
            btn_2_1.Size = new Size(35, 35);
            btn_2_1.TabIndex = 8;
            btn_2_1.UseVisualStyleBackColor = true;
            // 
            // btn_1_1
            // 
            btn_1_1.Location = new Point(47, 68);
            btn_1_1.Name = "btn_1_1";
            btn_1_1.Size = new Size(35, 35);
            btn_1_1.TabIndex = 7;
            btn_1_1.UseVisualStyleBackColor = true;
            // 
            // btn_0_1
            // 
            btn_0_1.Location = new Point(11, 68);
            btn_0_1.Name = "btn_0_1";
            btn_0_1.Size = new Size(35, 35);
            btn_0_1.TabIndex = 6;
            btn_0_1.UseVisualStyleBackColor = true;
            // 
            // btn_5_0
            // 
            btn_5_0.Location = new Point(191, 27);
            btn_5_0.Name = "btn_5_0";
            btn_5_0.Size = new Size(35, 35);
            btn_5_0.TabIndex = 5;
            btn_5_0.UseVisualStyleBackColor = true;
            // 
            // btn_4_0
            // 
            btn_4_0.Location = new Point(155, 27);
            btn_4_0.Name = "btn_4_0";
            btn_4_0.Size = new Size(35, 35);
            btn_4_0.TabIndex = 4;
            btn_4_0.UseVisualStyleBackColor = true;
            // 
            // btn_3_0
            // 
            btn_3_0.Location = new Point(119, 27);
            btn_3_0.Name = "btn_3_0";
            btn_3_0.Size = new Size(35, 35);
            btn_3_0.TabIndex = 3;
            btn_3_0.UseVisualStyleBackColor = true;
            // 
            // btn_2_0
            // 
            btn_2_0.Location = new Point(83, 27);
            btn_2_0.Name = "btn_2_0";
            btn_2_0.Size = new Size(35, 35);
            btn_2_0.TabIndex = 2;
            btn_2_0.UseVisualStyleBackColor = true;
            // 
            // btn_1_0
            // 
            btn_1_0.Location = new Point(47, 27);
            btn_1_0.Name = "btn_1_0";
            btn_1_0.Size = new Size(35, 35);
            btn_1_0.TabIndex = 1;
            btn_1_0.UseVisualStyleBackColor = true;
            // 
            // btn_0_0
            // 
            btn_0_0.Location = new Point(11, 27);
            btn_0_0.Name = "btn_0_0";
            btn_0_0.Size = new Size(35, 35);
            btn_0_0.TabIndex = 0;
            btn_0_0.UseVisualStyleBackColor = true;
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
            tbl_Folder.Controls.Add(lbl_FolderContents, 0, 2);
            tbl_Folder.Controls.Add(tabControl1, 0, 0);
            tbl_Folder.Controls.Add(txt_ChipDataView_Left, 0, 1);
            tbl_Folder.Dock = DockStyle.Fill;
            tbl_Folder.Location = new Point(3, 93);
            tbl_Folder.Name = "tbl_Folder";
            tbl_Folder.RowCount = 3;
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Percent, 77.21311F));
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Percent, 22.7868843F));
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tbl_Folder.Size = new Size(379, 649);
            tbl_Folder.TabIndex = 4;
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
            // tabControl1
            // 
            tabControl1.Controls.Add(tab_Folder);
            tabControl1.Controls.Add(tab_Checklist);
            tabControl1.Controls.Add(tab_RandomHand);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(3, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(373, 465);
            tabControl1.TabIndex = 3;
            // 
            // tab_Folder
            // 
            tab_Folder.Controls.Add(dgv_Folder);
            tab_Folder.Location = new Point(4, 24);
            tab_Folder.Name = "tab_Folder";
            tab_Folder.Padding = new Padding(3);
            tab_Folder.Size = new Size(365, 437);
            tab_Folder.TabIndex = 0;
            tab_Folder.Text = "Folder";
            tab_Folder.UseVisualStyleBackColor = true;
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
            dgv_Folder.Size = new Size(359, 431);
            dgv_Folder.TabIndex = 3;
            // 
            // tab_Checklist
            // 
            tab_Checklist.Location = new Point(4, 24);
            tab_Checklist.Name = "tab_Checklist";
            tab_Checklist.Padding = new Padding(3);
            tab_Checklist.Size = new Size(365, 437);
            tab_Checklist.TabIndex = 1;
            tab_Checklist.Text = "Checklist";
            tab_Checklist.UseVisualStyleBackColor = true;
            // 
            // tab_RandomHand
            // 
            tab_RandomHand.Location = new Point(4, 24);
            tab_RandomHand.Name = "tab_RandomHand";
            tab_RandomHand.Size = new Size(365, 437);
            tab_RandomHand.TabIndex = 2;
            tab_RandomHand.Text = "Random Hand";
            tab_RandomHand.UseVisualStyleBackColor = true;
            // 
            // txt_ChipDataView_Left
            // 
            txt_ChipDataView_Left.Dock = DockStyle.Fill;
            txt_ChipDataView_Left.Location = new Point(3, 474);
            txt_ChipDataView_Left.Multiline = true;
            txt_ChipDataView_Left.Name = "txt_ChipDataView_Left";
            txt_ChipDataView_Left.ReadOnly = true;
            txt_ChipDataView_Left.ScrollBars = ScrollBars.Both;
            txt_ChipDataView_Left.Size = new Size(373, 133);
            txt_ChipDataView_Left.TabIndex = 4;
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
            split_GameChips.Panel1.ResumeLayout(false);
            split_GameChips.Panel2.ResumeLayout(false);
            split_GameChips.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)split_GameChips).EndInit();
            split_GameChips.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_ChipList).EndInit();
            grp_SelectGame.ResumeLayout(false);
            tbl_Folder.ResumeLayout(false);
            tbl_Folder.PerformLayout();
            tabControl1.ResumeLayout(false);
            tab_Folder.ResumeLayout(false);
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
        private Button btn_SaveFolders;
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
        private Label lbl_Error;
        private Label lbl_FolderContents;
        private DataGridView dgv_ChipList;
        private DataGridView dgv_Folder;
        private Label lbl_ByCodes;
        private TextBox txt_FilterByCodes;
        private TabControl tabControl1;
        private TabPage tab_Folder;
        private TabPage tab_Checklist;
        private TabPage tab_RandomHand;
        private TextBox txt_ChipDataView_Left;
        private SplitContainer split_GameChips;
        private Button btn_3_0;
        private Button btn_2_0;
        private Button btn_1_0;
        private Button btn_0_0;
        private TextBox textBox1;
        private Button btn_5_2;
        private Button btn_4_2;
        private Button btn_3_2;
        private Button btn_2_2;
        private Button btn_1_2;
        private Button btn_0_2;
        private Button btn_5_1;
        private Button btn_4_1;
        private Button btn_3_1;
        private Button btn_2_1;
        private Button btn_1_1;
        private Button btn_0_1;
        private Button btn_5_0;
        private Button btn_4_0;
    }
}
