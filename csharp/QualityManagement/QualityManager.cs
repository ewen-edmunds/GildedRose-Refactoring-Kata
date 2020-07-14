namespace csharp
{
    public abstract class QualityManager
    {
        public static int DEFAULT_QUALITY_DECREASE = 1;
        public static int PAST_SELLIN_DATE_QUALITY_CHANGE_FACTOR = 2;
        public static int DEFAULT_MAX_QUALITY = 50;
        public static int DEFAULT_MIN_QUALITY = 0;
        public abstract void UpdateItemQuality(Item item);

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