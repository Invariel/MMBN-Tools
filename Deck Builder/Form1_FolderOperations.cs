using Deck_Builder.Classes;
using System.Text;
using System.Text.Json;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder : Form
    {
        public bool SaveCurrentFolder(string previousName)
        {
            Folder? updatedFolder = null;

            if (!_canUpdateFolder)
            {
                return false;
            }

            if (string.IsNullOrEmpty(previousName))
            {
                updatedFolder = currentFolders.FirstOrDefault(f => f.FolderName.Equals(previousName));
            }

            if (updatedFolder is null)
            {
                updatedFolder = currentFolders.FirstOrDefault(f => f.FolderName.Equals(cmb_SelectFolder.Text));
            }

            // Write the current deck to the folder, along with its name.
            if (updatedFolder is null)
            {
                currentFolders.Add(_currentFolder);
            }
            else
            {
                updatedFolder = _currentFolder;
            }

            return true;
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
                if (!currentFolders.Contains(_currentFolder))
                {
                    currentFolders.Add(_currentFolder);
                }

                var jsonFile = JsonSerializer.Serialize(currentFolders);
                var file = saveFileDialog.OpenFile();
                file.Write(Encoding.UTF8.GetBytes(jsonFile));
                file.Flush();
                file.Close();
            }
        }

        public void LoadSelectedFolder()
        {
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

            if (result.Equals(DialogResult.OK))
            {
                _currentFolder = new();
                currentFolders = new();

                var jsonFile = loadFileDialog.OpenFile();
                var bytes = jsonFile.Length;

                byte[] fileBytes = new byte[bytes];
                jsonFile.ReadExactly(fileBytes, 0, (int)bytes);

                currentFolders = JsonSerializer.Deserialize<List<Folder>>(Encoding.UTF8.GetString(fileBytes))!;
            }

            (cmb_SelectFolder.DataSource as BindingSource).DataSource = currentFolders.Select (cf => cf.FolderName).ToList();

            cmb_SelectFolder.SelectedIndex = 0;
            _currentFolder = currentFolders.FirstOrDefault(f => f.FolderName.Equals(cmb_SelectFolder.Text)) ?? new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
        }

        public void NewFolder()
        {
            SaveCurrentFolder(cmb_SelectFolder.Text);

            _canUpdateFolder = false;
            // Clear the current deck and reset the folder name.
            cmb_SelectFolder.Text = "";
            _currentFolder = new Folder() { GameName = cmb_SelectGame.Text, Chips = new(), FolderName = string.Empty };

            _canUpdateFolder = true;

            dgv_FolderBindingSource.DataSource = null;
            dgv_FolderBindingSource.DataSource = _currentFolder.Chips;
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