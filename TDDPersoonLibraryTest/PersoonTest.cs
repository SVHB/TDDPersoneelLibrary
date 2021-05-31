using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDDPersoonLibrary;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Text.RegularExpressions;

namespace TDDPersoonLibraryTest
{
    [TestClass]
    public class PersoonTest
    {
        List<string> voornamen;

        [TestInitialize]
        public void Initialize()
        {
            voornamen = new List<string>();
        }

        [TestMethod]
        public void EenPersoonHeeftEenVoornaam()
        {
            voornamen.Add("Jan");

            Assert.AreEqual(1, new Persoon(voornamen).ToString().Split(' ').Length);
        }

        public void EenPersoonHeeftTweeVoornamen()
        {
            voornamen.Add("Jan");
            voornamen.Add("Piet");

            Assert.AreEqual(2, new Persoon(voornamen).ToString().Split(' ').Length);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ElkeVoornaamHeeftEenUniekeNaam()
        {
            voornamen.Add("Jan");
            voornamen.Add("Jan");

            new Persoon(voornamen).ToString();
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        public void ElkeVoornaamBevatMinstensEenTeken()
        {
            voornamen.Add("Jan");
            voornamen.Add("");

            new Persoon(voornamen).ToString();
        }
    }
}
