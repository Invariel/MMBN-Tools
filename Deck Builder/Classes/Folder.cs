namespace Deck_Builder.Classes
{
    public class Folder
    {
        public string GameName { get; set; } = string.Empty;
        public string FolderName { get; set; } = string.Empty;
        public List<FolderChip> Chips { get; set; } = new List<FolderChip>();

        public bool IsFolderValid ()
        {
            if (Chips.Count != 30)
            {
                return false;
            }

            foreach (FolderChip battlechip in Chips)
            {
                // Chip rules based on type (standard, mega, giga) and quantity
            }

            return true;
        }

        public override string ToString()
        {
            int standard = 0;
            int mega = 0;
            int giga = 0;
            int dark = 0;

            foreach (FolderChip chip in Chips)
            {
                switch (chip.ChipType)
                {
                    case ChipType.Standard: standard += chip.Quantity; break;
                    case ChipType.Mega: mega += chip.Quantity; break;
                    case ChipType.Giga: giga += chip.Quantity; break;
                    case ChipType.Dark: dark += chip.Quantity; break;
                }
            }

            return $"S: {standard}, M: {mega}, G: {giga}, {(dark > 0 ? $"D: {dark}," : "")} {standard + mega + giga + dark} / 30";
        }
    }
}