using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class RegularItemTests {
        [Test]
        public void RegularItemLosesQualityOnce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
            qualityUpdater.UpdateItemQuality(Items[0]);
            Assert.AreEqual(19, Items[0].Quality);
        }
        
        [Test]
        public void RegularItemLosesSellInOnce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };
            SellInUpdater.UpdateSellIn(Items[0]);
            Assert.AreEqual(9, Items[0].SellIn);
        }
        
        [Test]
        public void RegularItemLosesQualityMultipleTimes()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 50, Quality = 40}
                };
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                Assert.AreEqual(40-numDaysToSimulate, Items[0].Quality);
            }
        }
        
        [Test]
        public void RegularItemLosesSellInMultipleTimes()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
                };
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    SellInUpdater.UpdateSellIn(Items[0]);
                }
                
                Assert.AreEqual(10-numDaysToSimulate, Items[0].SellIn);
            }
        }
        
        [Test]
        public void RegularItemQualityNeverBelow0()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 30; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 10}
                };
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.GreaterOrEqual(Items[0].Quality, 0); 
            }
        }
        
        [Test]
        public void RegularItemQualityDecreasesTwiceAsFastPastSellInDate()
        {
            for (int numDaysToSimulate = 0; numDaysToSimulate < 10; numDaysToSimulate++)
            {
                IList<Item> Items = new List<Item>
                {
                    new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 50}
                };
                QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    qualityUpdater.UpdateItemQuality(Items[0]);
                }
                
                Assert.AreEqual(50-(2*numDaysToSimulate), Items[0].Quality);
            }
        }
    }
}