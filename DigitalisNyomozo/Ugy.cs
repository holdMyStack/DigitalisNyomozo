using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Ugy
	{
		string azonosito;
		string cim;
		string leiras;
		string allapot;
		List<Szemely> szemelyek;
		List<Bizonyitek> bizonyitekok;

		public Ugy(string azonosito, string cim, string leiras, string allapot, List<Szemely> szemelyek, List<Bizonyitek> bizonyitekok)
		{
			this.azonosito = azonosito;
			this.cim = cim;
			this.leiras = leiras;
			this.allapot = allapot;
			this.szemelyek = szemelyek;
			this.bizonyitekok = bizonyitekok;
		}
	}
}
