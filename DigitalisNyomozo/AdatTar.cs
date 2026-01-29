using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class AdatTar
	{
		List<Felhasznalo> felhasznalok;
		List<Ugy> ugyek;
		List<Szemely> szemelyek;
		List<Bizonyitek> bizonyitekok;

		public AdatTar()
		{
			felhasznalok = new List<Felhasznalo>();
			ugyek = new List<Ugy>();
			szemelyek = new List<Szemely>();
			bizonyitekok = new List<Bizonyitek>();
		}
	}
}
