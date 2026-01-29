using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Felhasznalo
	{
		string nev;
		string azonosito;
		string szerepkor;

		public Felhasznalo(string nev, string azonosito, string szerepkor)
		{
			this.nev = nev;
			this.azonosito = azonosito;
			this.szerepkor = szerepkor;
		}
	}
}
