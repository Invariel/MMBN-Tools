namespace Deck_Builder.Classes
{
    public class Game
    {
        public string Name { get; set; } = string.Empty;
        public GameRules Rules { get; set; } = new();
        public List<Battlechip> Battlechips { get; set; } = new();
    }
}
