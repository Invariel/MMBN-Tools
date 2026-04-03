namespace Deck_Builder.Classes
{
    public class Game
    {
        public GameName GameName { get; set; }
        public string Name { get; set; } = string.Empty;
        public string JsonFile { get; set; } = string.Empty;
        public List<Battlechip> Battlechips { get; set; } = new();
        public GameRules Rules { get; set; } = new();

        private List<GameChip> _gameChips = new();

        public List<GameChip> Gamechips()
        {
            if (_gameChips.Count > 0)
            {
                return _gameChips;
            }

            foreach (Battlechip chip in Battlechips)
            {
                foreach (var code in chip.Codes.Split(","))
                {
                    _gameChips.Add(new GameChip(GameName, chip.Number, chip.Name, chip.Elements[0], code.Trim(), chip.ChipClass));
                }
            }

            return _gameChips;
        }
    }

    public class GameRules
    {
        public int MaxFolderSize { get; set; } = 30;
        public int MaxCopies { get; set; } = 4;
        public int MaxMegaChips { get; set; } = 8;
        public int MaxGigaChips { get; set; } = 3;
        public int MaxDarkChips { get; set; } = 30;
        public int MaxSameStandardChip { get; set; } = 4;
        public int MaxSameMegaChip { get; set; } = 1;
        public int MaxSameGigaChip { get; set; } = 1;
        public int MaxSameDarkChip { get; set; } = 1;
    }
}
