using System;
using System.Collections.Generic;

namespace NetCore
{
	class Program
	{
		static Random ran = new Random();

		static void Main(string[] args)
		{
			List<FlashCard> FlashCards =  ReadData.Read(@"/home/blue/FlashCardFiles");

			bool Quit = true;

			while (Quit)
			{
				if (FlashCards.Count > 0)
				{
					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Definition-----------FlashCards v.1");
					Console.ForegroundColor = ConsoleColor.Blue;
					
					string ifEsc = String.Empty;
					int index = ran.Next(FlashCards.Count);
					string Item = FlashCards[index].Item;
					string Def = FlashCards[index].Definition;

					Console.WriteLine();
					Console.WriteLine(Def);
					Console.ForegroundColor = ConsoleColor.Red;
					
					ifEsc = Console.ReadLine();
					if (ifEsc == ":q")
					{
						break;
					}
					Console.Clear();

					Console.ForegroundColor = ConsoleColor.Green;
					Console.WriteLine("Answer---------------FlashCards v.1");
					Console.ForegroundColor = ConsoleColor.Magenta;
					
					Console.WriteLine();
					Console.WriteLine(Item);
					Console.ForegroundColor = ConsoleColor.Red;
					ifEsc = Console.ReadLine();
					if (ifEsc == ":q")
					{
						break;
					}

					Console.Clear();
				}
				else
				{
					Console.WriteLine("No Flash Cards Availible....");
					Console.ReadKey();
					break;
				}
			}
		}
	}
}
