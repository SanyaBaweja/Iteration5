using System;
using System.ComponentModel;
using System.Numerics;
using Iteration5;

namespace Iteration5
{
    public class LookCommand : Command
    {



        public LookCommand() : base(new string[] { "look" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory container = null;
            string thingId = null;

            if (text.Length != 3 && text.Length != 5 && text.Length != 1)
            {
                return ("I don't know how to look like that.");
            }
            else
            {
                if (text[0] != "look")
                {
                    return ("Error in look input");
                }

                if (text.Length != 1 && text[1] != "at")
                {
                    return ("What do you want to look at?");
                }

                if (text.Length == 5 && text[3] != "in")
                {
                    return ("What do you want to look in?");
                }

                if (text.Length == 1)
                {
                    if (text[0] == "look")
                    {
                        container = p;
                        thingId = "room";
                    }

                }
                if (text.Length == 3)
                {
                    container = p;
                    thingId = text[2];
                }
                if (text.Length == 5)
                {
                    container = FetchContainer(p, text[4]);
                    if (container == null)
                    {
                        return ("I cannot find the " + text[4]);
                    }
                    thingId = text[2];

                }

            }


            return LookAtIn(thingId, container);

        }
        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }
        private string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) == null)
            {
                return ("I cannot find the " + thingId + " in the " + container.Name);
            }
            else
            {
                return container.Locate(thingId).FullDescription;
            }

        }

    }
}

