using Deck_Builder.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        public void ShowChipData(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var rowData = dgv_ChipList.Rows[e.RowIndex];

            if (rowData is null || rowData.DataBoundItem is null || rowData.DataBoundItem as GameChip is null)
            {
                return;
            }

            var selectedChip = rowData.DataBoundItem as GameChip;

            if (selectedChip is null)
            {
                return;
            }

            var game = GetCurrentGame();
            var gameChip = game.Battlechips.First(b => b.Number == selectedChip.Number);

            lbl_ChipDataView_Right.Text = CalculateLabelText(gameChip);
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
{chip.Name} {chip.Damage} x {chip.Hits}
{chip.Description}
{string.Join('\n', chip.CalculateChipCodes().Select(d => d.Location))}
Traders: {chip.Traders}
""";


        public void AddChipToFolder(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var rowData = dgv_ChipList.Rows[e.RowIndex];

            if (rowData is null || rowData.DataBoundItem is null || rowData.DataBoundItem as GameChip is null)
            {
                return;
            }

            var selectedChip = rowData.DataBoundItem as GameChip;

            if (selectedChip is null)
            {
                return;
            }

            var result = TryAddChipToFolder(selectedChip);

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

            var folderChip = _currentFolder.Chips.FirstOrDefault(c => c.Number == selectedChip.Number && c.ChipClass == selectedChip.ChipClass && c.Code == selectedChip.Code);

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

        public (bool success, string error) TryAddChipToFolder (GameChip gameChip)
        {
            var game = GetCurrentGame();
            var battleChip = game.Battlechips.FirstOrDefault(c => c.Number == gameChip.Number);

            if (battleChip is null)
            {
                return (false, "Bad Battlechip data.");
            }

            if (_currentFolder.Chips.Sum(c => c.Quantity) >= game.Rules.MaxFolderSize)
            {
                return (false, "Cannot have more than 30 chips in a folder.");
            }

            int chipQuantity = _currentFolder.Chips.Sum(c => (c.Number == gameChip.Number && c.ChipClass == gameChip.ChipClass ? c.Quantity : 0));
            int chipClassQuantity = _currentFolder.Chips.Sum(c => c.ChipClass == gameChip.ChipClass ? c.Quantity : 0);

            int maxSameChipQuantity = 0;
            int maxSameChipClassQuantity = 0;

            switch (battleChip.ChipClass)
            {
                case ChipClass.Standard:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameStandardChip;
                        maxSameChipClassQuantity = game.Rules.MaxFolderSize;
                    }
                    break;
                case ChipClass.Mega:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameMegaChip;
                        maxSameChipClassQuantity = game.Rules.MaxMegaChips;
                    }
                    break;
                case ChipClass.Giga:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameGigaChip;
                        maxSameChipClassQuantity = game.Rules.MaxGigaChips;
                    }
                    break;
                case ChipClass.Dark:
                    {
                        maxSameChipQuantity = game.Rules.MaxSameDarkChip;
                        maxSameChipClassQuantity = game.Rules.MaxDarkChips;
                    }
                    break;
            }

            if (chipQuantity >= maxSameChipQuantity)
            {
                return (false, $"Cannot have more than {maxSameChipQuantity} of the same {GetChipTypeFromEnum(battleChip.ChipClass)} chip in a folder.");
            }

            if (chipClassQuantity >= maxSameChipClassQuantity)
            {
                return (false, $"Cannot have more than {maxSameChipClassQuantity} {GetChipTypeFromEnum(battleChip.ChipClass)} chip{(maxSameChipClassQuantity == 1 ? "" : "s")} in a folder.");
            }

            var existingChip = _currentFolder.Chips.FirstOrDefault(c => c.Number == gameChip.Number && c.ChipClass == gameChip.ChipClass && c.Code == gameChip.Code);
            if (existingChip is not null)
            {
                existingChip.Quantity++;
            }
            else
            {
                _currentFolder.Chips.Add(new FolderChip { Number = gameChip.Number, Name = gameChip.Name, ChipClass = gameChip.ChipClass, Code = gameChip.Code, Quantity = 1 });
            }

            return (true, string.Empty);
        }
    }
}
