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
        private readonly List<string> voornamen;

        //constructor
        public Persoon(List<string> voornamen)
        {
            this.voornamen = voornamen;                
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            string voornaam = string.Empty;

            for (int i = 0; i < this.voornamen.Count; i++)
            {
                voornaam = this.voornamen[i];
                
                sb.Append(voornaam);

                if (i != this.voornamen.Count - 1)
                {
                    sb.Append(" ");
                }

                if (CountOccurenceOfValue2(this.voornamen, voornaam) > 1)
                {
                    throw new ArgumentException();
                }

                if (voornaam.Length == 0)
                {
                    throw new ArgumentException();
                }
            }

            return sb.ToString();
        }

        static int CountOccurenceOfValue2(List<string> list, string valueToFind)
        {
            int count = list.Where(temp => temp.Equals(valueToFind))
                        .Select(temp => temp)
                        .Count();
            return count;
        }
    }
}
