using Deck_Builder.Classes;
using System.Drawing.Text;
using System.Text.Json;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);

        private PrivateFontCollection _internalFonts = new();
        private Font _mmbnFont;

        private Dictionary<GameName, Game> _gameDictionary = new()
        {
            { GameName.MMBN1, new Game { GameName = GameName.MMBN1, Name = "Mega Man Battle Network", JsonFile = "ChipData/MMBN1.json" } },
            { GameName.MMBN2, new Game { GameName = GameName.MMBN2, Name = "Mega Man Battle Network 2", JsonFile = "ChipData/MMBN2.json" } },
            { GameName.MMBN3_Blue, new Game { GameName = GameName.MMBN3_Blue, Name = "Mega Man Battle Network 3 Blue", JsonFile = "ChipData/MMBN3_Blue.json" } },
            { GameName.MMBN3_White, new Game { GameName = GameName.MMBN3_White, Name = "Mega Man Battle Network 3 White", JsonFile = "ChipData/MMBN3_White.json" } },
            { GameName.MMBN4_RedSun, new Game { GameName = GameName.MMBN4_RedSun, Name = "Mega Man Battle Network 4 Red Sun", JsonFile = "ChipData/MMBN4_RedSun.json" } },
            { GameName.MMBN4_BlueMoon, new Game { GameName = GameName.MMBN4_BlueMoon, Name = "Mega Man Battle Network 4 Blue Moon", JsonFile = "ChipData/MMBN4_BlueMoon.json" } },
            { GameName.MMBN5_Protoman, new Game { GameName = GameName.MMBN5_Protoman, Name = "Mega Man Battle Network 5 - Team Protoman", JsonFile = "ChipData/MMBN5_Protoman.json" } },
            { GameName.MMBN5_Colonel, new Game { GameName = GameName.MMBN5_Colonel, Name = "Mega Man Battle Network 5 - Team Colonel", JsonFile = "ChipData/MMBN5_Colonel.json" } },
            { GameName.MMBN6_Falzar, new Game { GameName = GameName.MMBN6_Falzar, Name = "Mega Man Battle Network 6 - Cybeast Falzar", JsonFile = "ChipData/MMBN6_Falzar.json" } },
            { GameName.MMBN6_Gregar, new Game { GameName = GameName.MMBN6_Gregar, Name = "Mega Man Battle Network 6 - Cybeast Gregar", JsonFile = "ChipData/MMBN6_Gregar.json" } }
        };

        private List<string> _availableGames = new();

        private bool _pauseUpdates = false;

        private Folder _currentFolder = new();
        private BindingSource dgv_FolderBindingSource;

        public frm_DeckBuilder()
        {
            InitializeComponent();

            ConfigureMMBNFont();
            _mmbnFont = new Font(_internalFonts.Families[0], 10.0f);

            AssignFonts();

            LoadGamesAndBattlechips();

            // Set up the game dropdown.
            cmb_SelectGame.DataSource = _availableGames;
            cmb_SelectGame.SelectedIndexChanged += LoadSelectedGameData;
            cmb_SelectGame.SelectedIndex = 0;

            // Set up the chip list.
            dgv_ChipList.AutoGenerateColumns = false;
            dgv_ChipList.DataSource = GetCurrentGame().Gamechips();

            dgv_ChipList.Columns.Add("Number", "No.");
            dgv_ChipList.Columns[0].DataPropertyName = "Number";
            dgv_ChipList.Columns[0].Width = 40;

            dgv_ChipList.Columns.Add("Name", "Name");
            dgv_ChipList.Columns[1].DataPropertyName = "Name";

            dgv_ChipList.Columns.Add("Elem", "Element");
            dgv_ChipList.Columns[2].DataPropertyName = "Element";

            dgv_ChipList.Columns.Add("Code", "Code");
            dgv_ChipList.Columns[3].DataPropertyName = "Code";
            dgv_ChipList.Columns[3].Width = 60;

            dgv_ChipList.CellClick += ShowChipData;
            dgv_ChipList.CellDoubleClick += AddChipToFolder;
            dgv_ChipList.EditMode = DataGridViewEditMode.EditProgrammatically;

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

            dgv_Folder.Columns.Add("ChipClass", "Class");
            dgv_Folder.Columns[2].DataPropertyName = "ChipClass";

            dgv_Folder.Columns.Add("Quantity", "Qty");
            dgv_Folder.Columns[3].DataPropertyName = "Quantity";
            dgv_Folder.Columns[3].Width = 30;

            dgv_Folder.CellClick += ShowFolderChipData;
            dgv_Folder.CellDoubleClick += RemoveChipFromFolder;
            dgv_Folder.EditMode = DataGridViewEditMode.EditProgrammatically;

            _currentFolder.GameName = GetCurrentGame().GameName;
        }

        public void LoadSelectedGameData (object? sender, EventArgs e)
        {
            // Save the existing folder if it is not empty.
            //SaveCurrentFolder();

            // Start a new folder for the selected game.
            // Unload the battle chips from the dgv.
            // Load the new game's battle chips into the dgv.
            // Move the dgv to the top, sort by chip number [reset the dgv, this should be done as part of loading maybe? and its own func]
        }

        /// <summary>
        /// Font: https://www.dafont.com/mega-man-battle-network.font
        /// How to Use the Font in WinForms: https://stackoverflow.com/questions/556147/how-do-i-embed-my-own-fonts-in-a-winforms-app
        /// </summary>
        internal void ConfigureMMBNFont()
        {
            byte[] mmbnFontData = Properties.Resources.MegaManBattleNetworkFont;
            IntPtr mmbnFontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(mmbnFontData.Length);

            System.Runtime.InteropServices.Marshal.Copy(mmbnFontData, 0, mmbnFontPtr, mmbnFontData.Length);

            uint dummy = 0;

            _internalFonts.AddMemoryFont(mmbnFontPtr, Properties.Resources.MegaManBattleNetworkFont.Length);
            AddFontMemResourceEx(mmbnFontPtr, (uint)Properties.Resources.MegaManBattleNetworkFont.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(mmbnFontPtr);
        }

        internal void AssignFonts()
        {
            cmb_SelectFolder.Font = _mmbnFont;
            cmb_SelectGame.Font = _mmbnFont;
            txt_FilterByName.Font = _mmbnFont;
            cmb_FilterByElement.Font = _mmbnFont;

            lbl_FilterByElement.Font = _mmbnFont;
            lbl_FilterByName.Font = _mmbnFont;

            dgv_ChipList.Font = _mmbnFont;

            lbl_Error.Font = _mmbnFont;
            lbl_ChipDataView_Left.Font = _mmbnFont;
            lbl_ChipDataView_Right.Font = _mmbnFont;
        }

        internal void LoadGamesAndBattlechips()
        {
            foreach (var kvp in _gameDictionary)
            {
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), kvp.Value.JsonFile);

                if (File.Exists(filePath))
                {
                    string fileText = File.ReadAllText(filePath);

                    if (fileText is not null)
                    {
                        kvp.Value.Battlechips = JsonSerializer.Deserialize<List<Battlechip>>(fileText) ?? new();
                        kvp.Value.Battlechips.ForEach(c => c.CalculateChipCodes());
                        _availableGames.Add(kvp.Value.Name);
                    }
                }
            }
        }

        internal Game GetCurrentGame()
            => _gameDictionary.FirstOrDefault(g => cmb_SelectGame.Text == g.Value.Name).Value;

        internal string GetChipTypeFromEnum(ChipClass chipClass)
        {
            return chipClass switch
            {
                ChipClass.Standard => "Standard",
                ChipClass.Mega => "Mega",
                ChipClass.Giga => "Giga",
                ChipClass.Dark => "Dark",
                _ => throw new NotSupportedException()
            };
        }
    }
}
