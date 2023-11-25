using System;
namespace Iteration5
{
	public interface IHaveInventory
	{
		Game_Object Locate(string id);
		

		public string Name
		{
			get;
		}
	}
}

