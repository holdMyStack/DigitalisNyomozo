using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class UgyKezelo
	{
		AdatTar tar;

		public UgyKezelo(AdatTar tar)
		{
			this.tar = tar;
		}

		public void UgyHozzaAd(Ugy ugy)
		{
			tar.ugyek.Add(ugy);
		}

		public void SzemelyHozzaAd(Ugy ugy, Szemely szemely)
		{
			ugy.szemelyek.Add(szemely);
		}

		public void BizonyítekHozzaAd(Ugy ugy, Bizonyitek bizonyitek)
		{
			ugy.bizonyitekok.Add(bizonyitek);
		}
	}
}
