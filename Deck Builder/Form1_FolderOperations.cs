using Deck_Builder.Classes;

namespace Deck_Builder
{
    public partial class frm_DeckBuilder
    {
        internal List<Folder> currentFolders = new();

        public bool SaveCurrentFolder (string previousName)
        {
            Folder? updatedFolder = null;

            if (string.IsNullOrEmpty (previousName))
            {
                updatedFolder = currentFolders.FirstOrDefault(f => f.Name.Equals(previousName));
            }

            if (updatedFolder is null)
            {
                updatedFolder = currentFolders.FirstOrDefault(f => f.Name.Equals(cmb_SelectFolder.Text));
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

        public bool SaveAllFolders ()
        {
            // Write JSON to disk.
            throw new NotImplementedException();
        }

        public bool LoadSelectedFolder()
        {
            throw new NotImplementedException();

        }

        public bool LoadAllFolders ()
        {
            // Load JSON from file.
            throw new NotImplementedException();
        }
    }
}
