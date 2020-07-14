using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class BrieTests
    {
        [Test]
        public void BrieQualityGoesUpOnce()
        {
            IList<Item> Items = new List<Item> { new Item { Name = "Aged Brie", SellIn = 100, Quality = 0 } };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);
            Assert.AreEqual(1, Items[0].Quality);
        }
        
        [Test]
        public void BrieQualityGoesUpMultipleTimes()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Aged Brie", SellIn = 100, Quality = 10}
                };
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.AreEqual(10+numDaysToSimulate, Items[0].Quality);
            }
        }
        
        [Test]
        public void BrieQualityGoesUpTwiceAsFastPastSellInDate()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 10; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Aged Brie", SellIn = 0, Quality = 10}
                };
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.AreEqual(10+(2*numDaysToSimulate), Items[0].Quality);
            }
        }
        
        [Test]
        public void BrieQualityNeverAbove50()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Aged Brie", SellIn = 15, Quality = 40}
                };
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.LessOrEqual(Items[0].Quality, 50);
            }
        }
    }
}