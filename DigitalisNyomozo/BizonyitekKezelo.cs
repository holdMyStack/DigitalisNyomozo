using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class BizonyitekKezelo
	{
		AdatTar tar;

		public BizonyitekKezelo(AdatTar tar)
		{
			this.tar = tar;
		}

		public void HozzaAd(Bizonyitek bizonyitek)
		{
			tar.bizonyitekok.Add(bizonyitek);
		}

		public List<Bizonyitek> Listaz() {
			return tar.bizonyitekok;
		}

		public void Torol(Bizonyitek bizonyitek)
		{
			tar.bizonyitekok.Remove(bizonyitek);
		}
	}
}
