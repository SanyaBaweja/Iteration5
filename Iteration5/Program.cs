using System;

namespace Iteration5
{
	class Program
	{

		public void Main(string[] args)
		{
			Console.WriteLine("Enter the name of your player: ");
			string name = Console.ReadLine();


			Console.WriteLine("Enter the description of your player: ");
			string description = Console.ReadLine();

			Player p = new Player(name, description);

			Item gem = new Item(new string[] { "gem" }, "gem", "A bright red");
			Item sword = new Item(new string[] { "sword" }, "sword", "bronze");
			p.Inv.Put(gem);
			p.Inv.Put(sword);
			Bag b = new Bag(new string[] { "bag" }, "bag", "That is a leather bag");
			p.Inv.Put(b);

			Item box = new Item(new string[] { "box" }, "box", "This is the box");
			b.Inv.Put(box);

			bool exit = false;
			LookCommand look = new LookCommand();
			while (!exit)
			{
				Console.WriteLine("\nType your command:");
				string command = Console.ReadLine();
				if (command == "exit")
				{
					exit = true;

				}
				else
				{
					Console.WriteLine(look.Execute(p, command.Split()));
				}
			}
			

		}
	}
}



