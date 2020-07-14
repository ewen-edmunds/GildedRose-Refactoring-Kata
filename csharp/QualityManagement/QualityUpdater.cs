using System;

namespace csharp
{
    public class QualityUpdater
    {
        public const int DEFAULT_QUALITY_DECREASE = 1;
        public const int PAST_SELLIN_DATE_QUALITY_CHANGE_FACTOR = 2;
        public const int DEFAULT_MAX_QUALITY = 50;
        public const int DEFAULT_MIN_QUALITY = 0;
        
        public int QualityDecrease;
        
        public QualityUpdater()
        {
            QualityDecrease = DEFAULT_QUALITY_DECREASE;
        }
        
        public virtual void UpdateItemQuality(Item item)
        {
            item.Quality = Math.Min(DEFAULT_MAX_QUALITY, Math.Max(DEFAULT_MIN_QUALITY, item.Quality-(QualityDecrease*GetQualityChangeFactor(item))));
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