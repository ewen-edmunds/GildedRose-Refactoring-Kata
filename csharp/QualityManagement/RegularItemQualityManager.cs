using System;

namespace csharp
{
    public class RegularItemQualityManager : QualityManager
    {
        public override void UpdateItemQuality(Item item)
        {
            item.Quality = Math.Max(DEFAULT_MIN_QUALITY, item.Quality-(DEFAULT_QUALITY_DECREASE*GetQualityChangeFactor(item)));
        }
    }
}