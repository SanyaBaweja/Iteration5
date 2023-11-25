using NUnit.Framework.Internal;

namespace Iteration5
{
    [TestFixture()]
    public class MoveTest
    {
        Player p;
        Move m;
        Location l;
        Location dest;
        Path path;
        [SetUp()]
        public void SetUp()
        {
            p = new Player("Sanya", "I am a student at Swinburne.");
            m = new Move();
            l = new Location("Ambala", "My hometown");
            dest = new Location("Phagwara", "My mum's hometown");
            path = new Path(new string[] { "north", "n" }, "north", "State of Punjab", dest);

            p.Loc = l;
            l.AddPathInList(path);
        }
        [Test()]
        public void IdentifiableMoveCommand()
        {
            Assert.IsTrue(m.AreYou("move"));
            Assert.IsTrue(m.AreYou("go"));
            Assert.IsFalse(m.AreYou("chalo"));
        }
        [Test()]
        public void MovePlayerToDestination()
        {
            Assert.AreSame(l, p.Loc);
            m.Execute(p, new string[] { "move", "n" });
            Assert.AreSame(dest, p.Loc);
        }
        [Test()]
        public void PlayerLeavesLocation()
        {
            Assert.AreSame(l, p.Loc);
            m.Execute(p, new string[] { "move", "n" });
            Assert.AreNotSame(l, p.Loc);
        }
        [Test()]
        public void PlayerRemainInSameLocation()
        {
            Assert.AreSame(l, p.Loc);
            m.Execute(p, new string[] { "move", "s" });
            Assert.AreSame(l, p.Loc);
        }



    }
}
