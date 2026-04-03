namespace Deck_Builder.Classes
{
    public class GameChip (GameName game, int number, string name, ChipElement element, string code, ChipClass chipClass)
    {
        public GameName Game { get; set; } = game;
        public int Number { get; set; } = number;
        public string Name { get; set; } = name;
        public string Code { get; set; } = code;
        public ChipElement Element { get; set; } = element;
        public ChipClass ChipClass { get; set; } = chipClass;
    }
}
