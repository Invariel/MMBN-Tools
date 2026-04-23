using Deck_Builder.Classes;
using Deck_Builder.Extensions;
using System.Collections;
using System.Drawing.Text;
using System.Globalization;
using System.Text.Json;

namespace Deck_Builder;

public partial class frm_DeckBuilder : Form
{
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

    private PrivateFontCollection _internalFonts = new();

    private List<Game> _availableGames = new();

    private List<Battlechip> _currentGameChips = new();

    internal List<Folder> currentFolders = new();
    private Folder _currentFolder = new();

    private BindingSource dgv_FolderBindingSource = new();

    private System.Timers.Timer _timer = new();
    private int _cycle = 0;
    private List<PictureBox> _zeroLights = new();
    private List<PictureBox> _oneLights = new();
    private List<PictureBox> _twoLights = new();

    private Image _zeroLight = new Bitmap("./Images/Light_00.gif");
    private Image _oneLight = new Bitmap("./Images/Light_01.gif");
    private Image _twoLight = new Bitmap("./Images/Light_02.gif");

    ~frm_DeckBuilder()
    {
        _timer.Dispose();
        _zeroLight.Dispose();
        _oneLight.Dispose();
        _twoLight.Dispose();
    }

    public frm_DeckBuilder()
    {
        InitializeComponent();

        ConfigureMMBNFont();

        AssignFonts();

        LoadGamesAndBattlechips();

        // Set up the game dropdown.
        cmb_SelectGame.DataSource = _availableGames.Select(g => g.Name).ToList();
        cmb_SelectGame.SelectedIndexChanged += LoadSelectedGameData;
        cmb_SelectGame.SelectedIndex = 0;

        _currentFolder.GameName = GetCurrentGame().Name;

        cmb_FilterByElement.DataSource = Enum.GetValues<ChipElement>().Cast<ChipElement>().Select(e => e.ToString()).ToList();
        cmb_FilterByElement.SelectedItem = "None";
        cmb_FilterByElement.SelectionChangeCommitted += dgv_ChipList_Filter;

        txt_FilterByName.TextChanged += dgv_ChipList_Filter;
        txt_FilterByCodes.TextChanged += dgv_ChipList_Filter;

        cmb_FilterByClass.SelectedIndex = 0;
        cmb_FilterByClass.SelectionChangeCommitted += dgv_ChipList_Filter;

        txt_SearchLocationText.TextChanged += dgv_ChipList_Filter;

        LoadSelectedGameData(default, new ());

        BindingSource folderList = new BindingSource();
        folderList.DataSource = currentFolders.Select(f => f.FolderName).ToList();

        cmb_SelectFolder.DataSource = folderList;
        cmb_SelectFolder.SelectionChangeCommitted += ChangeFolders;

        btn_NewFolder.Click += delegate
        {
            NewFolder();
        };

        btn_SaveFolders.Click += delegate { SaveAllFolders(); };
        btn_LoadFolders.Click += delegate { LoadAllFolders(); };

        btn_DeleteFolder.Click += DeleteFolder;

        numud_CustMega.ValueChanged += delegate
        {
            txt_GameDetails.Text = GenerateGameDetails();

            lbl_FolderContents.Text = _currentFolder.ToString();

            (bool valid, string error) = IsFolderValid(_currentFolder);

            lbl_FolderContents.BackColor = valid ? lbl_ChipDataView_Right.BackColor : Color.Red;
            lbl_FolderContents.Text = valid ? lbl_FolderContents.Text : "Invalid folder: " + error + "\n";

            _currentFolder.AdditionalMegaChips = (int)numud_CustMega.Value;
        };

        numud_CustGiga.ValueChanged += delegate
        {
            txt_GameDetails.Text = GenerateGameDetails();

            lbl_FolderContents.Text = _currentFolder.ToString();

            (bool valid, string error) = IsFolderValid(_currentFolder);

            lbl_FolderContents.BackColor = valid ? lbl_ChipDataView_Right.BackColor : Color.Red;
            lbl_FolderContents.Text = valid ? lbl_FolderContents.Text : "Invalid folder: " + error + "\n";

            _currentFolder.AdditionalGigaChips = (int)numud_CustGiga.Value;
        };

        _currentFolder.GameName = cmb_SelectGame.Text;

        CreateTheLights();

        _timer.Elapsed += SwapTheLights;
        _timer.Interval = 250;
        _timer.AutoReset = true;
        _timer.Enabled = true;

        btn_Generate.Click += delegate { txt_Results.Text = GenerateRandomHands((int)numud_Draws.Value, (int)numud_HandSize.Value); };
    }

    public void CreateTheLights ()
    {
        int count = 0;
        int i = 0;
        int j = 0;

        PictureBox lastPictureBox = null!;

        // Top
        for (i = 8; i < panel_RandomHand.Width; i += 16)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Parent = panel_RandomHand;
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.Dock = DockStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point(i, 16);

            switch (count)
            {
                case 0:
                    pictureBox.Image = _zeroLight;
                    _zeroLights.Add(pictureBox);
                    break;
                case 1:
                    pictureBox.Image = _oneLight;
                    _oneLights.Add(pictureBox);
                    break;
                case 2:
                    pictureBox.Image = _twoLight;
                    _twoLights.Add(pictureBox);
                    break;
            }

            count = (++count) % 3;
            lastPictureBox = pictureBox;
        }

        i -= 16;

        for (j = lastPictureBox!.Location.Y + 16; j < tab_RandomHand.Height; j += 16)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Parent = panel_RandomHand;
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.Dock = DockStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point(i, j);

            switch (count)
            {
                case 0:
                    pictureBox.Image = _zeroLight;
                    _zeroLights.Add(pictureBox);
                    break;
                case 1:
                    pictureBox.Image = _oneLight;
                    _oneLights.Add(pictureBox);
                    break;
                case 2:
                    pictureBox.Image = _twoLight;
                    _twoLights.Add(pictureBox);
                    break;
            }

            count = (++count) % 3;
            lastPictureBox = pictureBox;
        }

        j -= 16;

        for (; i > 0; i -= 16)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Parent = panel_RandomHand;
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.Dock = DockStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point(i, j);
            switch (count)
            {
                case 0:
                    pictureBox.Image = _zeroLight;
                    _zeroLights.Add(pictureBox);
                    break;
                case 1:
                    pictureBox.Image = _oneLight;
                    _oneLights.Add(pictureBox);
                    break;
                case 2:
                    pictureBox.Image = _twoLight;
                    _twoLights.Add(pictureBox);
                    break;
            }
            count = (++count) % 3;
            lastPictureBox = pictureBox;
        }

        i += 16;

        for (; j > 0; j -= 16)
        {
            PictureBox pictureBox = new PictureBox();
            pictureBox.Parent = panel_RandomHand;
            pictureBox.Anchor = AnchorStyles.None;
            pictureBox.Dock = DockStyle.None;
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox.Location = new Point(i, j);
            switch (count)
            {
                case 0:
                    pictureBox.Image = _zeroLight;
                    _zeroLights.Add(pictureBox);
                    break;
                case 1:
                    pictureBox.Image = _oneLight;
                    _oneLights.Add(pictureBox);
                    break;
                case 2:
                    pictureBox.Image = _twoLight;
                    _twoLights.Add(pictureBox);
                    break;
            }
            count = (++count) % 3;
            lastPictureBox = pictureBox;
        }
    }

    private void UpdateLight (PictureBox light, Image image)
    {
        if (!this.IsDisposed && !this.Disposing)
        {
            try
            {
                this.Invoke(new Action(() => light.Image = image));
            }
            catch (Exception)
            {
                // Intentionally blank.
            }
        }
    }

    public void SwapTheLights (object? sender, System.Timers.ElapsedEventArgs e)
    {
        _cycle = (_cycle + 2) % 3;

        switch (_cycle)
        {
            case 0:
                foreach (var light in _zeroLights) { UpdateLight (light, _zeroLight); }
                foreach (var light in _oneLights) { UpdateLight (light, _oneLight); }
                foreach (var light in _twoLights) { UpdateLight (light, _twoLight); }
                break;
            case 1:
                foreach (var light in _zeroLights) { UpdateLight (light, _oneLight); }
                foreach (var light in _oneLights) { UpdateLight (light, _twoLight); }
                foreach (var light in _twoLights) { UpdateLight (light, _zeroLight); }
                break;
            case 2:
                foreach (var light in _zeroLights) { UpdateLight (light, _twoLight); }
                foreach (var light in _oneLights) { UpdateLight (light, _zeroLight); }
                foreach (var light in _twoLights) { UpdateLight (light, _oneLight); }
                break;
        }
    }

    public void LoadSelectedGameData (object? sender, EventArgs e)
    {
        if (_currentFolder.Chips.Count > 0)
        {
            SaveCurrentFolder();

            if (!_currentFolder.GameName.Equals(cmb_SelectGame.SelectedValue))
            {
                _currentFolder = new() { GameName = cmb_SelectGame.SelectedValue!.ToString()!, Chips = new(), FolderName = string.Empty };
                SaveCurrentFolder();
            }
        }
        else
        {
            _currentFolder.GameName = cmb_SelectGame.SelectedValue!.ToString()!;
            SaveCurrentFolder();
        }

        // Load the new game's battle chips into the dgv.
        Create_dgv_ChipList();
        Create_dgv_Folder();
        AddBattlechipsToChipList(GetCurrentGame().Battlechips);

        lbl_ChipDataView_Right.Text = "";
        txt_ChipDataView_Left.Text = "";

        cmb_SelectFolder.DataSource = currentFolders.Select(cf => cf.FolderName).ToList();
        var index = currentFolders.IndexOf(_currentFolder);
        cmb_SelectFolder.SelectedIndex = index;

        txt_GameDetails.Text = GenerateGameDetails();

        numud_HandSize.Maximum = GetCurrentGame().Rules.MaxCustomChips;
        if (numud_HandSize.Value > numud_HandSize.Maximum)
        {
            numud_HandSize.Value = 5;
        }
    }

    public string GenerateGameDetails ()
    {
        var game = GetCurrentGame();

        bool hasDarkChips = game.Battlechips.Any(c => c.ChipType.IsChipType(ChipType.Dark)) && game.Rules.MaxDarkChips > 0;

return
$"""
Standard: {game.Battlechips.Count(c => c.ChipType.IsChipType(ChipType.Standard)), 3} | Max Same: {game.Rules.MaxSameStandardChip, 2} | Max in Folder: {game.Rules.MaxFolderSize, 3}{(hasDarkChips ? $" |{"",-10}Dark: {game.Battlechips.Count(c => c.ChipType.IsChipType(ChipType.Dark)), 3}" : ""), -1}
Mega    : {game.Battlechips.Count(c => c.ChipType.IsChipType(ChipType.Mega)), 3} | Max Same: {game.Rules.MaxSameMegaChip, 2} | Max in Folder: {game.Rules.MaxMegaChips + (int)numud_CustMega.Value, 3}{(hasDarkChips ? $" |{"",-10} Max: {game.Rules.MaxDarkChips, 3}" : ""), -1}
Giga    : {game.Battlechips.Count(c => c.ChipType.IsChipType(ChipType.Giga)), 3} | Max Same: {game.Rules.MaxSameGigaChip, 2} | Max in Folder: {game.Rules.MaxGigaChips + (int)numud_CustGiga.Value, 3}{(hasDarkChips ? $" |{"",-10}Same: {game.Rules.MaxSameDarkChip,3}" : ""), -1}
""";
    }

    public void Create_dgv_ChipList()
    {
        dgv_ChipList.Rows.Clear();
        dgv_ChipList.Columns.Clear();
        dgv_ChipList.AllowUserToAddRows = false;
        dgv_ChipList.AllowUserToDeleteRows = false;

        dgv_ChipList.CellClick -= dgv_ChipList_Clicked;
        dgv_ChipList.ColumnHeaderMouseClick -= dgv_ChipList_Sort;
        dgv_ChipList.SelectionChanged -= dgv_ChipList_SelectionChanged;

        dgv_ChipList.RowHeadersWidth = 4;

        int maxCodes = GetCurrentGame().Battlechips.Max(c => c.Codes.Split(",").Length);

        dgv_ChipList.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            DataPropertyName = "Number",
            Name = "No.",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = CreateFont("BN6FontBold", 16)
            },
            SortMode = DataGridViewColumnSortMode.Programmatic
        });

        dgv_ChipList.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            DataPropertyName = "Name",
            Name = "Name",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = CreateFont("BN6FontBold", 16)
            },
            SortMode = DataGridViewColumnSortMode.Automatic
        });

        dgv_ChipList.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            DataPropertyName = "Element",
            Name = "Element",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = CreateFont("BN6FontBold", 16)
            },
            SortMode = DataGridViewColumnSortMode.Programmatic
        });

        for (int i = 0; i < maxCodes; ++i)
        {
            dgv_ChipList.Columns.Add(new DataGridViewButtonColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Font = CreateFont("BN6FontTiny", 18)
                },
                SortMode = DataGridViewColumnSortMode.NotSortable
            });
        }

        dgv_ChipList.CellClick += dgv_ChipList_Clicked;
        dgv_ChipList.ColumnHeaderMouseClick += dgv_ChipList_Sort;
        dgv_ChipList.SelectionChanged += dgv_ChipList_SelectionChanged;

        dgv_ChipList.EditMode = DataGridViewEditMode.EditProgrammatically;
    }

    public void Create_dgv_Folder()
    {
        dgv_Folder.CellClick -= dgv_Folder_Clicked;
        dgv_Folder.ColumnHeaderMouseClick -= dgv_Folder_Sort;
        dgv_Folder.SelectionChanged -= dgv_Folder_SelectionChanged;
        dgv_Folder.EditMode = DataGridViewEditMode.EditProgrammatically;

        // Set up the folder.
        dgv_FolderBindingSource = new();

        dgv_FolderBindingSource.DataSourceChanged += delegate
        {
            dgv_Folder.Refresh();

            if (dgv_FolderBindingSource.DataSource is not null)
            {
                lbl_FolderContents.Text = _currentFolder.ToString();

                (bool valid, string error) = IsFolderValid(_currentFolder);

                lbl_FolderContents.BackColor = valid ? lbl_ChipDataView_Right.BackColor : Color.Red;
                lbl_FolderContents.Text = valid ? lbl_FolderContents.Text : "Invalid folder: " + error + "\n";

                GenerateChecklist();
            }
        };

        dgv_FolderBindingSource.DataSource = _currentFolder.Chips;

        dgv_Folder.Columns.Clear();

        dgv_Folder.AutoGenerateColumns = false;
        dgv_Folder.DataSource = dgv_FolderBindingSource;
        dgv_Folder.RowHeadersWidth = 4;

        dgv_Folder.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill,
            DataPropertyName = "Name",
            Name = "Name",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleLeft,
                Font = CreateFont("BN6FontBold", 14),
                Padding = new Padding(0, 0, 0, 0)
            },
            SortMode = DataGridViewColumnSortMode.Programmatic
        });

        dgv_Folder.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            DataPropertyName = "Code",
            Name = "Code",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = CreateFont("BN6FontTiny", 18),
                Padding = new Padding(0, 0, 0, 0)
            },
            SortMode = DataGridViewColumnSortMode.Programmatic
        });

        dgv_Folder.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            DataPropertyName = "Game_ChipType",
            Name = "Class",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = CreateFont("BN6FontBigCond", 14),
                Padding = new Padding(0, 0, 0, 0)
            },
            SortMode = DataGridViewColumnSortMode.Programmatic
        });

        dgv_Folder.Columns.Add(new DataGridViewTextBoxColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            DataPropertyName = "Quantity",
            Name = "Qty",
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = CreateFont("BN6FontBold", 14),
                Padding = new Padding(0, 0, 0, 0)
            },
            SortMode = DataGridViewColumnSortMode.Programmatic
        });

        dgv_Folder.Columns.Add(new DataGridViewButtonColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            Name = "-1",
            Text = "-",
            UseColumnTextForButtonValue = true,
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = CreateFont("BN6FontTiny", 18)
            },
        });

        dgv_Folder.Columns.Add(new DataGridViewButtonColumn()
        {
            AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
            Name = "X",
            Text = "X",
            UseColumnTextForButtonValue = true,
            DefaultCellStyle = new DataGridViewCellStyle()
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Font = CreateFont("BN6FontTiny", 18)
            },
        });

        dgv_Folder.CellClick += dgv_Folder_Clicked;
        dgv_Folder.ColumnHeaderMouseClick += dgv_Folder_Sort;
        dgv_Folder.SelectionChanged += dgv_Folder_SelectionChanged;
        dgv_Folder.EditMode = DataGridViewEditMode.EditProgrammatically;
    }

    /// <summary>
    /// Font: https://www.dafont.com/mega-man-battle-network.font
    /// How to Use the Font in WinForms: https://stackoverflow.com/questions/556147/how-do-i-embed-my-own-fonts-in-a-winforms-app
    /// </summary>
    internal void ConfigureMMBNFont()
    {
        foreach (DictionaryEntry font in Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true)!)
        {
            if (font.Value is byte[] fontData)
            {
                IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
                System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
                uint dummy = 0;
                _internalFonts.AddMemoryFont(fontPtr, fontData.Length);
                AddFontMemResourceEx(fontPtr, (uint)fontData.Length, IntPtr.Zero, ref dummy);
                System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);
            }
        }
    }

    private Font CreateFont (string fontFace, float fontSize)
        => new Font (_internalFonts.Families.First(f => f.Name.Equals(fontFace)), fontSize);

    internal void AssignFonts()
    {
        btn_NewFolder.Font = CreateFont("BN6FontBig", 14);
        btn_DeleteFolder.Font = CreateFont("BN6FontBig", 14);
        btn_SaveFolders.Font = CreateFont("BN6FontBig", 14);
        btn_LoadFolders.Font = CreateFont("BN6FontBig", 14);

        lbl_FilterByName.Font = CreateFont("BN6FontSmall", 14);
        txt_FilterByName.Font = CreateFont("BN6FontBold", 14);

        lbl_FilterByElement.Font = CreateFont("BN6FontSmall", 14);
        cmb_FilterByElement.Font = CreateFont("BN6FontBold", 14);

        lbl_FilterByCodes.Font = CreateFont("BN6FontSmall", 14);
        txt_FilterByCodes.Font = CreateFont("BN6FontTiny", 14);

        lbl_FilterByClass.Font = CreateFont("BN6FontSmall", 14);
        cmb_FilterByClass.Font = CreateFont("BN6FontBold", 14);

        lbl_LocationText.Font = CreateFont("BN6FontSmall", 14);
        txt_SearchLocationText.Font = CreateFont("BN6FontBold", 14);

        txt_ChipDataView_Left.Font = CreateFont("BN6FontSmall", 14);
        lbl_ChipDataView_Right.Font = CreateFont("BN6FontSmall", 14);
        lbl_Error.Font = CreateFont("BN6FontSmall", 14);
        lbl_FolderContents.Font = CreateFont("BN6FontSmall", 12);

        dgv_ChipList.Font = CreateFont("BN6FontThinVar", 12);
        dgv_Folder.Font = CreateFont("BN6FontThinVar", 12);

        tabControl1.Font = CreateFont("BN6FontBig", 14);
        tab_Checklist.Font = CreateFont("BN6FontThin", 12);

        grp_FilterChips.Font = CreateFont("BN6FontBig", 14);
        grp_SelectFolder.Font = CreateFont("BN6FontBig", 14);
        grp_SelectGame.Font = CreateFont("BN6FontBig", 14);
        grp_NaviCust.Font = CreateFont("BN6FontBig", 14);

        cmb_SelectFolder.Font = CreateFont("BN6FontBig", 14);
        cmb_SelectGame.Font = CreateFont("BN6FontBig", 14);

        txt_GameDetails.Font = CreateFont("BN6FontSmall", 14);

        lbl_CustMega.Font = CreateFont("BN6FontSmall", 14);
        lbl_CustGiga.Font = CreateFont("BN6FontSmall", 14);

        numud_CustMega.Font = CreateFont("BN6FontBold", 16);
        numud_CustGiga.Font = CreateFont("BN6FontBold", 16);

        lbl_NumberOfDraws.Font = CreateFont("BN6FontSmall", 14);
        lbl_HandSize.Font = CreateFont("BN6FontSmall", 14);

        numud_Draws.Font = CreateFont("BN6FontBold", 16);
        numud_HandSize.Font = CreateFont("BN6FontBold", 16);

        btn_Generate.Font = CreateFont("BN6FontBig", 14);

        txt_Results.Font = CreateFont("BN6FontThin", 14);
    }

    internal void LoadGamesAndBattlechips()
    {
        var gameDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ChipData");
        var gameFiles = Directory.GetFiles(gameDirectory, "*.json");

        foreach (var gameFile in gameFiles)
        {
            if (File.Exists(gameFile))
            {
                string fileText = File.ReadAllText(gameFile);
                if (fileText is not null)
                {
                    try
                    {
                        Game game = JsonSerializer.Deserialize<Game>(fileText) ?? new();
                        _availableGames.Add(game);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Could not load {gameFile}.", $"Error Loading {gameFile}");
                        File.WriteAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MMBN Folder Creator", "error.txt"), ex.ToString());
                    }
                }
            }
        }

        if (_availableGames.Count == 0)
        {
            MessageBox.Show("No games loaded.\nThe program cannot function without game data.\nPlease ensure that the ChipData folder is in the ChipData subdirectory and contains valid .json files.", "No Games Loaded", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }

    internal Game GetCurrentGame()
        => _availableGames.FirstOrDefault(game => game.Name.Equals(cmb_SelectGame.Text)) ?? new Game();

    internal string GetDeckChipTypeFromEnum(int chipClass)
    {
        if (chipClass.IsChipType(ChipType.Standard)) { return "Standard"; }
        if (chipClass.IsChipType(ChipType.Mega)) { return "Mega"; }
        if (chipClass.IsChipType(ChipType.Giga)) { return "Giga"; }
        if (chipClass.IsChipType(ChipType.Dark)) { return "Dark"; }
        if (chipClass.IsSecretChip()) { return "Secret"; }
        if (chipClass.IsUnregisteredChip()) { return "Unregistered"; }

        return "None";
    }

    internal ChipType GetChipTypeFromString(string chipClass)
    {
        if (chipClass.Equals("Standard", StringComparison.OrdinalIgnoreCase)) { return ChipType.Standard; }
        if (chipClass.Equals("Mega", StringComparison.OrdinalIgnoreCase)) { return ChipType.Mega; }
        if (chipClass.Equals("Giga", StringComparison.OrdinalIgnoreCase)) { return ChipType.Giga; }
        if (chipClass.Equals("Dark", StringComparison.OrdinalIgnoreCase)) { return ChipType.Dark; }
        return ChipType.None;
    }
}