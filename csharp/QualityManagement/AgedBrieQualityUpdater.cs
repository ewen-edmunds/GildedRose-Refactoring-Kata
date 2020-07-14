
using System;

namespace csharp
{
    public class AgedBrieQualityUpdater : QualityUpdater
    {
        public const int AGED_BRIE_QUALITY_INCREASE = 1;
        public override void UpdateItemQuality(Item item)
        {
            item.Quality = Math.Min(DEFAULT_MAX_QUALITY, item.Quality + (AGED_BRIE_QUALITY_INCREASE*GetQualityChangeFactor(item)));
        }
    }
}