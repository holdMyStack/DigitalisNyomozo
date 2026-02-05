using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Szemely
	{
		public string nev;
		public int eletkor;
		public string megjegyzes;

		public Szemely(string nev, int eletkor, string megjegyzes)
		{
			this.nev = nev;
			this.eletkor = eletkor;
			this.megjegyzes = megjegyzes;
		}

		public string Szovegge()
		{
			return $"{nev}, született {2026 - eletkor}";
		}
	}
}
