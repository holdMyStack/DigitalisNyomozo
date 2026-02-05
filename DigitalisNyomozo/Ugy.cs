using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Ugy
	{
		public string azonosito;
		public string cim;
		public string leiras;
		public string allapot;
		public List<Szemely> szemelyek;
		public List<Bizonyitek> bizonyitekok;
		public List<Gyanusitott> gyanusitottak;

		public Ugy(string azonosito, string cim, string leiras, string allapot, List<Szemely> szemelyek, List<Bizonyitek> bizonyitekok, List<Gyanusitott> gyanusitottak)
		{
			this.azonosito = azonosito;
			this.cim = cim;
			this.leiras = leiras;
			this.allapot = allapot;
			this.szemelyek = szemelyek;
			this.bizonyitekok = bizonyitekok;
			this.gyanusitottak = gyanusitottak;
		}

		public override string ToString()
		{
			string szemelyekString = "";
			string bizonyitekokString = "";
			string gyanusitottakString = "";

			foreach (Szemely szemely in szemelyek)
			{
				szemelyekString += $"\n{szemely.ToString()}";
			}

			foreach (Bizonyitek bizony in bizonyitekok)
			{
				szemelyekString += $"\n{bizony.ToString()}";
			}

			foreach (Gyanusitott gyanusitott in gyanusitottak)
			{
				gyanusitottakString += $"\n{gyanusitott.ToString()}";
			}

			return $"== {azonosito} {cim} - {allapot} ==\nLeírás: {leiras}\nSzemélyek:{szemelyekString}\nBizonyítékok:{bizonyitekokString}\nGyanusítottak:{gyanusitottakString}";
		}
	}
}
