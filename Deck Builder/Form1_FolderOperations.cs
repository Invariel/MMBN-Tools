using Deck_Builder.Classes;
using Deck_Builder.Extensions;
using System.Collections.Immutable;
using System.Text;
using System.Text.Json;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        public void AddToCurrentFolders()
        {
            if (!currentFolders.Any(f => f.Equals(_currentFolder)))
            {
                currentFolders.Add(_currentFolder);
            }

            _currentFolder.FolderName = cmb_SelectFolder.Text;

            cmb_SelectFolder.DataSource = currentFolders.Select(cf => cf.FolderName).ToList();
            cmb_SelectFolder.SelectedIndex = currentFolders.IndexOf(_currentFolder);
        }

        public void SaveCurrentFolder()
        {
            AddToCurrentFolders();
        }

        public void SaveAllFolders()
        {
            string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MMBN Folder Creator");

            if (!Path.Exists(defaultPath))
            {
                Directory.CreateDirectory(defaultPath);
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Folders to File";
            saveFileDialog.InitialDirectory = defaultPath;
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.RestoreDirectory = true;

            DialogResult result = saveFileDialog.ShowDialog();

            if (result.Equals(DialogResult.OK))
            {
                AddToCurrentFolders();

                var jsonFile = JsonSerializer.Serialize(currentFolders);
                var file = saveFileDialog.OpenFile();
                file.Write(Encoding.UTF8.GetBytes(jsonFile));
                file.Flush();
                file.Close();
            }
        }

        public void LoadSelectedFolder()
        {
            _currentFolder = currentFolders.FirstOrDefault(f => f.FolderName.Equals(cmb_SelectFolder.Text)) ?? new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };

            if (!cmb_SelectGame.Items.Contains(_currentFolder.GameName))
            {
                MessageBox.Show(
                    $"Data for {_currentFolder.GameName} has not been loaded.  " +
                    $"Please include {_currentFolder.GameName}.json in the ChipData directory.",
                    "Error - Specified Game not Loaded",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);

                _currentFolder = new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };
            }

            if (!_currentFolder.GameName.Equals(cmb_SelectGame.SelectedValue!.ToString()!))
            {
                var newFolder = _currentFolder;

                cmb_SelectGame.SelectedIndex = cmb_SelectGame.Items.IndexOf(_currentFolder.GameName);

                _currentFolder = newFolder;
            }

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;

            numud_CustMega.Value = _currentFolder.AdditionalMegaChips;
            numud_CustGiga.Value = _currentFolder.AdditionalGigaChips;
        }

        public void LoadAllFolders()
        {
            string defaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "MMBN Folder Creator");

            OpenFileDialog loadFileDialog = new OpenFileDialog();
            loadFileDialog.InitialDirectory = defaultPath;
            loadFileDialog.AddToRecent = true;
            loadFileDialog.Multiselect = false;
            loadFileDialog.Title = "Load Folder File";

            DialogResult result = loadFileDialog.ShowDialog();

            if (!result.Equals(DialogResult.OK))
            {
                return;
            }

            try
            {
                Stream loadFileStream;

                if ((loadFileStream = loadFileDialog.OpenFile()) == null)
                {
                    throw new Exception();
                }

                var loadedFolders = JsonSerializer.Deserialize<List<Folder>>(loadFileStream);

                if (loadedFolders is null)
                {
                    throw new Exception($"No folders were found in the selected file {loadFileDialog.FileName}");
                }

                currentFolders = loadedFolders;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file.\n{ex}", "Error Reading File", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string currentGameName = cmb_SelectGame.SelectedValue!.ToString()!;
            _currentFolder = currentFolders.FirstOrDefault(cf => cf.GameName.Equals(currentGameName))
                ?? currentFolders.FirstOrDefault(f => cmb_SelectGame.Items.Contains(f.GameName))
                ?? new Folder() { GameName = currentGameName, Chips = new(), FolderName = string.Empty };

            string folderName = _currentFolder.FolderName;

            cmb_SelectGame.SelectedIndex = cmb_SelectGame.Items.IndexOf(_currentFolder.GameName);

            _currentFolder.FolderName = folderName; // I hate having to do this.

            cmb_SelectFolder.DataSource = currentFolders.Select(cf => cf.FolderName).ToList();
            cmb_SelectFolder.SelectedIndex = currentFolders.IndexOf(_currentFolder);

            SaveCurrentFolder();

            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
        }

        public void NewFolder()
        {
            AddToCurrentFolders();

            // Clear the current deck and reset the folder name.
            _currentFolder = new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };
            cmb_SelectFolder.Text = string.Empty;

            AddToCurrentFolders();

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
        }

        public void ChangeFolders(object? sender, EventArgs e)
        {
            int selected = cmb_SelectFolder.SelectedIndex;

            SaveCurrentFolder();

            cmb_SelectFolder.SelectedIndex = selected;

            LoadSelectedFolder();
        }

        public void DeleteFolder(object? sender, EventArgs e)
        {
            Folder folderToDelete = _currentFolder;
            _currentFolder = new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };

            if (currentFolders.Contains(folderToDelete))
            {
                currentFolders.Remove(folderToDelete);
            }

            if (currentFolders.Count == 0)
            {
                currentFolders.Add(_currentFolder);
            }

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;

            cmb_SelectFolder.DataSource = null;
            cmb_SelectFolder.DataSource = currentFolders.Select(cf => cf.FolderName).ToList();

            cmb_SelectFolder.SelectedIndex = 0;
        }

        public (bool, string) IsFolderValid (Folder folder)
        {
            var game = _availableGames.FirstOrDefault(g => g.Name.Equals(folder.GameName));
            int allCodesChipQuantity = 0;

            if (game is null)
            {
                return (false, $"Game {folder.GameName} not found.");
            }

            var gameRules = game.Rules;

            if (gameRules.MaxFolderSize < folder.Chips.Sum(c => c.Quantity))
            {
                return (false, $"More than {gameRules.MaxFolderSize} chip{(gameRules.MaxFolderSize == 1 ? "" : "s")} in the folder.");
            }

            foreach (var chipByName in folder.Chips.Select(c => c.Name))
            {
                allCodesChipQuantity = folder.Chips.Where(c => chipByName.Equals(c.Name)).Sum(c => c.Quantity);

                switch (folder.Chips.First(c => c.Name.Equals(chipByName)).Game_ChipType)
                {
                    case ChipType.Standard:
                        if (allCodesChipQuantity > gameRules.MaxSameStandardChip)
                        {
                            return (false, $"More than {gameRules.MaxSameStandardChip} cop{(gameRules.MaxSameStandardChip == 1 ? "y" : "ies")} of {chipByName}.");
                        }
                    break;
                    case ChipType.Mega:
                        if (allCodesChipQuantity > gameRules.MaxSameMegaChip + (int)numud_CustMega.Value)
                        {
                            return (false, $"More than {gameRules.MaxSameMegaChip + (int)numud_CustMega.Value} cop{(gameRules.MaxSameMegaChip + (int)numud_CustMega.Value == 1 ? "y" : "ies")} of {chipByName}.");
                        }
                    break;
                    case ChipType.Giga:
                        if (allCodesChipQuantity > gameRules.MaxSameGigaChip + (int)numud_CustGiga.Value)
                        {
                            return (false, $"More than {gameRules.MaxSameGigaChip + (int)numud_CustGiga.Value} cop{(gameRules.MaxSameGigaChip + (int)numud_CustGiga.Value == 1 ? "y" : "ies")} of {chipByName}.");
                        }
                    break;
                    case ChipType.Dark:
                        if (allCodesChipQuantity > gameRules.MaxSameDarkChip)
                        {
                            return (false, $"More than {gameRules.MaxSameDarkChip} cop{(gameRules.MaxSameDarkChip == 1 ? "y" : "ies")} of {chipByName}.");
                        }
                    break;
                }
            }

            if (folder.Chips.Where(c => c.ChipType.IsChipType(ChipType.Standard)).Sum(c => c.Quantity) > gameRules.MaxFolderSize)
            {
                return (false, $"More than {gameRules.MaxFolderSize} Standard chip{(gameRules.MaxFolderSize == 1 ? "" : "s")} in the folder.");
            }

            if (folder.Chips.Where(c => c.ChipType.IsChipType(ChipType.Mega)).Sum(c => c.Quantity) > gameRules.MaxMegaChips + (int)numud_CustMega.Value)
            {
                return (false, $"More than {gameRules.MaxMegaChips + (int)numud_CustMega.Value} Mega chip{(gameRules.MaxMegaChips + (int)numud_CustMega.Value == 1 ? "" : "s")} in the folder.");
            }

            if (folder.Chips.Where(c => c.ChipType.IsChipType(ChipType.Giga)).Sum(c => c.Quantity) > gameRules.MaxGigaChips + (int)numud_CustGiga.Value)
            {
                return (false, $"More than {gameRules.MaxGigaChips + (int)numud_CustGiga.Value} Giga chip{(gameRules.MaxGigaChips + (int)numud_CustGiga.Value == 1 ? "" : "s")} in the folder.");
            }

            if (folder.Chips.Where(c => c.ChipType.IsChipType(ChipType.Dark)).Sum(c => c.Quantity) > gameRules.MaxDarkChips)
            {
                return (false, $"More than {gameRules.MaxDarkChips} Dark chip{(gameRules.MaxDarkChips == 1 ? "" : "s")} in the folder.");
            }

            return (true, string.Empty);
        }

        public string GenerateRandomHands(int draws, int customSize)
        {
            Dictionary<string, int> chipFrequency = new();
            List<int> numberOfChips = new();

            if (_currentFolder.Chips.Sum(c => c.Quantity) < (int)GetCurrentGame().Rules.MaxFolderSize)
            {
                return "A full folder is required to generate random hands.";
            }

            List<FolderChip> entireFolder = new();
            foreach (var chip in _currentFolder.Chips)
            {
                for (int i = 0; i < chip.Quantity; i++)
                {
                    entireFolder.Add(new FolderChip() { Name = chip.Name, Code = chip.Code, Quantity = 1 });
                }
            }

            for (int i = 0; i < draws; ++ i)
            {
                var hand = GenerateRandomHand(entireFolder, customSize);

                foreach (var chip in hand)
                {
                    string key = $"{chip.Name, 8} {chip.Code}";
                    if (!chipFrequency.ContainsKey(key))
                    {
                        chipFrequency[key] = 0;
                    }
                    chipFrequency[key] ++;
                }

                var mostCommonName = hand.GroupBy(c => c.Name).Select(g => new { Name = g.Key, Quantity = g.Sum(c => c.Quantity) }).OrderByDescending(g => g.Quantity).ThenBy(g => g.Name).First();
                var starCodes = hand.Where(c => c.Code.Equals("*")).ToList();
                var mostCommonCode =
                    hand
                        .Except(starCodes)
                        .GroupBy(c => c.Code)
                        .Select(g => new { Code = g.Key, Quantity = hand.Where(c => c.Code.Equals(g.Key)).Count() })
                        .OrderByDescending(g => g.Quantity)
                        .ThenBy(g => g.Code)
                        .First();

                int numChips = Math.Min(5, Math.Max(mostCommonName.Quantity, mostCommonCode.Quantity + starCodes.Count));

                numberOfChips.Add(numChips);
            }

            StringBuilder sb = new();
            int line = 0;

            int[] handSizes = 
            {
                numberOfChips.Count(c => c == 5),
                numberOfChips.Count(c => c == 4),
                numberOfChips.Count(c => c == 3),
                numberOfChips.Count(c => c == 2),
                numberOfChips.Count(c => c == 1)
            };

            int freqWidth = (int)Math.Log10(draws) + 1;

            foreach (var frequency in chipFrequency.OrderByDescending(kv => kv.Value))
            {
                string frequencyLine = $"{frequency.Key}: {frequency.Value.ToString().PadLeft(freqWidth)} ({Math.Round((double)frequency.Value / draws * 100, 2), 5}%)";
                sb.Append($"{frequencyLine, -25}");

                if (line < 5)
                {
                    string handSizeLine = $"[{5 - line}]: {handSizes[line].ToString().PadLeft(freqWidth)}";
                    sb.Append($"{handSizeLine, 10}");
                    ++line;
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        public List<FolderChip> GenerateRandomHand(List<FolderChip> folder, int customSize)
        {
            List<FolderChip> shuffleFolder = new List<FolderChip>();
            shuffleFolder.AddRange(folder);

            Random random = new Random();
            for (int i = 0; i < random.Next(10); ++ i)
            {
                shuffleFolder = shuffleFolder.Shuffle().ToList();
            }

            return shuffleFolder.Take(customSize).ToList();
        }
    }
}