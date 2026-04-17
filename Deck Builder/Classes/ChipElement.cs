namespace Deck_Builder.Classes
{
    // Note: add more elements for the other games.  The BN4 list should be a good starting place though.
    public enum ChipElement
    {
        None = -1,
        Normal = 0,
        Fire = 1,
        Aqua = 2,
        Wood = 4,
        Elec = 8,
        Wind = 16,
        Ground = 32,
        Recovery = 64,
        Invisibility = 128,
        Plus = 256,
        Break = 512,
        Sword = 1024,
        Obstacle = 2048,
        Target = 4096,
        Dark = 8192,
    }
}