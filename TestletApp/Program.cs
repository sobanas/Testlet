using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestletApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Item> items = new List<Item>();
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

            Testlet testlet = new Testlet("1", items);

            var randomizedData = testlet.Randomize();

            Console.WriteLine("Testlet App Randomized Items:");
            randomizedData.ForEach(item => Console.WriteLine("Item ID: {0}, Item Type: {1}",item.ItemId,item.ItemType.ToString()));
            Console.ReadLine();
        }


    }
}
