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
            tbl_GameDetails = new TableLayoutPanel();
            grp_SelectGame = new GroupBox();
            cmb_SelectGame = new ComboBox();
            txt_GameDetails = new TextBox();
            tbl_Cards = new TableLayoutPanel();
            grp_FilterChips = new GroupBox();
            tbl_Filters = new TableLayoutPanel();
            lbl_FilterByName = new Label();
            txt_FilterByName = new TextBox();
            lbl_FilterByElement = new Label();
            cmb_FilterByElement = new ComboBox();
            lbl_FilterByCodes = new Label();
            txt_FilterByCodes = new TextBox();
            lbl_FilterByClass = new Label();
            cmb_FilterByClass = new ComboBox();
            lbl_LocationText = new Label();
            txt_SearchLocationText = new TextBox();
            tbl_ChipView = new TableLayoutPanel();
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
            txt_ChipDataView_Right = new TextBox();
            grp_NaviCust = new GroupBox();
            tbl_NaviCust = new TableLayoutPanel();
            lbl_CustMega = new Label();
            lbl_CustGiga = new Label();
            numud_CustMega = new NumericUpDown();
            numud_CustGiga = new NumericUpDown();
            tbl_Folder = new TableLayoutPanel();
            lbl_FolderContents = new Label();
            tabControl1 = new TabControl();
            tab_Folder = new TabPage();
            dgv_Folder = new DataGridView();
            tab_Checklist = new TabPage();
            flw_Checklist = new FlowLayoutPanel();
            tab_RandomHand = new TabPage();
            panel_RandomHand = new Panel();
            txt_Results = new TextBox();
            btn_Generate = new Button();
            numud_HandSize = new NumericUpDown();
            lbl_HandSize = new Label();
            numud_Draws = new NumericUpDown();
            lbl_NumberOfDraws = new Label();
            txt_ChipDataView_Left = new TextBox();
            tbl_FolderLayoutPanel = new TableLayoutPanel();
            grp_SelectFolder = new GroupBox();
            cmb_SelectFolder = new ComboBox();
            btn_SaveFolders = new Button();
            btn_NewFolder = new Button();
            btn_DeleteFolder = new Button();
            btn_LoadFolders = new Button();
            menuStrip1 = new MenuStrip();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            tbl_MainLayout.SuspendLayout();
            tbl_GameDetails.SuspendLayout();
            grp_SelectGame.SuspendLayout();
            tbl_Cards.SuspendLayout();
            grp_FilterChips.SuspendLayout();
            tbl_Filters.SuspendLayout();
            tbl_ChipView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)split_GameChips).BeginInit();
            split_GameChips.Panel1.SuspendLayout();
            split_GameChips.Panel2.SuspendLayout();
            split_GameChips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_ChipList).BeginInit();
            grp_NaviCust.SuspendLayout();
            tbl_NaviCust.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numud_CustMega).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numud_CustGiga).BeginInit();
            tbl_Folder.SuspendLayout();
            tabControl1.SuspendLayout();
            tab_Folder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgv_Folder).BeginInit();
            tab_Checklist.SuspendLayout();
            tab_RandomHand.SuspendLayout();
            panel_RandomHand.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numud_HandSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numud_Draws).BeginInit();
            tbl_FolderLayoutPanel.SuspendLayout();
            grp_SelectFolder.SuspendLayout();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // tbl_MainLayout
            // 
            tbl_MainLayout.AutoScroll = true;
            tbl_MainLayout.AutoSize = true;
            tbl_MainLayout.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_MainLayout.ColumnCount = 2;
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34.8056526F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65.19434F));
            tbl_MainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbl_MainLayout.Controls.Add(tbl_GameDetails, 1, 0);
            tbl_MainLayout.Controls.Add(tbl_Cards, 1, 1);
            tbl_MainLayout.Controls.Add(tbl_Folder, 0, 1);
            tbl_MainLayout.Controls.Add(tbl_FolderLayoutPanel, 0, 0);
            tbl_MainLayout.Dock = DockStyle.Fill;
            tbl_MainLayout.Location = new Point(0, 24);
            tbl_MainLayout.Name = "tbl_MainLayout";
            tbl_MainLayout.RowCount = 2;
            tbl_MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 16.6442947F));
            tbl_MainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 83.3557053F));
            tbl_MainLayout.Size = new Size(1132, 721);
            tbl_MainLayout.TabIndex = 0;
            // 
            // tbl_GameDetails
            // 
            tbl_GameDetails.AutoSize = true;
            tbl_GameDetails.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_GameDetails.ColumnCount = 1;
            tbl_GameDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_GameDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbl_GameDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbl_GameDetails.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tbl_GameDetails.Controls.Add(grp_SelectGame, 0, 0);
            tbl_GameDetails.Controls.Add(txt_GameDetails, 0, 1);
            tbl_GameDetails.Dock = DockStyle.Fill;
            tbl_GameDetails.Location = new Point(397, 3);
            tbl_GameDetails.Name = "tbl_GameDetails";
            tbl_GameDetails.RowCount = 2;
            tbl_GameDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_GameDetails.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_GameDetails.Size = new Size(732, 114);
            tbl_GameDetails.TabIndex = 2;
            // 
            // grp_SelectGame
            // 
            grp_SelectGame.Controls.Add(cmb_SelectGame);
            grp_SelectGame.Dock = DockStyle.Fill;
            grp_SelectGame.Location = new Point(3, 3);
            grp_SelectGame.Name = "grp_SelectGame";
            grp_SelectGame.Size = new Size(726, 51);
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
            cmb_SelectGame.MaxDropDownItems = 24;
            cmb_SelectGame.Name = "cmb_SelectGame";
            cmb_SelectGame.Size = new Size(720, 23);
            cmb_SelectGame.TabIndex = 0;
            // 
            // txt_GameDetails
            // 
            txt_GameDetails.Dock = DockStyle.Fill;
            txt_GameDetails.Location = new Point(3, 60);
            txt_GameDetails.Multiline = true;
            txt_GameDetails.Name = "txt_GameDetails";
            txt_GameDetails.ReadOnly = true;
            txt_GameDetails.Size = new Size(726, 51);
            txt_GameDetails.TabIndex = 3;
            // 
            // tbl_Cards
            // 
            tbl_Cards.ColumnCount = 1;
            tbl_Cards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_Cards.Controls.Add(grp_FilterChips, 0, 1);
            tbl_Cards.Controls.Add(tbl_ChipView, 0, 2);
            tbl_Cards.Controls.Add(grp_NaviCust, 0, 0);
            tbl_Cards.Dock = DockStyle.Fill;
            tbl_Cards.Location = new Point(397, 123);
            tbl_Cards.Name = "tbl_Cards";
            tbl_Cards.RowCount = 3;
            tbl_Cards.RowStyles.Add(new RowStyle(SizeType.Percent, 11.6575594F));
            tbl_Cards.RowStyles.Add(new RowStyle(SizeType.Percent, 17.7195683F));
            tbl_Cards.RowStyles.Add(new RowStyle(SizeType.Percent, 70.72419F));
            tbl_Cards.Size = new Size(732, 595);
            tbl_Cards.TabIndex = 3;
            // 
            // grp_FilterChips
            // 
            grp_FilterChips.Controls.Add(tbl_Filters);
            grp_FilterChips.Dock = DockStyle.Fill;
            grp_FilterChips.Location = new Point(3, 72);
            grp_FilterChips.Name = "grp_FilterChips";
            grp_FilterChips.Size = new Size(726, 99);
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
            tbl_Filters.Controls.Add(lbl_FilterByCodes, 2, 0);
            tbl_Filters.Controls.Add(txt_FilterByCodes, 3, 0);
            tbl_Filters.Controls.Add(lbl_FilterByClass, 2, 1);
            tbl_Filters.Controls.Add(cmb_FilterByClass, 3, 1);
            tbl_Filters.Controls.Add(lbl_LocationText, 0, 2);
            tbl_Filters.Controls.Add(txt_SearchLocationText, 1, 2);
            tbl_Filters.Dock = DockStyle.Fill;
            tbl_Filters.Location = new Point(3, 19);
            tbl_Filters.Name = "tbl_Filters";
            tbl_Filters.RowCount = 3;
            tbl_Filters.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3322334F));
            tbl_Filters.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3322334F));
            tbl_Filters.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3355331F));
            tbl_Filters.Size = new Size(720, 77);
            tbl_Filters.TabIndex = 0;
            // 
            // lbl_FilterByName
            // 
            lbl_FilterByName.Anchor = AnchorStyles.Right;
            lbl_FilterByName.AutoSize = true;
            lbl_FilterByName.Location = new Point(122, 5);
            lbl_FilterByName.Name = "lbl_FilterByName";
            lbl_FilterByName.Size = new Size(55, 15);
            lbl_FilterByName.TabIndex = 0;
            lbl_FilterByName.Text = "By Name";
            // 
            // txt_FilterByName
            // 
            txt_FilterByName.Dock = DockStyle.Fill;
            txt_FilterByName.Location = new Point(183, 3);
            txt_FilterByName.Name = "txt_FilterByName";
            txt_FilterByName.Size = new Size(174, 23);
            txt_FilterByName.TabIndex = 1;
            // 
            // lbl_FilterByElement
            // 
            lbl_FilterByElement.Anchor = AnchorStyles.Right;
            lbl_FilterByElement.AutoSize = true;
            lbl_FilterByElement.Location = new Point(111, 30);
            lbl_FilterByElement.Name = "lbl_FilterByElement";
            lbl_FilterByElement.Size = new Size(66, 15);
            lbl_FilterByElement.TabIndex = 2;
            lbl_FilterByElement.Text = "By Element";
            // 
            // cmb_FilterByElement
            // 
            cmb_FilterByElement.Dock = DockStyle.Fill;
            cmb_FilterByElement.FormattingEnabled = true;
            cmb_FilterByElement.Location = new Point(183, 28);
            cmb_FilterByElement.Name = "cmb_FilterByElement";
            cmb_FilterByElement.Size = new Size(174, 23);
            cmb_FilterByElement.TabIndex = 3;
            // 
            // lbl_FilterByCodes
            // 
            lbl_FilterByCodes.Anchor = AnchorStyles.Right;
            lbl_FilterByCodes.AutoSize = true;
            lbl_FilterByCodes.Location = new Point(481, 5);
            lbl_FilterByCodes.Name = "lbl_FilterByCodes";
            lbl_FilterByCodes.Size = new Size(56, 15);
            lbl_FilterByCodes.TabIndex = 4;
            lbl_FilterByCodes.Text = "By Codes";
            // 
            // txt_FilterByCodes
            // 
            txt_FilterByCodes.Dock = DockStyle.Fill;
            txt_FilterByCodes.Location = new Point(543, 3);
            txt_FilterByCodes.Name = "txt_FilterByCodes";
            txt_FilterByCodes.Size = new Size(174, 23);
            txt_FilterByCodes.TabIndex = 5;
            // 
            // lbl_FilterByClass
            // 
            lbl_FilterByClass.Anchor = AnchorStyles.Right;
            lbl_FilterByClass.AutoSize = true;
            lbl_FilterByClass.Location = new Point(487, 30);
            lbl_FilterByClass.Name = "lbl_FilterByClass";
            lbl_FilterByClass.Size = new Size(50, 15);
            lbl_FilterByClass.TabIndex = 6;
            lbl_FilterByClass.Text = "By Class";
            // 
            // cmb_FilterByClass
            // 
            cmb_FilterByClass.Dock = DockStyle.Fill;
            cmb_FilterByClass.FormattingEnabled = true;
            cmb_FilterByClass.Items.AddRange(new object[] { "None", "Standard", "Mega", "Giga", "Dark" });
            cmb_FilterByClass.Location = new Point(543, 28);
            cmb_FilterByClass.Name = "cmb_FilterByClass";
            cmb_FilterByClass.Size = new Size(174, 23);
            cmb_FilterByClass.TabIndex = 7;
            // 
            // lbl_LocationText
            // 
            lbl_LocationText.Anchor = AnchorStyles.Right;
            lbl_LocationText.AutoSize = true;
            lbl_LocationText.Location = new Point(108, 56);
            lbl_LocationText.Name = "lbl_LocationText";
            lbl_LocationText.Size = new Size(69, 15);
            lbl_LocationText.TabIndex = 8;
            lbl_LocationText.Text = "By Location";
            // 
            // txt_SearchLocationText
            // 
            txt_SearchLocationText.Dock = DockStyle.Fill;
            txt_SearchLocationText.Location = new Point(183, 53);
            txt_SearchLocationText.Name = "txt_SearchLocationText";
            txt_SearchLocationText.Size = new Size(174, 23);
            txt_SearchLocationText.TabIndex = 9;
            // 
            // tbl_ChipView
            // 
            tbl_ChipView.ColumnCount = 1;
            tbl_ChipView.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tbl_ChipView.Controls.Add(lbl_Error, 0, 2);
            tbl_ChipView.Controls.Add(split_GameChips, 0, 0);
            tbl_ChipView.Controls.Add(txt_ChipDataView_Right, 0, 1);
            tbl_ChipView.Dock = DockStyle.Fill;
            tbl_ChipView.Location = new Point(3, 177);
            tbl_ChipView.Name = "tbl_ChipView";
            tbl_ChipView.RowCount = 3;
            tbl_ChipView.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tbl_ChipView.RowStyles.Add(new RowStyle(SizeType.Percent, 35F));
            tbl_ChipView.RowStyles.Add(new RowStyle(SizeType.Percent, 5F));
            tbl_ChipView.Size = new Size(726, 415);
            tbl_ChipView.TabIndex = 1;
            // 
            // lbl_Error
            // 
            lbl_Error.AutoSize = true;
            lbl_Error.Dock = DockStyle.Fill;
            lbl_Error.Location = new Point(3, 394);
            lbl_Error.Name = "lbl_Error";
            lbl_Error.Size = new Size(720, 21);
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
            split_GameChips.Size = new Size(720, 243);
            split_GameChips.SplitterDistance = 480;
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
            dgv_ChipList.Size = new Size(480, 243);
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
            textBox1.Visible = false;
            // 
            // btn_5_2
            // 
            btn_5_2.Location = new Point(191, 109);
            btn_5_2.Name = "btn_5_2";
            btn_5_2.Size = new Size(35, 35);
            btn_5_2.TabIndex = 17;
            btn_5_2.UseVisualStyleBackColor = true;
            btn_5_2.Visible = false;
            // 
            // btn_4_2
            // 
            btn_4_2.Location = new Point(155, 109);
            btn_4_2.Name = "btn_4_2";
            btn_4_2.Size = new Size(35, 35);
            btn_4_2.TabIndex = 16;
            btn_4_2.UseVisualStyleBackColor = true;
            btn_4_2.Visible = false;
            // 
            // btn_3_2
            // 
            btn_3_2.Location = new Point(119, 109);
            btn_3_2.Name = "btn_3_2";
            btn_3_2.Size = new Size(35, 35);
            btn_3_2.TabIndex = 15;
            btn_3_2.UseVisualStyleBackColor = true;
            btn_3_2.Visible = false;
            // 
            // btn_2_2
            // 
            btn_2_2.Location = new Point(83, 109);
            btn_2_2.Name = "btn_2_2";
            btn_2_2.Size = new Size(35, 35);
            btn_2_2.TabIndex = 14;
            btn_2_2.UseVisualStyleBackColor = true;
            btn_2_2.Visible = false;
            // 
            // btn_1_2
            // 
            btn_1_2.Location = new Point(47, 109);
            btn_1_2.Name = "btn_1_2";
            btn_1_2.Size = new Size(35, 35);
            btn_1_2.TabIndex = 13;
            btn_1_2.UseVisualStyleBackColor = true;
            btn_1_2.Visible = false;
            // 
            // btn_0_2
            // 
            btn_0_2.Location = new Point(11, 109);
            btn_0_2.Name = "btn_0_2";
            btn_0_2.Size = new Size(35, 35);
            btn_0_2.TabIndex = 12;
            btn_0_2.UseVisualStyleBackColor = true;
            btn_0_2.Visible = false;
            // 
            // btn_5_1
            // 
            btn_5_1.Location = new Point(191, 68);
            btn_5_1.Name = "btn_5_1";
            btn_5_1.Size = new Size(35, 35);
            btn_5_1.TabIndex = 11;
            btn_5_1.UseVisualStyleBackColor = true;
            btn_5_1.Visible = false;
            // 
            // btn_4_1
            // 
            btn_4_1.Location = new Point(155, 68);
            btn_4_1.Name = "btn_4_1";
            btn_4_1.Size = new Size(35, 35);
            btn_4_1.TabIndex = 10;
            btn_4_1.UseVisualStyleBackColor = true;
            btn_4_1.Visible = false;
            // 
            // btn_3_1
            // 
            btn_3_1.Location = new Point(119, 68);
            btn_3_1.Name = "btn_3_1";
            btn_3_1.Size = new Size(35, 35);
            btn_3_1.TabIndex = 9;
            btn_3_1.UseVisualStyleBackColor = true;
            btn_3_1.Visible = false;
            // 
            // btn_2_1
            // 
            btn_2_1.Location = new Point(83, 68);
            btn_2_1.Name = "btn_2_1";
            btn_2_1.Size = new Size(35, 35);
            btn_2_1.TabIndex = 8;
            btn_2_1.UseVisualStyleBackColor = true;
            btn_2_1.Visible = false;
            // 
            // btn_1_1
            // 
            btn_1_1.Location = new Point(47, 68);
            btn_1_1.Name = "btn_1_1";
            btn_1_1.Size = new Size(35, 35);
            btn_1_1.TabIndex = 7;
            btn_1_1.UseVisualStyleBackColor = true;
            btn_1_1.Visible = false;
            // 
            // btn_0_1
            // 
            btn_0_1.Location = new Point(11, 68);
            btn_0_1.Name = "btn_0_1";
            btn_0_1.Size = new Size(35, 35);
            btn_0_1.TabIndex = 6;
            btn_0_1.UseVisualStyleBackColor = true;
            btn_0_1.Visible = false;
            // 
            // btn_5_0
            // 
            btn_5_0.Location = new Point(191, 27);
            btn_5_0.Name = "btn_5_0";
            btn_5_0.Size = new Size(35, 35);
            btn_5_0.TabIndex = 5;
            btn_5_0.UseVisualStyleBackColor = true;
            btn_5_0.Visible = false;
            // 
            // btn_4_0
            // 
            btn_4_0.Location = new Point(155, 27);
            btn_4_0.Name = "btn_4_0";
            btn_4_0.Size = new Size(35, 35);
            btn_4_0.TabIndex = 4;
            btn_4_0.UseVisualStyleBackColor = true;
            btn_4_0.Visible = false;
            // 
            // btn_3_0
            // 
            btn_3_0.Location = new Point(119, 27);
            btn_3_0.Name = "btn_3_0";
            btn_3_0.Size = new Size(35, 35);
            btn_3_0.TabIndex = 3;
            btn_3_0.UseVisualStyleBackColor = true;
            btn_3_0.Visible = false;
            // 
            // btn_2_0
            // 
            btn_2_0.Location = new Point(83, 27);
            btn_2_0.Name = "btn_2_0";
            btn_2_0.Size = new Size(35, 35);
            btn_2_0.TabIndex = 2;
            btn_2_0.UseVisualStyleBackColor = true;
            btn_2_0.Visible = false;
            // 
            // btn_1_0
            // 
            btn_1_0.Location = new Point(47, 27);
            btn_1_0.Name = "btn_1_0";
            btn_1_0.Size = new Size(35, 35);
            btn_1_0.TabIndex = 1;
            btn_1_0.UseVisualStyleBackColor = true;
            btn_1_0.Visible = false;
            // 
            // btn_0_0
            // 
            btn_0_0.Location = new Point(11, 27);
            btn_0_0.Name = "btn_0_0";
            btn_0_0.Size = new Size(35, 35);
            btn_0_0.TabIndex = 0;
            btn_0_0.UseVisualStyleBackColor = true;
            btn_0_0.Visible = false;
            // 
            // txt_ChipDataView_Right
            // 
            txt_ChipDataView_Right.Dock = DockStyle.Fill;
            txt_ChipDataView_Right.Location = new Point(3, 252);
            txt_ChipDataView_Right.Multiline = true;
            txt_ChipDataView_Right.Name = "txt_ChipDataView_Right";
            txt_ChipDataView_Right.ReadOnly = true;
            txt_ChipDataView_Right.ScrollBars = ScrollBars.Both;
            txt_ChipDataView_Right.Size = new Size(720, 139);
            txt_ChipDataView_Right.TabIndex = 4;
            // 
            // grp_NaviCust
            // 
            grp_NaviCust.Controls.Add(tbl_NaviCust);
            grp_NaviCust.Dock = DockStyle.Fill;
            grp_NaviCust.Location = new Point(3, 3);
            grp_NaviCust.Name = "grp_NaviCust";
            grp_NaviCust.Size = new Size(726, 63);
            grp_NaviCust.TabIndex = 2;
            grp_NaviCust.TabStop = false;
            grp_NaviCust.Text = "NaviCust";
            // 
            // tbl_NaviCust
            // 
            tbl_NaviCust.ColumnCount = 4;
            tbl_NaviCust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_NaviCust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_NaviCust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_NaviCust.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tbl_NaviCust.Controls.Add(lbl_CustMega, 0, 0);
            tbl_NaviCust.Controls.Add(lbl_CustGiga, 2, 0);
            tbl_NaviCust.Controls.Add(numud_CustMega, 1, 0);
            tbl_NaviCust.Controls.Add(numud_CustGiga, 3, 0);
            tbl_NaviCust.Dock = DockStyle.Fill;
            tbl_NaviCust.Location = new Point(3, 19);
            tbl_NaviCust.Name = "tbl_NaviCust";
            tbl_NaviCust.RowCount = 2;
            tbl_NaviCust.RowStyles.Add(new RowStyle(SizeType.Percent, 66.6666641F));
            tbl_NaviCust.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            tbl_NaviCust.Size = new Size(720, 41);
            tbl_NaviCust.TabIndex = 0;
            // 
            // lbl_CustMega
            // 
            lbl_CustMega.Anchor = AnchorStyles.Right;
            lbl_CustMega.AutoSize = true;
            lbl_CustMega.Location = new Point(96, 6);
            lbl_CustMega.Name = "lbl_CustMega";
            lbl_CustMega.Size = new Size(81, 15);
            lbl_CustMega.TabIndex = 0;
            lbl_CustMega.Text = "+ Mega Chips";
            // 
            // lbl_CustGiga
            // 
            lbl_CustGiga.Anchor = AnchorStyles.Right;
            lbl_CustGiga.AutoSize = true;
            lbl_CustGiga.Location = new Point(462, 6);
            lbl_CustGiga.Name = "lbl_CustGiga";
            lbl_CustGiga.Size = new Size(75, 15);
            lbl_CustGiga.TabIndex = 1;
            lbl_CustGiga.Text = "+ Giga Chips";
            // 
            // numud_CustMega
            // 
            numud_CustMega.Dock = DockStyle.Fill;
            numud_CustMega.Location = new Point(183, 3);
            numud_CustMega.Maximum = new decimal(new int[] { 5, 0, 0, 0 });
            numud_CustMega.Name = "numud_CustMega";
            numud_CustMega.Size = new Size(174, 23);
            numud_CustMega.TabIndex = 2;
            numud_CustMega.TextAlign = HorizontalAlignment.Right;
            // 
            // numud_CustGiga
            // 
            numud_CustGiga.Dock = DockStyle.Fill;
            numud_CustGiga.Location = new Point(543, 3);
            numud_CustGiga.Maximum = new decimal(new int[] { 3, 0, 0, 0 });
            numud_CustGiga.Name = "numud_CustGiga";
            numud_CustGiga.Size = new Size(174, 23);
            numud_CustGiga.TabIndex = 3;
            numud_CustGiga.TextAlign = HorizontalAlignment.Right;
            // 
            // tbl_Folder
            // 
            tbl_Folder.ColumnCount = 1;
            tbl_Folder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_Folder.Controls.Add(lbl_FolderContents, 0, 2);
            tbl_Folder.Controls.Add(tabControl1, 0, 0);
            tbl_Folder.Controls.Add(txt_ChipDataView_Left, 0, 1);
            tbl_Folder.Dock = DockStyle.Fill;
            tbl_Folder.Location = new Point(3, 123);
            tbl_Folder.Name = "tbl_Folder";
            tbl_Folder.RowCount = 3;
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Percent, 77.21311F));
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Percent, 22.7868843F));
            tbl_Folder.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            tbl_Folder.Size = new Size(388, 595);
            tbl_Folder.TabIndex = 4;
            // 
            // lbl_FolderContents
            // 
            lbl_FolderContents.AutoSize = true;
            lbl_FolderContents.Dock = DockStyle.Fill;
            lbl_FolderContents.Location = new Point(3, 556);
            lbl_FolderContents.Name = "lbl_FolderContents";
            lbl_FolderContents.Size = new Size(382, 39);
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
            tabControl1.Size = new Size(382, 424);
            tabControl1.TabIndex = 3;
            // 
            // tab_Folder
            // 
            tab_Folder.Controls.Add(dgv_Folder);
            tab_Folder.Location = new Point(4, 24);
            tab_Folder.Name = "tab_Folder";
            tab_Folder.Padding = new Padding(3);
            tab_Folder.Size = new Size(374, 396);
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
            dgv_Folder.Size = new Size(368, 390);
            dgv_Folder.TabIndex = 3;
            // 
            // tab_Checklist
            // 
            tab_Checklist.AutoScroll = true;
            tab_Checklist.Controls.Add(flw_Checklist);
            tab_Checklist.Location = new Point(4, 24);
            tab_Checklist.Name = "tab_Checklist";
            tab_Checklist.Padding = new Padding(3);
            tab_Checklist.Size = new Size(374, 396);
            tab_Checklist.TabIndex = 1;
            tab_Checklist.Text = "Checklist";
            tab_Checklist.UseVisualStyleBackColor = true;
            // 
            // flw_Checklist
            // 
            flw_Checklist.AutoScroll = true;
            flw_Checklist.Dock = DockStyle.Fill;
            flw_Checklist.Location = new Point(3, 3);
            flw_Checklist.Name = "flw_Checklist";
            flw_Checklist.Size = new Size(368, 390);
            flw_Checklist.TabIndex = 0;
            // 
            // tab_RandomHand
            // 
            tab_RandomHand.Controls.Add(panel_RandomHand);
            tab_RandomHand.Location = new Point(4, 24);
            tab_RandomHand.Name = "tab_RandomHand";
            tab_RandomHand.Size = new Size(374, 396);
            tab_RandomHand.TabIndex = 2;
            tab_RandomHand.Text = "Random Hand";
            tab_RandomHand.UseVisualStyleBackColor = true;
            // 
            // panel_RandomHand
            // 
            panel_RandomHand.Controls.Add(txt_Results);
            panel_RandomHand.Controls.Add(btn_Generate);
            panel_RandomHand.Controls.Add(numud_HandSize);
            panel_RandomHand.Controls.Add(lbl_HandSize);
            panel_RandomHand.Controls.Add(numud_Draws);
            panel_RandomHand.Controls.Add(lbl_NumberOfDraws);
            panel_RandomHand.Dock = DockStyle.Fill;
            panel_RandomHand.Location = new Point(0, 0);
            panel_RandomHand.Name = "panel_RandomHand";
            panel_RandomHand.Size = new Size(374, 396);
            panel_RandomHand.TabIndex = 0;
            // 
            // txt_Results
            // 
            txt_Results.Location = new Point(32, 95);
            txt_Results.Multiline = true;
            txt_Results.Name = "txt_Results";
            txt_Results.ReadOnly = true;
            txt_Results.ScrollBars = ScrollBars.Vertical;
            txt_Results.Size = new Size(310, 284);
            txt_Results.TabIndex = 5;
            // 
            // btn_Generate
            // 
            btn_Generate.Location = new Point(32, 59);
            btn_Generate.Name = "btn_Generate";
            btn_Generate.Size = new Size(310, 23);
            btn_Generate.TabIndex = 4;
            btn_Generate.Text = "Generate Opening Hands";
            btn_Generate.UseVisualStyleBackColor = true;
            // 
            // numud_HandSize
            // 
            numud_HandSize.Location = new Point(282, 30);
            numud_HandSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numud_HandSize.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numud_HandSize.Name = "numud_HandSize";
            numud_HandSize.Size = new Size(60, 23);
            numud_HandSize.TabIndex = 3;
            numud_HandSize.TextAlign = HorizontalAlignment.Right;
            numud_HandSize.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // lbl_HandSize
            // 
            lbl_HandSize.AutoSize = true;
            lbl_HandSize.Location = new Point(200, 32);
            lbl_HandSize.Name = "lbl_HandSize";
            lbl_HandSize.Size = new Size(49, 15);
            lbl_HandSize.TabIndex = 2;
            lbl_HandSize.Text = "Custom";
            // 
            // numud_Draws
            // 
            numud_Draws.Location = new Point(101, 30);
            numud_Draws.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numud_Draws.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numud_Draws.Name = "numud_Draws";
            numud_Draws.Size = new Size(83, 23);
            numud_Draws.TabIndex = 1;
            numud_Draws.TextAlign = HorizontalAlignment.Right;
            numud_Draws.Value = new decimal(new int[] { 10, 0, 0, 0 });
            // 
            // lbl_NumberOfDraws
            // 
            lbl_NumberOfDraws.Anchor = AnchorStyles.Right;
            lbl_NumberOfDraws.AutoSize = true;
            lbl_NumberOfDraws.Location = new Point(32, 32);
            lbl_NumberOfDraws.Name = "lbl_NumberOfDraws";
            lbl_NumberOfDraws.Size = new Size(39, 15);
            lbl_NumberOfDraws.TabIndex = 0;
            lbl_NumberOfDraws.Text = "Draws";
            // 
            // txt_ChipDataView_Left
            // 
            txt_ChipDataView_Left.Dock = DockStyle.Fill;
            txt_ChipDataView_Left.Location = new Point(3, 433);
            txt_ChipDataView_Left.Multiline = true;
            txt_ChipDataView_Left.Name = "txt_ChipDataView_Left";
            txt_ChipDataView_Left.ReadOnly = true;
            txt_ChipDataView_Left.ScrollBars = ScrollBars.Both;
            txt_ChipDataView_Left.Size = new Size(382, 120);
            txt_ChipDataView_Left.TabIndex = 4;
            // 
            // tbl_FolderLayoutPanel
            // 
            tbl_FolderLayoutPanel.ColumnCount = 2;
            tbl_FolderLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_FolderLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tbl_FolderLayoutPanel.Controls.Add(grp_SelectFolder, 0, 0);
            tbl_FolderLayoutPanel.Controls.Add(btn_SaveFolders, 1, 2);
            tbl_FolderLayoutPanel.Controls.Add(btn_NewFolder, 0, 1);
            tbl_FolderLayoutPanel.Controls.Add(btn_DeleteFolder, 1, 1);
            tbl_FolderLayoutPanel.Controls.Add(btn_LoadFolders, 0, 2);
            tbl_FolderLayoutPanel.Dock = DockStyle.Fill;
            tbl_FolderLayoutPanel.Location = new Point(3, 3);
            tbl_FolderLayoutPanel.Name = "tbl_FolderLayoutPanel";
            tbl_FolderLayoutPanel.RowCount = 3;
            tbl_FolderLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tbl_FolderLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tbl_FolderLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tbl_FolderLayoutPanel.Size = new Size(388, 114);
            tbl_FolderLayoutPanel.TabIndex = 5;
            // 
            // grp_SelectFolder
            // 
            grp_SelectFolder.AutoSize = true;
            grp_SelectFolder.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tbl_FolderLayoutPanel.SetColumnSpan(grp_SelectFolder, 2);
            grp_SelectFolder.Controls.Add(cmb_SelectFolder);
            grp_SelectFolder.Dock = DockStyle.Fill;
            grp_SelectFolder.Location = new Point(3, 3);
            grp_SelectFolder.Name = "grp_SelectFolder";
            grp_SelectFolder.Size = new Size(382, 51);
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
            cmb_SelectFolder.Size = new Size(376, 23);
            cmb_SelectFolder.TabIndex = 0;
            // 
            // btn_SaveFolders
            // 
            btn_SaveFolders.Dock = DockStyle.Fill;
            btn_SaveFolders.Location = new Point(197, 88);
            btn_SaveFolders.Name = "btn_SaveFolders";
            btn_SaveFolders.Size = new Size(188, 23);
            btn_SaveFolders.TabIndex = 2;
            btn_SaveFolders.Text = "&Save Folders";
            btn_SaveFolders.UseVisualStyleBackColor = true;
            // 
            // btn_NewFolder
            // 
            btn_NewFolder.Dock = DockStyle.Fill;
            btn_NewFolder.Location = new Point(3, 60);
            btn_NewFolder.Name = "btn_NewFolder";
            btn_NewFolder.Size = new Size(188, 22);
            btn_NewFolder.TabIndex = 0;
            btn_NewFolder.Text = "&New Folder";
            btn_NewFolder.UseVisualStyleBackColor = true;
            // 
            // btn_DeleteFolder
            // 
            btn_DeleteFolder.Dock = DockStyle.Fill;
            btn_DeleteFolder.Location = new Point(197, 60);
            btn_DeleteFolder.Name = "btn_DeleteFolder";
            btn_DeleteFolder.Size = new Size(188, 22);
            btn_DeleteFolder.TabIndex = 1;
            btn_DeleteFolder.Text = "&Delete Folder";
            btn_DeleteFolder.UseVisualStyleBackColor = true;
            // 
            // btn_LoadFolders
            // 
            btn_LoadFolders.Dock = DockStyle.Fill;
            btn_LoadFolders.Location = new Point(3, 88);
            btn_LoadFolders.Name = "btn_LoadFolders";
            btn_LoadFolders.Size = new Size(188, 23);
            btn_LoadFolders.TabIndex = 3;
            btn_LoadFolders.Text = "&Load Folders";
            btn_LoadFolders.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { aboutToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1132, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem1 });
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(52, 20);
            aboutToolStripMenuItem.Text = "About";
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(107, 22);
            aboutToolStripMenuItem1.Text = "About";
            // 
            // frm_DeckBuilder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1132, 745);
            Controls.Add(tbl_MainLayout);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimumSize = new Size(1148, 784);
            Name = "frm_DeckBuilder";
            Text = "Folder Builder";
            tbl_MainLayout.ResumeLayout(false);
            tbl_MainLayout.PerformLayout();
            tbl_GameDetails.ResumeLayout(false);
            tbl_GameDetails.PerformLayout();
            grp_SelectGame.ResumeLayout(false);
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
            grp_NaviCust.ResumeLayout(false);
            tbl_NaviCust.ResumeLayout(false);
            tbl_NaviCust.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numud_CustMega).EndInit();
            ((System.ComponentModel.ISupportInitialize)numud_CustGiga).EndInit();
            tbl_Folder.ResumeLayout(false);
            tbl_Folder.PerformLayout();
            tabControl1.ResumeLayout(false);
            tab_Folder.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgv_Folder).EndInit();
            tab_Checklist.ResumeLayout(false);
            tab_RandomHand.ResumeLayout(false);
            panel_RandomHand.ResumeLayout(false);
            panel_RandomHand.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numud_HandSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numud_Draws).EndInit();
            tbl_FolderLayoutPanel.ResumeLayout(false);
            tbl_FolderLayoutPanel.PerformLayout();
            grp_SelectFolder.ResumeLayout(false);
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tbl_MainLayout;
        private GroupBox grp_SelectFolder;
        private ComboBox cmb_SelectFolder;
        private Button btn_NewFolder;
        private Button btn_DeleteFolder;
        private TableLayoutPanel tbl_GameDetails;
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
        private Label lbl_Error;
        private Label lbl_FolderContents;
        private DataGridView dgv_ChipList;
        private DataGridView dgv_Folder;
        private Label lbl_FilterByCodes;
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
        private Label lbl_FilterByClass;
        private ComboBox cmb_FilterByClass;
        private FlowLayoutPanel flw_Checklist;
        private Label lbl_LocationText;
        private TextBox txt_SearchLocationText;
        private TableLayoutPanel tbl_FolderLayoutPanel;
        private TextBox txt_GameDetails;
        private GroupBox grp_NaviCust;
        private TableLayoutPanel tbl_NaviCust;
        private Label lbl_CustMega;
        private Label lbl_CustGiga;
        private NumericUpDown numud_CustMega;
        private NumericUpDown numud_CustGiga;
        private Panel panel_RandomHand;
        private NumericUpDown numud_Draws;
        private Label lbl_NumberOfDraws;
        private NumericUpDown numud_HandSize;
        private Label lbl_HandSize;
        private Button btn_Generate;
        private TextBox txt_Results;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private TextBox txt_ChipDataView_Right;
    }
}
