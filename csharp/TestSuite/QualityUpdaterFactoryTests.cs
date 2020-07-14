using System.Collections.Generic;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class QualityUpdaterFactoryTests
    {
        [Test]
        public void ReturnsRegularQualityManager()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "+5 Dexterity Vest", SellIn = 0, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);

            Assert.AreEqual(qualityUpdater.GetType(), typeof(QualityUpdater));
        }
        
        [Test]
        public void ReturnsConjuredQualityManager()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Conjured Mana Pie", SellIn = 0, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);

            Assert.AreEqual(qualityUpdater.GetType(), typeof(ConjuredItemQualityUpdater));
        }
        
        [Test]
        public void ReturnsSulfurasQualityManager()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);

            Assert.AreEqual(qualityUpdater.GetType(), typeof(SulfurasQualityUpdater));
        }
        
        [Test]
        public void ReturnsBrieQualityManager()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Aged Brie", SellIn = 0, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);

            Assert.AreEqual(qualityUpdater.GetType(), typeof(AgedBrieQualityUpdater));
        }
        
        [Test]
        public void ReturnsStagePassQualityManager()
        {
            IList<Item> Items = new List<Item>
            {
                new Item {Name = "Backstage passes to a TAFKAL80ETC concert", SellIn = 0, Quality = 10}
            };
            QualityUpdater qualityUpdater = QualityFactory.GetQualityManager(Items[0]);

            Assert.AreEqual(qualityUpdater.GetType(), typeof(BackstagePassQualityUpdater));
        }
    }
}