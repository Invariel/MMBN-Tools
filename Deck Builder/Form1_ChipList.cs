using Deck_Builder.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        const int COLUMN_CHIP_NUMBER = 0;
        const int COLUMN_CHIP_NAME = 1;
        const int COLUMN_CHIP_ELEMENT = 2;
        const int COLUMN_CHIP_CODE_1 = 3;

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
                lbl_ChipDataView_Right.Text = CalculateLabelText(battlechip);
            }
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
            var gameChip = game.Battlechips.First(b => b.Number == selectedChip.Number);

            lbl_ChipDataView_Left.Text = CalculateLabelText(gameChip);
        }

        public string CalculateLabelText (Battlechip chip)
            =>
$"""
{chip.Name} {chip.Damage} x {chip.Hits} {chip.Element}

{chip.Description}

{string.Join('\n', chip.Locations.Split(';').Select(l => l.Trim()))}

Traders: {chip.Traders}
""";


        public void RemoveChipFromFolder(object? sender, DataGridViewCellEventArgs e)
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

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
        }

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

            switch (chip.ChipType)
            {
                case ChipType.Standard:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameStandardChip;
                        maxSameChipClassQuantity = game.Rules.MaxFolderSize;
                    }
                    break;
                case ChipType.Mega:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameMegaChip;
                        maxSameChipClassQuantity = game.Rules.MaxMegaChips;
                    }
                    break;
                case ChipType.Giga:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameGigaChip;
                        maxSameChipClassQuantity = game.Rules.MaxGigaChips;
                    }
                    break;
                case ChipType.Dark:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameDarkChip;
                        maxSameChipClassQuantity = game.Rules.MaxDarkChips;
                    }
                    break;
            }

            if (chipQuantity >= maxSameChipQuantity)
            {
                return (false, $"Cannot have more than {maxSameChipQuantity} of the same {GetChipTypeFromEnum(chip.ChipType)} chip in a folder.");
            }

            if (chipClassQuantity >= maxSameChipClassQuantity)
            {
                return (false, $"Cannot have more than {maxSameChipClassQuantity} {GetChipTypeFromEnum(chip.ChipType)} chip{(maxSameChipClassQuantity == 1 ? "" : "s")} in a folder.");
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
    }
}
