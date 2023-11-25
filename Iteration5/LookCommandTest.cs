using System;
using System.ComponentModel;
using System.Xml.Linq;
using Iteration5;
using NUnit;
namespace Iteration5
{
    [TestFixture()]
    public class LookCommandTest
    {
        LookCommand l;
        Player p;
        Item gem;
        Bag b;
        Location lc;

        [SetUp()]
        public void Setup()
        {
            l = new LookCommand();
            p = new Player("Fred", "the mighty programmer");
            b = new Bag(new string[] { "bag" }, "leather bag", "small brown");
            gem = new Item(new string[] { "gem" }, "gem", "A bright red");
            lc = new Location("room", "a small room");
            p.Inv.Put(gem);
            p.Loc = lc;
        }
        [Test()]
        public void TestLookAtMe()
        {
            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "inventory" }), p.FullDescription);
        }
        [Test()]
        public void TestLookAtGem()
        {
            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "gem" }), gem.FullDescription);
        }
        [Test()]
        public void TestLookAtUnk()
        {
            p.Inv.Take("gem");
            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "gem" }), "I cannot find the gem in the Fred");
        }

        [Test()]
        public void TestLookAtGemInMe()
        {
            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "gem", "in", "inventory" }), gem.FullDescription);


        }

        [Test()]
        public void TestLookAtGemInBag()
        {
            b.Inv.Put(gem);
            p.Inv.Put(b);

            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" }), gem.FullDescription);
        }

        [Test()]
        public void TestLookAtGemInNoBag()
        {
            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" }), "I cannot find the bag");
        }
        [Test()]
        public void TestLookAtNoGemInBag()
        {
            p.Inv.Put(b);

            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" }), "I cannot find the gem in the leather bag");
        }
        [Test()]
        public void TestInvalidLook()
        {
            Assert.AreEqual(l.Execute(p, new string[] { "look", "around" }), "I don't know how to look like that.");
            Assert.AreEqual(l.Execute(p, new string[] { "Hello", "Sanya", "Baweja" }), "Error in look input");
            Assert.AreEqual(l.Execute(p, new string[] { "look", "at", "a", "at", "b" }), "What do you want to look in?");

        }
        [Test()]
        public void LocationTest()

        {
            Assert.AreEqual(l.Execute(p, new string[] { "look" }), lc.FullDescription);
        }

        }
}