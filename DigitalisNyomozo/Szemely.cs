using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Szemely
	{
		string nev;
		int eletkor;
		string megjegyzes;

		public Szemely(string nev, int eletkor, string megjegyzes)
		{
			this.nev = nev;
			this.eletkor = eletkor;
			this.megjegyzes = megjegyzes;
		}
	}
}
