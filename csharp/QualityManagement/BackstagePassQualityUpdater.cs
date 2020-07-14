using System;

namespace csharp
{
    public class BackstagePassQualityUpdater : QualityUpdater
    {
        public static int DEFAULT_STAGE_PASS_QUALITY_INCREASE = 1;
        public static int LESS_THAN_10_DAYS_QUALITY_INCREASE = 2;
        public static int LESS_THAN_5_DAYS_QUALITY_INCREASE = 3;
        public override void UpdateItemQuality(Item item)
        {
            if (item.SellIn <= 0)
            {
                item.Quality = 0;
            }
            else if (item.SellIn <= 5)
            {
                item.Quality += LESS_THAN_5_DAYS_QUALITY_INCREASE;
            }
            else if (item.SellIn <= 10)
            {
                item.Quality += LESS_THAN_10_DAYS_QUALITY_INCREASE;
            }
            else
            {
                item.Quality += DEFAULT_STAGE_PASS_QUALITY_INCREASE;
            }
            
            item.Quality = Math.Min(DEFAULT_MAX_QUALITY, item.Quality);
        }
    }
}