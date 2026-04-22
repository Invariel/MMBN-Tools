namespace Deck_Builder.Classes
{
    public class GameRules
    {
        public int MaxFolderSize { get; set; } = 30;
        public int MaxMegaChips { get; set; } = 8;
        public int MaxGigaChips { get; set; } = 3;
        public int MaxDarkChips { get; set; } = 30;
        public int MaxSameStandardChip { get; set; } = 4;
        public int MaxSameMegaChip { get; set; } = 1;
        public int MaxSameGigaChip { get; set; } = 1;
        public int MaxSameDarkChip { get; set; } = 1;
    }
}
