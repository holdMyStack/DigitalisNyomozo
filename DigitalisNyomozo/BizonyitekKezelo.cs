using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class BizonyitekKezelo
	{
		List<Bizonyitek> bizonyitekok;

		public BizonyitekKezelo()
		{
			bizonyitekok = new List<Bizonyitek>();
		}

		public void HozzaAd(Bizonyitek bizonyitek)
		{
			bizonyitekok.Add(bizonyitek);
		}

		public void Torol(Bizonyitek bizonyitek)
		{
			bizonyitekok.Remove(bizonyitek);
		}
	}
}
