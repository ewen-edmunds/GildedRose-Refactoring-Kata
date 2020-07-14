namespace csharp
{
    public static class QualityFactory
    {
        public static QualityUpdater GetQualityManager(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                return new AgedBrieQualityUpdater();
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                return new BackstagePassQualityUpdater();
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                return new SulfurasQualityUpdater();
            }
            else if (item.Name.StartsWith("Conjured"))
            {
                return new ConjuredItemQualityUpdater();
            }
            else
            {
                return new QualityUpdater();
            }
        }
    }
}