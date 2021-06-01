using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TDDPersoonLibrary
{
    public class Persoon
    {
        private List<string> voornamen;

        //constructor
        public Persoon(List<string> voornamen)
        {
            if (voornamen == null)
                throw new ArgumentNullException();
            
            this.voornamen = voornamen;

            string voornaam = string.Empty;

            for (int i = 0; i < this.voornamen.Count; i++)
            {
                voornaam = this.voornamen[i];

                //exception opgooien indien voornaam meer dan één keer in de list voorkomt
                if (TelAantalKeerStringInList(this.voornamen, voornaam) > 1)
                {
                    throw new ArgumentException();
                }

                //exception opgooien indien de voornaam geen enkel teken bevat
                if (voornaam.Length == 0)
                {
                    throw new ArgumentException();
                }
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.voornamen.Count; i++)
            {
                sb.Append(this.voornamen[i]);

                if (i != this.voornamen.Count - 1)
                    sb.Append(" ");     //spatie als scheidingsteken tussen de verschillende voornamen
            }

            return sb.ToString();
        }

        static int TelAantalKeerStringInList(List<string> list, string valueToFind)
        {
            int count = list.Where(temp => temp.Equals(valueToFind))
                        .Select(temp => temp)
                        .Count();
            return count;
        }
    }
}
