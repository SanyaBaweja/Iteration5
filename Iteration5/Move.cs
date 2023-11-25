using System;
using Iteration5;

namespace Iteration5
{
    public class Move : Command
    {
        public Move() : base(new string[] { "leave", "head", "go", "move" })
        {
        }
        public override string Execute(Player pl, string[] text)
        {

            if (text.Length > 2)
            {
                return "How to move like that?";
            }
            else if (text[0] != "leave" && text[0] != "go" && text[0] != "head" && text[0] != "move")
            {
                return "Error";
            }
            else if (text.Length == 1)
            {
                return "Where to move?";
            }
            else
            {
                string direction = text[1];
                if (pl.Locate(direction) is Path p)
                {
                    pl.Move_to_path(p);
                    return ("You head towards " + p.Name + ". You have arrived in " + p.Loc.Name);
                }
                return "Error! ";
            }
        }
    }
}

