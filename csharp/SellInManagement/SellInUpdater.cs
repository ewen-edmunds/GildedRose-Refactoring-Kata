namespace csharp
{
    public static class SellInUpdater
    {
        public static void UpdateSellIn(Item item)
        {
            if (item.Name != "Sulfuras, Hand of Ragnaros")
            {
                item.SellIn -= 1;
            }
        }
    }
}