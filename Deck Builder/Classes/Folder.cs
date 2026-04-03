using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Deck_Builder.Classes
{
    public class Folder
    {
        public GameName GameName { get; set; }
        public string Name { get; set; } = string.Empty;
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
                switch (chip.ChipClass)
                {
                    case ChipClass.Standard: standard += chip.Quantity; break;
                    case ChipClass.Mega: mega += chip.Quantity; break;
                    case ChipClass.Giga: giga += chip.Quantity; break;
                    case ChipClass.Dark: dark += chip.Quantity; break;
                }
            }

            return $"S: {standard}, M: {mega}, G: {giga}, {(dark > 0 ? $"D: {dark}," : "")} {standard + mega + giga + dark} / 30";
        }
    }

    public class FolderChip 
    {
        public int Number { get; set; }
        [JsonIgnore]
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public ChipClass ChipClass { get; set; }
        public int Quantity { get; set; }
    }

    public enum ChipClass
    {
        Standard,
        Mega,
        Giga,
        Dark
    }
}