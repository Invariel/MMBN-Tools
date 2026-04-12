using Deck_Builder.Extensions;
using System.Collections.Immutable;
using System.Text;

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

            // Check the Game Rules for validity.
            return true;
        }

        public override string ToString()
        {
            Dictionary<string, int> chipCodes = new();

            int standard = 0;
            int mega = 0;
            int giga = 0;
            int dark = 0;

            foreach (FolderChip chip in Chips)
            {
                if (chip.ChipType.IsChipType(ChipType.Standard)) { standard += chip.Quantity; }
                else if (chip.ChipType.IsChipType(ChipType.Mega)) { mega += chip.Quantity; }
                else if (chip.ChipType.IsChipType(ChipType.Giga)) { giga += chip.Quantity; }
                else if (chip.ChipType.IsChipType(ChipType.Dark)) { dark += chip.Quantity; }

                if (!chipCodes.ContainsKey(chip.Code))
                {
                    chipCodes[chip.Code] = chip.Quantity;
                }
                else
                {
                    chipCodes[chip.Code] += chip.Quantity;
                }
            }

            StringBuilder builder = new StringBuilder();

            List<string> chipCodeKeys = chipCodes.Keys.ToList();
            chipCodeKeys.Sort();

            for (int i = 0; i < chipCodeKeys.Count; ++ i)
            {
                var elem = chipCodes[chipCodeKeys[i]];
                builder.Append($"{chipCodeKeys[i]}: {elem}{(i == chipCodeKeys.Count - 1 ? string.Empty : ", ")}");
            }

            builder.AppendLine();

            builder.Append($"{(standard > 0 ? $"S: {standard} " : string.Empty)}");
            builder.Append($"{(mega > 0 ? $"M: {mega} " : string.Empty)}");
            builder.Append($"{(giga > 0 ? $"G: {giga} " : string.Empty)}");
            builder.Append($"{(dark > 0 ? $"D: {dark} " : string.Empty)}");

            builder.Append ($"{standard + mega + giga + dark}/30");
            return builder.ToString();
        }
    }
}