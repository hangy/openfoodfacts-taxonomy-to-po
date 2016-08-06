namespace OffLangParser
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Pnns")]
    public static class PnnsGroupValidator
    {
        public static void EnsureIsInRange(int group)
        {
            const int MIN_GROUP = 1;
            const int MAX_GROUP = 2;

            if (group < MIN_GROUP || group > MAX_GROUP)
            {
                throw new ArgumentOutOfRangeException(nameof(group), $"{nameof(group)} should be between {MIN_GROUP} AND {MAX_GROUP}.");
            }
        }
    }
}
