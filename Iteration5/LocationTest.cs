using System;
using System.ComponentModel;
using System.Xml.Linq;
using Iteration5;
using NUnit;
namespace Iteration5
{
    [TestFixture()]
    public class LocationTest
    {
        Player p;
        Location l;
        Item gem;
       
        [SetUp()]
        public void SetUp()
        {
            p = new Player("Fred", "the mighty programmer");
            l = new Location("room", "a big room");
            gem = new Item(new string[] { "gem" }, "gem", "a bright red gem");

            p.Loc = l;
            l.Inv.Put(gem);
        }

        [Test()]
        public void Locations_identify_themselves()
        {
            Assert.AreSame(l, l.Locate("room"));
        }
        [Test()]
        public void Locations_locate_items()
        {
            Assert.AreSame(gem, l.Locate("gem"));
        }
        
        [Test()]
        public void FullDescriptionTest()
        {
            
            Assert.AreEqual("You are in the room\na big room.\nIn this room you can see:\n\ta gem (gem)\n", l.FullDescription);

        }
    }
}