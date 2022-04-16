using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TestletApp;


namespace TestletUnitTest
{
    [TestClass]
    public class TestletUnitTest
    {
        List<Item> items = new List<Item>(); 
        [TestInitialize]
        public void TestInitialize()
        {
            items.Add(new Item() { ItemId = "1", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "2", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "3", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "4", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "5", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "6", ItemType = ItemTypeEnum.Operational });
            items.Add(new Item() { ItemId = "7", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "8", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "9", ItemType = ItemTypeEnum.Pretest });
            items.Add(new Item() { ItemId = "10", ItemType = ItemTypeEnum.Pretest });
        } 
        [TestMethod]
        public void TestRandomizeHavingFirstTwoAsPreTest()
        {
           
            Testlet testlet = new Testlet("1", items);
            var randItems = testlet.Randomize();
            Assert.IsNotNull(randItems);
            Assert.IsTrue(randItems.Count == 10);
            Assert.IsTrue(randItems.Take(2).All(e => e.ItemType == ItemTypeEnum.Pretest));
            
        }

        [TestMethod]
        public void TestRandomizeHavingRemainingItemsWithPreTestandOperational()
        {
            Testlet testlet = new Testlet("1", items);
            var randItems = testlet.Randomize();
            Assert.IsNotNull(randItems);
            Assert.IsTrue(randItems.Count == 10);

            Assert.IsTrue(randItems.Skip(2).All(e => e.ItemType == ItemTypeEnum.Pretest || e.ItemType == ItemTypeEnum.Operational));
        }

        [TestMethod]
        public void TestRandomizeReturningRandomData()
        {
            Testlet testlet = new Testlet("1", items);
            var randItems1 = testlet.Randomize();

            var randItems2 = testlet.Randomize();

            Assert.IsFalse(randItems1.SequenceEqual(randItems2));
        }
    }
}
