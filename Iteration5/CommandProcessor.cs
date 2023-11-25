using Iteration5;

namespace Iteration5
{
    public class CommandProcessor : Command
    {

        List<Command> _cmd = new List<Command>()
        { new LookCommand(), new Move() };
        public CommandProcessor() : base(new string[] { "command" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command cmd in _cmd)
            {
                if (cmd.AreYou(text[0]))
                {
                    return cmd.Execute(p, text);
                }
            }
            return "What is that command! ";
        }
    }
}