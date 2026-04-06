using Deck_Builder.Classes;

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

        public bool SaveAllFolders()
        {
            // Write JSON to disk.
            throw new NotImplementedException();
        }

        public bool LoadSelectedFolder()
        {
            throw new NotImplementedException();

        }

        public bool LoadAllFolders()
        {
            // Load JSON from file.
            throw new NotImplementedException();
        }

        public void NewFolder(object? sender, EventArgs e)
        {
            SaveCurrentFolder(cmb_SelectFolder.Text);

            _canUpdateFolder = false;
            // Clear the current deck and reset the folder name.
            cmb_SelectFolder.Text = "";
            _currentFolder = new Folder();

            _canUpdateFolder = true;
        }
    }
}
