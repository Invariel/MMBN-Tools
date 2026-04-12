namespace Deck_Builder.Classes
{
    public class FolderChip 
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int ChipType { get; set; } = (int)Deck_Builder.Classes.ChipType.Standard;
        public int Quantity { get; set; }

        public ChipType Game_ChipType { get => GameChipType(); }

        public ChipType GameChipType() => (ChipType)(ChipType & 0b1111);
    }
}