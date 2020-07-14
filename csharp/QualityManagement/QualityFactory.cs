namespace csharp
{
    public static class QualityFactory
    {
        public static void UpdateItemQuality(Item item)
        {
            if (item.Name == "Aged Brie")
            {
                new AgedBrieQualityManager().UpdateItemQuality(item);
            }
            else if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
            {
                new BackstagePassQualityManager().UpdateItemQuality(item);
            }
            else if (item.Name == "Sulfuras, Hand of Ragnaros")
            {
                new SulfurasQualityManager().UpdateItemQuality(item);
            }
            else if (item.Name.StartsWith("Conjured"))
            {
                new ConjuredItemQualityManager().UpdateItemQuality(item);
            }
            else
            {
                new RegularItemQualityManager().UpdateItemQuality(item);
            }
        }
    }
}