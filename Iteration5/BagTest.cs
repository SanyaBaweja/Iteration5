using System;
using System.Xml.Linq;
using Iteration5;
namespace Iteration5
{
    [TestFixture()]
    public class BagTest
    {


        Bag bag1, bag2;
        Item shovel, sword;
        string retbag, retbag2;

        [SetUp()]
        public void Constructor_BagTest()
        {

            bag1 = new(new string[] { "bag" }, "leather bag", "small brown");
            bag2 = new(new string[] { "bag2" }, "Jute bag", "pretty big");
            shovel = new(new string[] { "shovel" }, "shovel", "");
            sword = new(new string[] { "sword" }, "sword", "bronze");

            bag1.Inv.Put(shovel);
            bag2.Inv.Put(sword);
            bag1.Inv.Put(bag2);

            retbag = "In this " + bag1.Name + " you can see:\n\t" + bag1.Inv.ItemList;

            retbag2 = "In this " + bag2.Name + " you can see:\n\t" + bag2.Inv.ItemList;


        }
        [Test()]
        public void Test_Bag_Locates_Items()
        {

            Assert.AreEqual(bag1.Locate("shovel"), shovel);
            Assert.IsTrue(bag1.Inv.HasItem("shovel"));

            Assert.AreEqual(bag2.Locate("sword"), sword);
            Assert.IsTrue(bag2.Inv.HasItem("sword"));

        }
        [Test()]
        public void Test_Bag_Locates_Itself()
        {
            Assert.AreEqual(bag1, bag1.Locate("bag"));
            Assert.AreEqual(bag2, bag2.Locate("bag2"));

        }
        [Test()]
        public void Test_Bag_Locates_Nothing()
        {
            Assert.AreNotEqual(bag1, bag1.Locate("nothing"));

            Assert.AreNotEqual(bag2, bag2.Locate("nothing"));
        }
        [Test()]
        public void Test_Bag_Full_Description()
        {
            Assert.AreEqual(bag1.FullDescription, retbag);

            Assert.AreEqual(retbag2, bag2.FullDescription);
        }
        [Test()]
        public void Test_Bag_In_Bag()
        {
            Assert.AreEqual(bag1.Locate("bag2"), bag2);
            Assert.AreEqual(bag1.Locate("shovel"), shovel);

            Assert.AreNotEqual(bag1.Locate("sword"), sword);

        }

    }
}

