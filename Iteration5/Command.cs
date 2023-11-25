using System;
namespace Iteration5
{
	public abstract class Command:Identifiable_object
	{
		public Command(string[] ids):base(ids)
		{
		}
		public abstract string Execute(Player p, string[] text);
	}
}

