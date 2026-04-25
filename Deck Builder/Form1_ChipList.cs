using Deck_Builder.Classes;
using System.Text;
using Deck_Builder.Extensions;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        const int COLUMN_CHIP_NUMBER = 0;
        const int COLUMN_CHIP_NAME = 1;
        const int COLUMN_CHIP_ELEMENT = 2;


        const int COLUMN_FOLDER_NAME = 0;
        const int COLUMN_FOLDER_CODE = 1;
        const int COLUMN_FOLDER_TYPE = 2;
        const int COLUMN_FOLDER_QUANTITY = 3;
        const int COLUMN_FOLDER_DECREMENT = 4;
        const int COLUMN_FOLDER_REMOVE = 5;

        #region dgv_ChipList
        public void dgv_ChipList_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var cell = dgv_ChipList[e.ColumnIndex, e.RowIndex];
            var rowData = cell.OwningRow;

            if (rowData is null || cell is null)
            {
                return;
            }

            Battlechip? battlechip = GetCurrentGame().Battlechips.FirstOrDefault(c => c.Number == int.Parse(rowData.Cells[COLUMN_CHIP_NUMBER].Value!.ToString() ?? "-1") && c.Name.Equals(rowData.Cells[COLUMN_CHIP_NAME].Value!.ToString()));

            if (battlechip is null)
            {
                return;
            }

            // If column is number, name, or element then show the chip data.  Otherwise, add the selected chip code to the folder if non-empty.
            if (cell is DataGridViewButtonCell && !string.IsNullOrEmpty(cell.Value?.ToString() ?? string.Empty))
            {
                string? chipCode = cell.Value?.ToString();

                if (battlechip is null || string.IsNullOrEmpty(chipCode))
                {
                    lbl_Error.Text = "Some error clicking on cell.";
                    return;
                }

                // Add chip code to folder.
                var result = TryAddChipToFolder(battlechip, chipCode);

                if (result.success)
                {
                    lbl_Error.Text = "Chip added successfully.";
                    dgv_FolderBindingSource.DataSource = null;
                    dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
                }
                else
                {
                    lbl_Error.Text = result.error;
                }
            }
            else
            {
                txt_ChipDataView_Right.Text = CalculateLabelText(battlechip);
            }
        }

        public void dgv_ChipList_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_ChipList.SelectedCells.Count == 0)
            {
                return;
            }

            var cell = dgv_ChipList.SelectedCells[0];
            var rowData = cell.OwningRow;

            if (rowData is null || cell is null)
            {
                return;
            }

            Battlechip? battlechip = GetCurrentGame().Battlechips.FirstOrDefault(c => c.Number == int.Parse(rowData.Cells[COLUMN_CHIP_NUMBER].Value!.ToString() ?? "-1") && c.Name.Equals(rowData.Cells[COLUMN_CHIP_NAME].Value!.ToString()));

            if (battlechip is null)
            {
                return;
            }

            txt_ChipDataView_Right.Text = CalculateLabelText(battlechip);
        }

        public void dgv_ChipList_Sort(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != COLUMN_CHIP_NUMBER && e.ColumnIndex != COLUMN_CHIP_ELEMENT)
            {
                return;
            }

            var headerCell = dgv_ChipList.Columns[e.ColumnIndex].HeaderCell;

            headerCell.SortGlyphDirection = (headerCell.SortGlyphDirection == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

            switch (e.ColumnIndex)
            {
                case COLUMN_CHIP_NUMBER:
                    _currentGameChips.Sort();
                    if (headerCell.SortGlyphDirection == SortOrder.Descending)
                    {
                        _currentGameChips.Reverse();
                    }
                    break;
                case COLUMN_CHIP_ELEMENT:
                    _currentGameChips.Sort((a, b) =>
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

            AddBattlechipsToChipList(_currentGameChips);
        }

        public void dgv_ChipList_Filter(object? sender, EventArgs e)
        {
            var battlechips = GetCurrentGame().Battlechips;

            foreach (DataGridViewColumn column in dgv_ChipList.Columns)
            {
                column.HeaderCell.SortGlyphDirection = SortOrder.None;
            }

            if (!string.IsNullOrEmpty(txt_FilterByName.Text))
            {
                battlechips = battlechips.Where(c => c.Name.ToLower().Contains(txt_FilterByName.Text.Trim().ToLower())).ToList();
            }

            if (cmb_FilterByElement.SelectedIndex != Enum.GetValues<ChipElement>().Length - 1)
            {
                battlechips = battlechips.Where(c => c.Element.Equals(Enum.GetValues<ChipElement>()[cmb_FilterByElement.SelectedIndex])).ToList();
            }

            if (!string.IsNullOrEmpty(txt_FilterByCodes.Text))
            {
                var chipCodes = txt_FilterByCodes.Text.ToUpper().ToCharArray().Select(c => c.ToString()).ToArray();
                battlechips = battlechips.Where(c => c.Codes.Split(",").Select(c => c.Trim()).Intersect(chipCodes).Any()).ToList();
            }

            if (cmb_FilterByClass.SelectedItem!.ToString() != "None")
            {
                battlechips = battlechips.Where(c => c.ChipType.IsChipType(GetChipTypeFromString(cmb_FilterByClass.SelectedItem!.ToString()!))).ToList();
            }
            
            if (!string.IsNullOrEmpty(txt_SearchLocationText.Text.Trim()))
            {
                battlechips = battlechips.Where(c => c.Locations.Contains(txt_SearchLocationText.Text.Trim().ToLower(), StringComparison.CurrentCultureIgnoreCase)).ToList();
            }

            dgv_ChipList.Rows.Clear();

            AddBattlechipsToChipList(battlechips);
        }

        public void AddBattlechipsToChipList(List<Battlechip> battlechips)
        {
            _currentGameChips = battlechips;

            int maxCodes = GetCurrentGame().Battlechips.Max(c => c.Codes.Split(",").Length);

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
        #endregion

        #region dgv_Folder
        public void dgv_Folder_Clicked(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var rowData = dgv_Folder.Rows[e.RowIndex];

            if (rowData is null || rowData.DataBoundItem is null || rowData.DataBoundItem as FolderChip is null)
            {
                return;
            }

            var selectedChip = rowData.DataBoundItem as FolderChip;

            if (selectedChip is null)
            {
                return;
            }

            if (e.ColumnIndex == dgv_Folder.Columns[COLUMN_FOLDER_DECREMENT].Index)
            {
                RemoveChipFromFolder(sender, e);

                dgv_FolderBindingSource.DataSource = null;
                dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
            }
            else if (e.ColumnIndex == dgv_Folder.Columns[COLUMN_FOLDER_REMOVE].Index)
            {
                _currentFolder.Chips.Remove(selectedChip);

                dgv_FolderBindingSource.DataSource = null;
                dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
            }
            else
            {
                ShowFolderChipData(sender, e);
            }
        }

        public void dgv_Folder_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgv_Folder.SelectedCells.Count == 0)
            {
                return;
            }
            var cell = dgv_Folder.SelectedCells[0];
            var rowData = cell.OwningRow;
            if (rowData is null || rowData.DataBoundItem is null || rowData.DataBoundItem as FolderChip is null)
            {
                return;
            }

            var selectedChip = rowData.DataBoundItem as FolderChip;
            if (selectedChip is null)
            {
                return;
            }

            ShowFolderChipData(sender, new DataGridViewCellEventArgs(cell.ColumnIndex, cell.RowIndex));
        }

        public void dgv_Folder_Sort(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == COLUMN_FOLDER_DECREMENT || e.ColumnIndex == COLUMN_FOLDER_REMOVE)
            {
                return;
            }

            var headerCell = dgv_Folder.Columns[e.ColumnIndex].HeaderCell;
            var sortGlyphDirection = (headerCell.SortGlyphDirection == SortOrder.Ascending) ? SortOrder.Descending : SortOrder.Ascending;

            switch (e.ColumnIndex)
            {
                case COLUMN_FOLDER_NAME:
                    _currentFolder.Chips = _currentFolder.Chips.OrderBy(c => c.Name).ToList();
                    if (sortGlyphDirection == SortOrder.Descending)
                    {
                        _currentFolder.Chips.Reverse();
                    }
                    break;
                case COLUMN_FOLDER_CODE:
                    _currentFolder.Chips = _currentFolder.Chips.OrderBy(c => c.Code).ToList();
                    if (sortGlyphDirection == SortOrder.Descending)
                    {
                        _currentFolder.Chips.Reverse();
                    }
                    break;
                case COLUMN_FOLDER_TYPE:
                    _currentFolder.Chips = _currentFolder.Chips.OrderBy(c => c.ChipType).ThenBy(c => c.Number).ToList();
                    if (sortGlyphDirection == SortOrder.Descending)
                    {
                        _currentFolder.Chips.Reverse();
                    }
                    break;
                case COLUMN_FOLDER_QUANTITY:
                    _currentFolder.Chips = _currentFolder.Chips.OrderBy(c => c.Quantity).ThenBy(c => c.Name).ToList();
                    if (sortGlyphDirection == SortOrder.Descending)
                    {
                        _currentFolder.Chips.Reverse();
                    }
                    break;
            }

            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
            headerCell.SortGlyphDirection = sortGlyphDirection;
        }

        public void ShowFolderChipData(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var rowData = dgv_Folder.Rows[e.RowIndex];

            if (rowData is null || rowData.DataBoundItem is null || rowData.DataBoundItem as FolderChip is null)
            {
                return;
            }

            var selectedChip = rowData.DataBoundItem as FolderChip;

            if (selectedChip is null)
            {
                return;
            }

            var game = GetCurrentGame();
            var gameChip = game.Battlechips.First(b => b.Number == selectedChip.Number && b.ChipType == selectedChip.ChipType);

            txt_ChipDataView_Left.Text = CalculateLabelText(gameChip, selectedChip.Code);
        }
        #endregion

        public string CalculateLabelText(Battlechip chip, string? code = null)
            =>
$"""
{chip.Name} {chip.Damage} x {chip.Hits} {chip.Element}

{chip.Description}

{(code is null ?
    string.Join(Environment.NewLine, chip.Locations.Split(';').Select(l => l.Trim())) :
    chip.Locations.Split(';').Select(l => l.Trim()).First(c => c.StartsWith(code)))}

{(string.IsNullOrEmpty(chip.Traders) ? "" : $"Traders: {chip.Traders}")}
""";


        public (bool success, string error) TryAddChipToFolder (Battlechip chip, string chipCode)
        {
            var game = GetCurrentGame();

            if (chip is null)
            {
                return (false, "Bad Battlechip data.");
            }

            if (_currentFolder.Chips.Sum(c => c.Quantity) >= game.Rules.MaxFolderSize)
            {
                return (false, "Cannot have more than 30 chips in a folder.");
            }

            int chipQuantity = _currentFolder.Chips.Sum(c => (c.Number == chip.Number && c.ChipType == chip.ChipType ? c.Quantity : 0));
            int chipClassQuantity = _currentFolder.Chips.Sum(c => c.ChipType == chip.ChipType ? c.Quantity : 0);

            int maxSameChipQuantity = 0;
            int maxSameChipClassQuantity = 0;

            if (chip.ChipType.IsChipType(ChipType.Standard))
            {
                maxSameChipQuantity = game.Rules.MaxSameStandardChip;
                maxSameChipClassQuantity = game.Rules.MaxFolderSize;
            }
            else if (chip.ChipType.IsChipType(ChipType.Mega))
            {
                maxSameChipQuantity = game.Rules.MaxSameMegaChip;
                maxSameChipClassQuantity = game.Rules.MaxMegaChips + (int)numud_CustMega.Value;
            }
            else if (chip.ChipType.IsChipType(ChipType.Giga))
            {
                maxSameChipQuantity = game.Rules.MaxSameGigaChip;
                maxSameChipClassQuantity = game.Rules.MaxGigaChips + (int)numud_CustGiga.Value;
            }
            else if (chip.ChipType.IsChipType(ChipType.Dark))
            {
                maxSameChipQuantity = game.Rules.MaxSameDarkChip;
                maxSameChipClassQuantity = game.Rules.MaxDarkChips;
            }
            else
            {
                throw new InvalidOperationException("Chip type is not recognized.");
            }

            if (chipQuantity >= maxSameChipQuantity)
            {
                return (false, $"Cannot have more than {maxSameChipQuantity} of the same {GetDeckChipTypeFromEnum(chip.ChipType)} chip in a folder.");
            }

            if (chipClassQuantity >= maxSameChipClassQuantity)
            {
                return (false, $"Cannot have more than {maxSameChipClassQuantity} {GetDeckChipTypeFromEnum(chip.ChipType)} chip{(maxSameChipClassQuantity == 1 ? "" : "s")} in a folder.");
            }

            var existingChip = _currentFolder.Chips.FirstOrDefault(c => c.Number == chip.Number && c.ChipType == chip.ChipType && c.Code == chipCode);
            if (existingChip is not null)
            {
                existingChip.Quantity++;
            }
            else
            {
                _currentFolder.Chips.Add(new FolderChip { Number = chip.Number, Name = chip.Name, ChipType = chip.ChipType, Code = chipCode, Quantity = 1 });
            }

            return (true, string.Empty);
        }

        public void RemoveChipFromFolder(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dgv_Folder.Rows.Count)
            {
                return;
            }

            var rowData = dgv_Folder.Rows[e.RowIndex];

            if (rowData is null || rowData.DataBoundItem is null || rowData.DataBoundItem as FolderChip is null)
            {
                return;
            }

            var selectedChip = rowData.DataBoundItem as FolderChip;

            if (selectedChip is null)
            {
                return;
            }

            var folderChip = _currentFolder.Chips.FirstOrDefault(c => c.Number == selectedChip.Number && c.ChipType == selectedChip.ChipType && c.Code == selectedChip.Code);

            if (folderChip is null)
            {
                // Something may have gone horribly wrong.  Fix later.
                return;
            }

            --folderChip.Quantity;

            if (folderChip.Quantity <= 0)
            {
                _currentFolder.Chips.Remove(folderChip);
            }

            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
        }

        public void GenerateChecklist()
        {
            flw_Checklist.Controls.Clear();

            for (int i = 0; i < _currentFolder.Chips.Count; ++ i)
            {
                var folderChip = _currentFolder.Chips[i];
                var battleChip = GetCurrentGame().Battlechips.First(c => c.Number == folderChip.Number && c.ChipType == folderChip.ChipType);

                string chipLocation = NiceWrap(battleChip.Locations.Split(';').Select(l => l.Trim()).First(c => c.StartsWith(folderChip.Code)));

                var checkbox = new CheckBox
                {
                    Anchor = AnchorStyles.Left | AnchorStyles.Right,
                    AutoSize = false,
                    Margin = new Padding(5),
                    Text = $"{folderChip.Name} {folderChip.Code} x{folderChip.Quantity}\n{chipLocation}",
                    TextAlign = ContentAlignment.TopLeft,
                    Width = tab_Checklist.Width - 30,
                };

                checkbox.Height = checkbox.Text.Split('\n').Length * (checkbox.Font.Height) + 5;
                flw_Checklist.Controls.Add(checkbox);
            }
        }

        public string NiceWrap (string str)
        {
            var words = str.Split(" ");
            var newString = new StringBuilder();

            int currentLine = 0;

            foreach (var word in words)
            {
                var currentWord = word.Replace("\r", string.Empty).Replace("\n", string.Empty);

                if (currentLine + currentWord.Length + 1 > 35)
                {
                    newString.AppendLine();
                    currentLine = 0;
                }

                newString.Append($"{currentWord} ");
                currentLine += currentWord.Length + 1;
            }

            return newString.ToString();
        }
    }
}
