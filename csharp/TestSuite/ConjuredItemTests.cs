using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class ConjuredItemTests
    {
        [Test]
        public void ConjuredItemLosesQualityOnce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Kudzu", SellIn = 10, Quality = 20}
            };
            QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);
            Assert.AreEqual(18, Items[0].Quality);
        }
        
        [Test]
        public void ConjuredItemLosesSellInOnce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Kudzu", SellIn = 10, Quality = 20}
            };
            SellInUpdater.UpdateSellIn(Items[0]);
            Assert.AreEqual(9, Items[0].SellIn);
        }
        
        [Test]
        public void ConjuredItemLosesQualityMultipleTimes()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 15; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Conjured Kudzu", SellIn = 50, Quality = 40}
                };
                QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.AreEqual(40-(2*numDaysToSimulate), Items[0].Quality);
            }
        }
        
        [Test]
        public void ConjuredItemLosesSellInMultipleTimes()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Conjured Kudzu", SellIn = 10, Quality = 20}
                };
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    SellInUpdater.UpdateSellIn(Items[0]);
                }
                
                Assert.AreEqual(10-numDaysToSimulate, Items[0].SellIn);
            }
        }
        
        [Test]
        public void ConjuredItemQualityNeverBelow0()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Conjured Kudzu", SellIn = 10, Quality = 10}
                };
                QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.GreaterOrEqual(Items[0].Quality, 0); 
            }
        }
        
        [Test]
        public void ConjuredItemQualityDecreasesTwiceAsFastPastSellInDate()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 10; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "Conjured Mana Buffet", SellIn = 0, Quality = 50}
                };
                QualityUpdater qualityUpdater = QualityFactory.QualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.AreEqual(50-(4*numDaysToSimulate), Items[0].Quality);
            }
        }
    }
}