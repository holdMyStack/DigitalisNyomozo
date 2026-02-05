using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Gyanusitott
	{
		Szemely szemely;
		int gyanusitottsagiSzint;
		string statusz;

		public Gyanusitott(Szemely szemely, int gyanusitottsagiSzint, string statusz)
		{
			this.szemely = szemely;
			this.gyanusitottsagiSzint = gyanusitottsagiSzint;
			this.statusz = statusz;
		}

		public override string ToString()
		{
			return $"{szemely.ToString()}\n> Gyanusítottsági szint: {gyanusitottsagiSzint}\n> Státusz: {statusz}";
		}
	}
}
