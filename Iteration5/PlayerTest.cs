using System;
using System.Xml.Linq;

namespace Iteration5
{
	public class PlayerTest
	{

		Item sword, computer;
		Player pl;
		Location l;
		Item box;
		
		[SetUp()]
		public void Constructor_PlayerTest()
		{

			pl = new Player("Fred", "the mighty programmer");
			
			sword = new Item(new string[] { "sword" }, "sword", "bronze");
			computer = new Item(new string[] { "pc" }, "computer", "small");
			l = new Location("room", "a small room");
			box = new Item(new string[] { "box" }, "big box", "brown");
			
			pl.Inv.Put(sword);
            pl.Inv.Put(computer);
			
			l.Inv.Put(box);
			pl.Loc = l;

		}
		[Test()]
		public void Test_Player_is_Identifiable()
		{
			Assert.IsTrue(pl.AreYou("me"));
		}
		[Test()]
		public void Test_Player_Locates_Items()
		{
			Assert.AreEqual(sword, pl.Locate("sword"));
			Assert.IsTrue(pl.Inv.HasItem("sword"));


			Assert.AreEqual(computer, pl.Locate("pc"));
			Assert.IsTrue(pl.Inv.HasItem("pc"));

		}
		[Test()]
		public void Test_Player_Locates_Itself()
		{
			Assert.AreEqual(pl, pl.Locate("me"));
			Assert.AreEqual(pl, pl.Locate("inventory"));

		}
		[Test()]
		public void Test_Player_Locates_Nothing()
		{
			Assert.AreEqual(null, pl.Locate("food"));

			Assert.AreEqual(null, pl.Locate("boat"));
		}
		[Test()]
		public void Test_Player_full_Description()
		{
			Assert.AreEqual("You are Fred the mighty programmer.\n" + "You are carrying\n" + "\ta sword (sword)\n\ta computer (pc)\n", pl.FullDescription);
		}
        [Test()]
        public void Players_locate_items_in_location()
        {
            Assert.AreSame(box, pl.Locate("box"));
        }
        [Test()]
        public void Player_identify_location()
        {
            Assert.AreSame(l, pl.Locate("room"));
        }
    }
}

