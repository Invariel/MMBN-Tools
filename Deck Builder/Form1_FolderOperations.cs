using Deck_Builder.Classes;
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

            _currentFolder = new();
            currentFolders = new();

            try
            {
                Stream loadFileStream;

                if ((loadFileStream = loadFileDialog.OpenFile()) == null)
                {
                    throw new Exception();
                }

                currentFolders = JsonSerializer.Deserialize<List<Folder>>(loadFileStream);

                if (currentFolders is null)
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading file.\n{ex}", "Error Reading File");

                currentFolders = new();
                _currentFolder = new() { GameName = cmb_SelectGame.SelectedValue!.ToString()!, FolderName = string.Empty, Chips = new() };
                SaveCurrentFolder();
            }

            var potentialFolder = currentFolders.FirstOrDefault(cf => cf.GameName.Equals(cmb_SelectGame.SelectedValue));

            if (potentialFolder is not null && cmb_SelectGame.Items.Contains(potentialFolder.GameName))
            {
                _currentFolder = potentialFolder;

                cmb_SelectGame.SelectedIndex = cmb_SelectGame.Items.IndexOf(_currentFolder.GameName);
            }
            else if (potentialFolder is null)
            {
                _currentFolder = new() { GameName = cmb_SelectGame.SelectedValue!.ToString()!, FolderName = string.Empty, Chips = new() };
            }
            else if (_currentFolder is not null && _currentFolder.Chips.Count == 0)
            {
                _currentFolder.GameName = cmb_SelectGame.SelectedValue!.ToString()!;
            }
            else if (_currentFolder is not null && !string.IsNullOrEmpty(_currentFolder.GameName))
            {
                cmb_SelectGame.SelectedIndex = cmb_SelectGame.Items.IndexOf(_currentFolder.GameName);
            }
            else
            {
                _currentFolder = new() { GameName = cmb_SelectGame.SelectedValue!.ToString()!, FolderName = string.Empty, Chips = new() };
            }

            cmb_SelectFolder.DataSource = currentFolders.Select(cf => cf.FolderName).ToList();
            cmb_SelectFolder.SelectedIndex = currentFolders.IndexOf(_currentFolder);

            SaveCurrentFolder();

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
        }

        public void NewFolder()
        {
            AddToCurrentFolders();

            _canUpdateFolder = false;

            // Clear the current deck and reset the folder name.
            _currentFolder = new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };
            cmb_SelectFolder.Text = string.Empty;

            AddToCurrentFolders();

            _canUpdateFolder = true;

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
    }
}