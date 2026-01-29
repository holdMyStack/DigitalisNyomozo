namespace DigitalisNyomozo
{
	internal class Program
	{
		static int ValasztasMenu(List<string> opciok)
		{
			for (int i = 0; i < opciok.Count(); i++)
			{
				char elso = opciok[i].ToUpper()[0];
				string veg = opciok[i].Substring(1);

				Console.WriteLine($"  ({elso}){veg}");
			}

			int valasztas = -1;

			while (valasztas < 0)
			{
				char match = Console.ReadKey(true).KeyChar;

				for (int i = 0; i < opciok.Count(); i++)
				{
					if (match.ToString().ToUpper()[0] == opciok[i].ToUpper()[0])
					{
						valasztas = i;
						break;
					}
				}
			}


			for (int i = 0; i < opciok.Count(); i++)
			{
				Console.Write($"\r\x1B[1A\x1B[2K");
			}

			Console.WriteLine($"> {opciok[valasztas]}");

			return valasztas;
		}

		static int ValasztasLista(List<string> opciok)
		{
			int valasztas = 0;
			bool vege = false;

			while (!vege)
			{
				for (int i = 0; i < opciok.Count(); i++)
				{
					string before = valasztas == i ? "> " : "  ";
					Console.WriteLine($"{before}{opciok[i]}");
				}

				switch (Console.ReadKey(true).Key)
				{
					case ConsoleKey.UpArrow:
						valasztas = Math.Max(0, valasztas - 1);
						break;

					case ConsoleKey.DownArrow:
						valasztas = Math.Min(opciok.Count() - 1, valasztas + 1);
						break;

					case ConsoleKey.Enter:
						vege = true;
						break;
				}

				Console.Write($"\r\x1B[{opciok.Count()}A");
			}

			for (int i = 0; i < opciok.Count(); i++)
			{
				Console.Write($"\r\x1B[2K\n");
			}

			Console.Write($"\r\x1B[{opciok.Count()}A");
			Console.WriteLine($"> {opciok[valasztas]}");

			return valasztas;
		}

		static void FoMenu()
		{
			AdatTar tarhely = new AdatTar();
		}

		static void Main(string[] args)
		{
			FoMenu();
		}
	}
}
