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
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.AreEqual(19, Items[0].Quality);
        }
        
        [Test]
        public void RegularItemLosesSellInOnce()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20}
            };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
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
                GildedRose app = new GildedRose(Items);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    app.UpdateQuality();
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
                GildedRose app = new GildedRose(Items);
                
                for (int j = 0; j < numDaysToSimulate; j++)
                {
                    app.UpdateQuality();
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