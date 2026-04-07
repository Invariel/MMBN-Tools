namespace Deck_Builder.Classes
{
    public class FolderChip 
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public ChipType ChipType { get; set; }
        public int Quantity { get; set; }
    }
}