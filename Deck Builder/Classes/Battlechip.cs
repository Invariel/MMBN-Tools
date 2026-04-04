using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Deck_Builder.Classes
{
    public class Battlechip : IComparable
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int Number { get; set; }

        public ChipType ChipType { get; set; } = ChipType.Standard;
        public List<ChipElement> Elements { get; set; } = new() { 0 };

        [JsonIgnore]
        public ChipElement Element { get => Elements[0]; }

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

        public int CompareTo(object? obj)
        {
            if (obj is not Battlechip that)
            {
                return -1;
            }

            if (this.ChipType != that.ChipType)
            {
                return that.ChipType - this.ChipType;
            }

            return that.Number - this.Number;
        }
    }
}

/*
 
=CONCATENATE (
    "{ ",
    $P$1, $A$1, $P$1, ": ", A2, ", ",
    $P$1, $C$1, $P$1, ": ", $P$1, C2, $P$1, ", ", 
    $P$1, "ChipClass", $P$1, ": ", 1, ", ",
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