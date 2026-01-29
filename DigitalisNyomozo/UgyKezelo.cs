using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class UgyKezelo
	{
		List<Ugy> ugyek;

		public UgyKezelo()
		{
			ugyek = new List<Ugy>();
		}

		public void HozzaAd(Ugy ugy)
		{
			ugyek.Add(ugy);
		}

		public List<Ugy> Listaz()
		{
			return ugyek;
		}

		public void Torol(Ugy ugy)
		{
			ugyek.Remove(ugy);
		}
	}
}
