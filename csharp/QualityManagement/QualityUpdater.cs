using System;

namespace csharp
{
    public class QualityUpdater
    {
        public static int DEFAULT_QUALITY_DECREASE = 1;
        public static int PAST_SELLIN_DATE_QUALITY_CHANGE_FACTOR = 2;
        public static int DEFAULT_MAX_QUALITY = 50;
        public static int DEFAULT_MIN_QUALITY = 0;
        public virtual void UpdateItemQuality(Item item)
        {
            item.Quality = Math.Max(DEFAULT_MIN_QUALITY, item.Quality-(DEFAULT_QUALITY_DECREASE*GetQualityChangeFactor(item)));
        }

        public int GetQualityChangeFactor(Item item)
        {
            if (item.SellIn > 0)
            {
                return 1;
            }

            return PAST_SELLIN_DATE_QUALITY_CHANGE_FACTOR;
        }
    }
}