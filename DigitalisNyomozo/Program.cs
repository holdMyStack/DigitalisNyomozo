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

		static void SzemélyekAlMenu(AdatTar tar)
		{
			string[] menuOpciok = { "Listázás", "Felvétel", "Törlés", "Visszalépés" };
			int opcio;

			do
			{
				Fejlec("Személyek");
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
			string[] menuOpciok = { "Listázás", "Felvétel", "Törlés", "Személy hozzárendelése", "Gyanusított hozzárendelése", "Bizonyíték hozzárendelése", "Visszalépés" };
			int opcio;

			do
			{
				Fejlec("Ügyek");
				Console.WriteLine("Válasszon műveletet:");

				opcio = ValasztasMenu(menuOpciok);
				Console.WriteLine();

				switch (opcio)
				{
					case 0:
						Fejlec("Ügyek listázása");

						foreach (Ugy ugy2 in tar.ugyek)
						{
							Console.WriteLine(ugy2.ToString() + "\n");
						}

						Console.ReadKey();
						break;

					case 1:
						Fejlec("Ügy hozzáadása");

						Console.Write("Ügy azonosítója: ");
						string ugyAzonosito = Console.ReadLine();

						Console.Write("Ügy címe: ");
						string ugyCim = Console.ReadLine();

						Console.Write("Ügy állapota: ");
						string ugyAllapot = Console.ReadLine();

						Console.Write("Ügy leírása: ");
						string ugyLeiras = Console.ReadLine();

						Ugy ugy = new Ugy(ugyAzonosito, ugyCim, ugyLeiras, ugyAllapot, new List<Szemely>(), new List<Bizonyitek>(), new List<Gyanusitott>());

						Fejlec("Ögy hozzáadása");

						Console.WriteLine(ugy.ToString());
						Console.Write("\nHelyes? (i/n) ");

						char key2 = Console.ReadKey().KeyChar;
						Console.WriteLine("");

						if (key2 == 'i')
						{
							tar.ugyek.Add(ugy);
							Console.WriteLine("\nÜgy hozzáadása sikeres.");
						}
						else
						{
							Console.WriteLine("\nÖgy hozzáadása megszakítva.");
						}

						Console.ReadKey();

						break;

					case 2:
						Fejlec("Ügy törlése");

						List<string> ugyek = new List<string>();

						foreach (Ugy ugy3 in tar.ugyek)
						{
							ugyek.Add($"{ugy3.azonosito} {ugy3.cim} ({ugy3.allapot})");
						}

						int valasztott = ValasztasLista(ugyek);

						Fejlec("Ügy törlése");

						Console.WriteLine($"{tar.ugyek[valasztott].ToString()}");
						Console.Write("\nHelyes? (i/n) ");

						char key = Console.ReadKey().KeyChar;
						Console.WriteLine("");

						if (key == 'i')
						{
							tar.ugyek.Remove(tar.ugyek[valasztott]);
							Console.WriteLine("\nÜgy eltávolítása sikeres.");
						}
						else
						{
							Console.WriteLine("\nÜgy eltávolítása megszakítva.");
						}

						Console.ReadKey();
						break;

					case 3:
						Fejlec("Személy hozzárendelése");

						if (tar.ugyek.Count == 0)
						{
							Console.WriteLine("Nincsenek ügyek.");
							Console.ReadKey();

							continue;
						}

						if (tar.szemelyek.Count == 0)
						{
							Console.WriteLine("Nincs hozzárendelhető személy.");
							Console.ReadKey();

							continue;
						}


						List<string> szemelyek2 = new List<string>();
						List<string> ugyek3 = new List<string>();

						foreach (Szemely szemely in tar.szemelyek)
						{
							szemelyek2.Add($"{szemely.nev}, született {2026 - szemely.eletkor}");
						}

						foreach (Ugy ugy3 in tar.ugyek)
						{
							ugyek3.Add($"{ugy3.azonosito} {ugy3.cim} - {ugy3.allapot}");
						}

						int valasztasSzemely2 = ValasztasLista(szemelyek2);

						Fejlec("Személy hozzárendelése");

						int valasztasUgy2 = ValasztasLista(ugyek3);

						Fejlec("Személy hozzárendelése");

						Console.WriteLine(tar.ugyek[valasztasUgy2].ToString() + "\n");
						Console.WriteLine(tar.szemelyek[valasztasSzemely2].ToString());
						Console.Write("\nHelyes? (i/n) ");

						char key5 = Console.ReadKey().KeyChar;
						Console.WriteLine("");

						if (key5 == 'i')
						{
							tar.ugyek[valasztasUgy2].szemelyek.Add(tar.szemelyek[valasztasSzemely2]);

							Console.WriteLine("\nSzemély hozzárendelése sikeres.");
						}
						else
						{
							Console.WriteLine("\nSzemély hozzárendelése megszakítva.");
						}

						Console.ReadKey();
						break;

					case 4:
						Fejlec("Gyanusított hozzárendelése");

						if (tar.ugyek.Count == 0)
						{
							Console.WriteLine("Nincsenek ügyek.");
							Console.ReadKey();

							continue;
						}

						if (tar.szemelyek.Count == 0)
						{
							Console.WriteLine("Nincs hozzárendelhető személy.");
							Console.ReadKey();

							continue;
						}

						List<string> szemelyek = new List<string>();
						List<string> ugyek2 = new List<string>();

						foreach (Szemely szemely in tar.szemelyek)
						{
							szemelyek.Add($"{szemely.nev}, született {2026 - szemely.eletkor}");
						}

						foreach (Ugy ugy2 in tar.ugyek)
						{
							ugyek2.Add($"{ugy2.azonosito} {ugy2.cim} - {ugy2.allapot}");
						}

						int valasztasSzemely = ValasztasLista(szemelyek);

						Fejlec("Gyanusított hozzárendelése");

						int valasztasUgy = ValasztasLista(ugyek2);

						Fejlec("Gyanusított hozzárendelése");

						int gyanusitottsag;
						Console.Write("Gyanusítottsági szint (0-100): ");
						bool sikeres = int.TryParse(Console.ReadLine(), out gyanusitottsag);

						if (sikeres && gyanusitottsag > 0 && gyanusitottsag <= 100)
						{
							Console.Write("Gyanusított státusza: ");
							string statusz = Console.ReadLine();

							Gyanusitott gyanusitott = new Gyanusitott(tar.szemelyek[valasztasSzemely], gyanusitottsag, statusz);

							Fejlec("Gyanusított hozzárendelése");

							Console.WriteLine(tar.ugyek[valasztasUgy].ToString() + "\n");
							Console.WriteLine(gyanusitott.ToString());
							Console.Write("\nHelyes? (i/n) ");

							char key4 = Console.ReadKey().KeyChar;
							Console.WriteLine("");

							if (key4 == 'i')
							{
								tar.ugyek[valasztasUgy].gyanusitottak.Add(gyanusitott);

								Console.WriteLine("\nGyanusított hozzárendelése sikeres.");
							}
							else
							{
								Console.WriteLine("\nGyanusított hozzárendelése megszakítva.");
							}
						}
						else
						{
							Console.WriteLine("\nÉrvénytelen érték, gyanusított hozzárendelése megszakítva.");
						}

						Console.ReadKey();
						break;
				}
			} while (opcio != 6);
		}

		static void FoMenu()
		{
			AdatTar tar = new AdatTar();

			UgyKezelo ugyKezelo = new UgyKezelo(tar);
			BizonyitekKezelo bizonyitekKezelo = new BizonyitekKezelo(tar);

			string[] menuOpciok = { "Személyek", "Ügyek", "Bizonyítékok", "Kilépés" };
			int opcio;

			do
			{
				Fejlec("Fő");

				Console.WriteLine("Válasszon almenüt:");
				opcio = ValasztasMenu(menuOpciok);

				switch (opcio)
				{
					case 0:
						SzemélyekAlMenu(tar);
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
