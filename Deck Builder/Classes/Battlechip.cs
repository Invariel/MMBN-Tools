using System.ComponentModel.DataAnnotations;

namespace Deck_Builder.Classes
{
    public class Battlechip
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Number { get; set; }

        public ChipClass ChipClass { get; set; } = ChipClass.Standard;
        public List<ChipElement> Elements { get; set; } = new();

        [Required]
        public string Codes { get; set; } = string.Empty;
        public string Locations { get; set; } = string.Empty;
        public string Traders { get; set; } = string.Empty;

        public Point MegaManLocation { get; set; }

        /// <summary>
        /// The list of coordinates that the chip targets, with Mega Man at (1, 1).  WideSword would be (2, 0), (2, 1), (2, 2).
        /// </summary>
        public List<Point> Targets { get; set; } = new();
        public int Capacity { get; set; }
        /// <summary>
        /// Not strictly damage; healing for recovery chips, + dmg for variable chips, empty for obstacles, etc.
        /// </summary>
        public string Damage { get; set; } = string.Empty;
        public string Hits { get; set; } = string.Empty;
        public List<List<string>> ProgramAdvances { get; set; } = new();
        public string Description { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

        /// <summary>
        /// Maybe a bit optimistic here.
        /// </summary>
        public string Image { get; set; } = string.Empty;

        private List<ChipCode> _chipCodes = null!;
        
        public List<ChipCode> CalculateChipCodes()
        {
            if (_chipCodes is null)
            {
                _chipCodes = new();

                foreach (string code in Codes.Split(",").Select(c => c.Trim()))
                {
                    List<string> locations = Locations?.Split(";").Select(l => l.Trim()).ToList() ?? new() { string.Empty };

                    string loc = locations.FirstOrDefault(loc => loc.StartsWith(code)) ?? string.Empty;

                    _chipCodes.Add(new ChipCode(code, loc));
                }
            }

            return _chipCodes;
        }
    }
}

/*
 
=CONCATENATE (
    "{ ",
    $P$1, $A$1, $P$1, ": ", A2, ", ",
    $P$1, $C$1, $P$1, ": ", $P$1, C2, $P$1, ", ", 
    $P$1, "ChipClass", $P$1, ": ", 0, ", ",
    $P$1, $D$1, $P$1, ": [ ", D2, " ], ",
    $P$1, $F$1, $P$1, ": ", $P$1, F2, $P$1, ", ",
    $P$1, $I$1, $P$1, ": ", $P$1, I2, $P$1, ", ",
    $P$1, $J$1, $P$1, ": ", $P$1, J2, $P$1, ", ",
    $P$1, "MegaManLocation", $P$1, ": { ", $P$1, "X", $P$1, ": 0, ", $P$1, "Y", $P$1, ": 1 }, ",
    $P$1, "Targets", $P$1, ": [ { ", $P$1, "X", $P$1, ": 0, ", $P$1, "Y", $P$1, ": 1 } ], ",
    $P$1, $G$1, $P$1, ": ", LEFT (G2, LEN (G2) - 3), ", ",
    $P$1, $E$1, $P$1, ": ", $P$1, E2, $P$1, ", ",
    $P$1, $K$1, $P$1, ": ", $P$1, K2, $P$1, ", ",
    $P$1, "ProgramAdvances", $P$1, ": [ ], ",
    $P$1, $H$1, $P$1, ": ", $P$1, H2, $P$1, ", ",
    $P$1, "Notes", $P$1, ": ", $P$1, $P$1, ", ",
    $P$1, "Image", $P$1, ": ", $P$1, $P$1,
    " }, ",
)

 */