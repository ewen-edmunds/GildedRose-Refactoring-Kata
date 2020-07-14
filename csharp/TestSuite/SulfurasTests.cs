using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class SulfurasTests
    {
        [Test]
        public void SulfurasImmutableQualityOverTime()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 20, Quality = 80}
                };
                GildedRose app = new GildedRose(Items);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    app.UpdateQuality();
                }
                
                Assert.AreEqual(80, Items[0].Quality);
            }
        }
    }
}