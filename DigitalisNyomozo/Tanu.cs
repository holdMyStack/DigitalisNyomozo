using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Tanu
	{
		Szemely szemely;
		string vallomasSzovege;
		DateTime vallomasDatuma;

		public Tanu(Szemely szemely, string vallomasSzovege, DateTime vallomasDatuma)
		{
			this.szemely = szemely;
			this.vallomasSzovege = vallomasSzovege;
			this.vallomasDatuma = vallomasDatuma;
		}
	}
}
