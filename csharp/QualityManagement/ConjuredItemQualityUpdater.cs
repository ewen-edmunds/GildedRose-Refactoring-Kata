using System;

namespace csharp
{
    public class ConjuredItemQualityUpdater : QualityUpdater
    {
        public static int CONJURED_QUALITY_DECREASE_FACTOR = 2;
        public override void UpdateItemQuality(Item item)
        {
            item.Quality = Math.Max(DEFAULT_MIN_QUALITY, item.Quality-(DEFAULT_QUALITY_DECREASE*CONJURED_QUALITY_DECREASE_FACTOR*GetQualityChangeFactor(item)));
        }
    }
}