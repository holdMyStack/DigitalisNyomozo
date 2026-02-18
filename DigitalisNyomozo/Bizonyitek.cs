using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalisNyomozo
{
	internal class Bizonyitek
	{
		string azonosito;
		string tipus;
		string leiras;
		int megbizhatosagiErtek;

		public Bizonyitek(string azonosito, string tipus, string leiras, int megbizhatosagiErtek)
		{
			this.azonosito = azonosito;
			this.tipus = tipus;
			this.leiras = leiras;
			this.megbizhatosagiErtek = megbizhatosagiErtek;
		}

        public override string ToString()
        {
			return $"> {azonosito} {tipus}, megbízhatóság: {megbizhatosagiErtek}/5\n> {leiras}";
        }

        public string Azonosito { get => azonosito; }
        public string Tipus { get => tipus; }
        public string Leiras { get => leiras; }
        public int MegbizhatosagiErtek { get => megbizhatosagiErtek; }
    }
}
