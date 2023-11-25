using Iteration5;
namespace Iteration5
{
    [TestFixture()]
    public class CommandProcessorTest
    {
        CommandProcessor cmd;
        Location l1;
        Location l2;
        Player p;
        Item pizza;
        Path raasta;


        [SetUp()]
        public void Setup()
        {
            cmd = new CommandProcessor();
            l1 = new Location("jungle", "a big");
            l2 = new Location("Highway", "the modern");
            p = new Player("Doraemon", "the blue cat");
            pizza = new Item(new string[] { "pizza" }, "pizza", "Margharita cheese pizza");
            raasta = new Path(new string[] { "southeast" }, "southeast", "moving southeast", l2);

            p.Inv.Put(pizza);
            p.Loc = l1;
            l1.AddPathInList(raasta);
        }
        [Test()]
        public void TestCommands()
        {
            Assert.AreEqual(cmd.Execute(p, new string[] { "look"}), l1.FullDescription);
            Assert.AreEqual(cmd.Execute(p, new string[] { "look", "at", "pizza" }), pizza.FullDescription);

            cmd.Execute(p, new string[] { "move", "southeast" });
            Assert.AreEqual(p.Loc, l2);

        }

    }
}