using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class BackstagePassTests
    {
        [Test]
        public void StagePassQualityGoesUpOverTime()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 100, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);

            Assert.AreEqual(11, Items[0].Quality);
        }
        
        [Test]
        public void StagePassQualityIncreasesFasterWithTenDaysLeft()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 10, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);

            Assert.AreEqual(12, Items[0].Quality);
        }
        
        [Test]
        public void StagePassQualityIncreasesFasterWithFiveDaysLeft()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 5, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);

            Assert.AreEqual(13, Items[0].Quality);
        }
        
        [Test]
        public void StagePassQualityToZeroAfterSellInDate()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);

            Assert.AreEqual(0, Items[0].Quality);
        }
        
        [Test]
        public void StagePassQualityNeverAbove50()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 15, Quality = 40}
                };
                QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.LessOrEqual(Items[0].Quality, 50);
            }
        }
    }
}