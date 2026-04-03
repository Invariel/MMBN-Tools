using Deck_Builder.Classes;
using System.Collections;
using System.ComponentModel;
using System.Drawing.Text;
using System.Globalization;
using System.Resources;
using System.Text;
using System.Text.Json;
using System.Windows.Forms.VisualStyles;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection _internalFonts = new();
        private Font _mmbnFont;

        private List<Game> _availableGames = new();

        private bool _pauseUpdates = false;

        private Folder _currentFolder = new();
        private BindingSource dgv_FolderBindingSource;

        public frm_DeckBuilder()
        {
            InitializeComponent();

            ConfigureMMBNFont();
            _mmbnFont = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);

            AssignFonts();

            LoadGamesAndBattlechips();

            // Set up the game dropdown.
            cmb_SelectGame.DataSource = _availableGames.Select(g => g.Name).ToList();
            cmb_SelectGame.SelectedIndexChanged += LoadSelectedGameData;
            cmb_SelectGame.SelectedIndex = 0;


            // Set up the folder.
            dgv_FolderBindingSource = new();
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;

            dgv_FolderBindingSource.DataSourceChanged += delegate
            {
                dgv_Folder.Refresh();

                if (dgv_FolderBindingSource.DataSource is not null)
                {
                    lbl_FolderContents.Text = _currentFolder.ToString();
                }
            };

            dgv_Folder.AutoGenerateColumns = false;
            dgv_Folder.DataSource = dgv_FolderBindingSource;

            dgv_Folder.Columns.Add("Name", "Name");
            dgv_Folder.Columns[0].DataPropertyName = "Name";

            dgv_Folder.Columns.Add("Code", "Code");
            dgv_Folder.Columns[1].DataPropertyName = "Code";

            dgv_Folder.Columns.Add("ChipType", "Class");
            dgv_Folder.Columns[2].DataPropertyName = "ChipType";

            dgv_Folder.Columns.Add("Quantity", "Qty");
            dgv_Folder.Columns[3].DataPropertyName = "Quantity";
            dgv_Folder.Columns[3].Width = 30;

            dgv_Folder.CellClick += ShowFolderChipData;
            dgv_Folder.CellDoubleClick += RemoveChipFromFolder;
            dgv_Folder.EditMode = DataGridViewEditMode.EditProgrammatically;

            _currentFolder.GameName = GetCurrentGame().Name;

            LoadSelectedGameData(default, new ());
        }

        public void LoadSelectedGameData (object? sender, EventArgs e)
        {
            // Save the existing folder if it is not empty.
            //SaveCurrentFolder();

            // Start a new folder for the selected game.
            // Unload the battle chips from the dgv.
            // Load the new game's battle chips into the dgv.
            Create_dgv_ChipList();
            AddBattlechips(GetCurrentGame().Battlechips);
            // Move the dgv to the top, sort by chip number [reset the dgv, this should be done as part of loading maybe? and its own func]
        }

        public void AddBattlechips(List<Battlechip> battlechips)
        {
            int maxCodes = battlechips.Max(c => c.Codes.Split(",").Length);

            foreach (Battlechip chip in battlechips)
            {
                List<string> codes = chip.Codes.Split(",").Select(c => c.Trim().ToUpper()).ToList();
                while (codes.Count < maxCodes)
                {
                    codes.Add(string.Empty);
                }

                List<string> elements = new List<string> { chip.Number.ToString(), chip.Name, chip.Element.ToString() };
                elements.AddRange(codes);

                dgv_ChipList.Rows.Add(elements.ToArray());
            }
        }

        public void dgv_ChipList_Sort (object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != COLUMN_CHIP_NUMBER && e.ColumnIndex != COLUMN_CHIP_ELEMENT)
            {
                return;
            }

            var headerCell = dgv_ChipList.Columns[e.ColumnIndex].HeaderCell;

            headerCell.SortGlyphDirection = (headerCell.SortGlyphDirection == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

            var battlechips = GetCurrentGame().Battlechips;

            switch (e.ColumnIndex)
            {
                case COLUMN_CHIP_NUMBER:
                    battlechips.Sort();
                    if (headerCell.SortGlyphDirection == SortOrder.Descending)
                    {
                        battlechips.Reverse();
                    }
                    break;
                case COLUMN_CHIP_ELEMENT:
                    battlechips.Sort((a, b) =>
                    {
                        int elementComparison = a.Element.CompareTo(b.Element) * (headerCell.SortGlyphDirection == SortOrder.Ascending ? 1 : -1);
                        if (elementComparison != 0)
                        {
                            return elementComparison;
                        }
                        return a.Number.CompareTo(b.Number);
                    });
                    break;
            }

            dgv_ChipList.Rows.Clear();

            AddBattlechips(battlechips);
        }

        public void Create_dgv_ChipList()
        {
            dgv_ChipList.Rows.Clear();
            dgv_ChipList.AllowUserToAddRows = false;
            dgv_ChipList.AllowUserToDeleteRows = false;

            dgv_ChipList.CellClick -= dgv_ChipList_Clicked;
            dgv_ChipList.ColumnHeaderMouseClick -= dgv_ChipList_Sort;

            int maxCodes = GetCurrentGame().Battlechips.Max(c => c.Codes.Split(",").Length);

            dgv_ChipList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataPropertyName = "Number",
                Name = "No.",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = _mmbnFont
                },
                SortMode = DataGridViewColumnSortMode.Programmatic
            });

            dgv_ChipList.Columns.Add(new DataGridViewTextBoxColumn()
            {
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DataPropertyName = "Name",
                Name = "Name",
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Alignment = DataGridViewContentAlignment.MiddleLeft,
                    Font = _mmbnFont
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
                    Font = _mmbnFont
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
                        Alignment = DataGridViewContentAlignment.MiddleLeft,
                        Font = CreateFont("BN6FontBig", 12)
                    },
                    SortMode = DataGridViewColumnSortMode.NotSortable
                });
            }

            dgv_ChipList.CellClick += dgv_ChipList_Clicked;
            dgv_ChipList.ColumnHeaderMouseClick += dgv_ChipList_Sort;
            dgv_ChipList.EditMode = DataGridViewEditMode.EditProgrammatically;
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
            cmb_SelectFolder.Font = CreateFont("BN6FontBig", 16);
            cmb_SelectGame.Font = CreateFont("BN6FontBig", 16);
            txt_FilterByName.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);
            cmb_FilterByElement.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);

            lbl_FilterByElement.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);
            lbl_FilterByName.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);

            dgv_ChipList.Font = CreateFont("BN6FontThinVar", 12);

            lbl_Error.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);
            lbl_ChipDataView_Left.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);
            lbl_ChipDataView_Right.Font = new Font(_internalFonts.Families.First(f => f.Name.Equals("BN6FontBig")), 14);
        }

        internal void LoadGamesAndBattlechips()
        {
            var gameDirectory = Path.Combine(Directory.GetCurrentDirectory(), "ChipData");
            var gameFiles = Directory.GetFiles(gameDirectory, "*.json");

            foreach (var gameFile in gameFiles)
            {
                string filePath = Path.Combine(gameDirectory, gameFile);

                if (File.Exists(filePath))
                {
                    string fileText = File.ReadAllText(filePath);
                    if (fileText is not null)
                    {
                        Game game = JsonSerializer.Deserialize<Game>(fileText) ?? new();
                        _availableGames.Add(game);
                    }
                }
            }
        }

        internal Game GetCurrentGame()
            => _availableGames.FirstOrDefault(game => game.Name.Equals(cmb_SelectGame.Text)) ?? new Game();

        internal string GetChipTypeFromEnum(ChipType chipClass)
        {
            return chipClass switch
            {
                ChipType.Standard => "Standard",
                ChipType.Mega => "Mega",
                ChipType.Giga => "Giga",
                ChipType.Dark => "Dark",
                _ => throw new NotSupportedException()
            };
        }
    }
}
