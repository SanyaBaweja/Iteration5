using System;
namespace Iteration5
{
    [TestFixture()]
    public class PathTest
    {
        Location l;
        Path p;


        [SetUp()]
        public void Setup()
        {
            l = new Location("a rich country", "This is my beautiful country");
            p = new Path(new string[] { "west", "w" }, "west", "moving towards west", l);
        }
        [Test()]
        public void IdentifyPaths()
        {
            Assert.IsTrue(p.AreYou("west"));
            Assert.IsFalse(p.AreYou("there"));
        }
        [Test()]
        public void PathFullDescription()
        {
            Assert.AreEqual("On moving west there is a rich country", p.FullDescription);
        }
    }
}

