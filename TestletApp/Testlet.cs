using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestletApp
{
    public class Testlet
    {
        public string TestletId;
        private List<Item> Items;
        public Testlet(string testletId, List<Item> items)
        {
            TestletId = testletId;
            Items = items;
        }
        public List<Item> Randomize()
        {
            List<Item> randomizedItems = new List<Item>();
            if(Items != null && Items.Any())
            {
                var itemsWithPretest = Items.Where(e => e.ItemType == ItemTypeEnum.Pretest).OrderBy(p => Guid.NewGuid()).Take(2).ToList();
                randomizedItems.AddRange(itemsWithPretest);

                var remainingItems = Items.Where(e => !itemsWithPretest.Any(p => p.ItemId == e.ItemId)).OrderBy(a => Guid.NewGuid());
                randomizedItems.AddRange(remainingItems);

            }
            return randomizedItems;
        }
    }
    public class Item
    {
        public string ItemId;
        public ItemTypeEnum ItemType;
    }
    public enum ItemTypeEnum
    {
        Pretest = 0,
        Operational = 1
    }
}
