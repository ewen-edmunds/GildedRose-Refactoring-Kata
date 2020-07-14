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
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.AreEqual(80, Items[0].Quality);
            }
        }
    }
}