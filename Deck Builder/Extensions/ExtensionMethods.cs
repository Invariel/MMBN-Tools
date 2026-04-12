using Deck_Builder.Classes;

namespace Deck_Builder.Extensions
{
    public static class ExtensionMethods
    {
        public static bool IsChipType(this int chipType, ChipType expected)
            => (chipType & (int)expected) == (int)expected;

        public static bool IsSecretChip(this int chipType)
            => (chipType & (int)ChipType.Secret) == (int)ChipType.Secret;

        public static bool IsUnregisteredChip(this int chipType)
            => (chipType & (int)ChipType.Unregistered) == (int)ChipType.Unregistered;
    }
}
