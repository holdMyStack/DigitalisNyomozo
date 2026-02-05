namespace DigitalisNyomozo
{
	internal class Program
	{
		static int ValasztasMenu(string[] opciok)
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

		static void Fejlec(string alMenu)
		{
			Console.Clear();
			Console.WriteLine($"======== BRFK KEZELŐFELÜLET > {alMenu} ========\n");
		}

		static void SzemélyzetAlMenu(AdatTar tar)
		{
			string[] menuOpciok = { "Listázás", "Felvétel", "Törlés", "Visszalépés" };
			int opcio;

			do
			{
				Fejlec("Személyzet");
				Console.WriteLine("Válasszon műveletet:");

				opcio = ValasztasMenu(menuOpciok);
				Console.WriteLine();

				switch (opcio)
				{
					case 0:
						Fejlec("Személy listázás");

						foreach (Szemely szemely in tar.szemelyek)
						{
							Console.WriteLine(szemely.ToString());
						}

						Console.ReadKey();
						break;

					case 1:
						Fejlec("Személy felvétel");

						Console.Write("Személy neve: ");
						string szemelyNev = Console.ReadLine();

						Console.Write("Személy életkora: ");
						int eletkor;
						bool sikeres = int.TryParse(Console.ReadLine(), out eletkor);

						if (sikeres)
						{
							Console.Write("Megjegyzés: ");
							string megjegyzes = Console.ReadLine();

							Szemely hozzaadott = new Szemely(szemelyNev, eletkor, megjegyzes);

							Fejlec("Személy felvétel");
							Console.WriteLine(hozzaadott.ToString());
							Console.Write("Helyes? (i/n) ");

							char key2 = Console.ReadKey().KeyChar;
							Console.WriteLine("");

							if (key2 == 'i')
							{
								tar.szemelyek.Add(hozzaadott);
								Console.WriteLine("\n> Személy hozzáadása sikeres.");
							}
							else
							{
								Console.WriteLine("\n> Személy hozzáadása megszakítva.");
							}
						}
						else
						{
							Console.WriteLine("\n> Helytelen számérték, személy hozzáadás megszakítva.");
						}

						Console.ReadKey();

						break;

					case 2:
						Fejlec("Személy törlés");

						List<string> szemelyek = new List<string>();

						foreach (Szemely szemely in tar.szemelyek)
						{
							szemelyek.Add(szemely.ToString());
						}

						int valasztott = ValasztasLista(szemelyek);

						Fejlec("Személy törlés");

						Console.WriteLine(tar.szemelyek[valasztott].ToString());
						Console.Write("\nHelyes? (i/n) ");

						char key = Console.ReadKey().KeyChar;
						Console.WriteLine("");

						if (key == 'i')
						{
							tar.szemelyek.Remove(tar.szemelyek[valasztott]);
							Console.WriteLine("\n> Személy eltávolítása sikeres.");
						}
						else
						{
							Console.WriteLine("\n> Személy eltávolítása megszakítva.");
						}

						break;
				}
			} while (opcio != 3);
		}

		static void UgyekAlMenu(AdatTar tar)
		{

			
		}

		static void FoMenu()
		{
			AdatTar tar = new AdatTar();

			UgyKezelo ugyKezelo = new UgyKezelo(tar);
			BizonyitekKezelo bizonyitekKezelo = new BizonyitekKezelo(tar);

			string[] menuOpciok = { "Személyzet", "Ügyek", "Gyanusítottak", "Tanúk", "Bizonyítékok", "Kilépés" };
			int opcio;

			do
			{
				Fejlec("Fő");

				Console.WriteLine("Válasszon almenüt:");
				opcio = ValasztasMenu(menuOpciok);

				switch (opcio)
				{
					case 0:
						SzemélyzetAlMenu(tar);
						break;

					case 1:
						UgyekAlMenu(tar);
						break;
				}
			} while (opcio != 5);
		}

		static void Main(string[] args)
		{
			FoMenu();
		}
	}
}
