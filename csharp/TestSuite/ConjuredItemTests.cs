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
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(18, Items[0].Quality);
        }
        
        [Test]
        public void ConjuredItemLosesSellInOnce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Kudzu", SellIn = 10, Quality = 20}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
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
                GildedRose app = new GildedRose(Items);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    app.UpdateQuality();
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
                GildedRose app = new GildedRose(Items);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    app.UpdateQuality();
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
                GildedRose app = new GildedRose(Items);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    app.UpdateQuality();
                }
                
                Assert.GreaterOrEqual(Items[0].Quality, 0); 
            }
        }
    }
}