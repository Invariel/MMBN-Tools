namespace Deck_Builder.Classes
{
    public class FolderChip : IComparable
    {
        public int Number { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Code { get; set; } = string.Empty;
        public int ChipType { get; set; } = (int)Deck_Builder.Classes.ChipType.Standard;
        public int Quantity { get; set; }

        public ChipType Game_ChipType { get => GameChipType(); }
        public ChipType GameChipType() => (ChipType)(ChipType & 0b1111);

        public int CompareTo(object? obj)
        {
            if (obj is not FolderChip other)
            {
                return 1;
            }

            int result = ChipType.CompareTo(other.ChipType);
            if (result != 0)
            {
                return result;
            }

            result = Number.CompareTo(other.Number);
            if (result != 0)
            {
                return result;
            }

            result = string.Compare(Code, other.Code, StringComparison.Ordinal);
            if (result != 0)
            {
                return result;
            }

            return Quantity.CompareTo(other.Quantity);
        }

        public override bool Equals(object? obj)
        {
            if (obj is not FolderChip other)
            {
                return false;
            }

            return Number == other.Number &&
                Name == other.Name &&
                Code == other.Code &&
                ChipType == other.ChipType &&
                Quantity == other.Quantity;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Number, Name, Code, ChipType, Quantity);
        }
    }
}