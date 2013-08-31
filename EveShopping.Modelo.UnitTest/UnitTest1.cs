using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveShopping.Logica.Conversion;
using System.Collections.Generic;
using EveShopping.Modelo.Models;
using System.Linq;

namespace EveShopping.Logica.UnitTest
{
    [TestClass]
    public class UnitTestConversorEveXmlToFitList
    {
        [TestMethod]
        public void TestConversionTresNaves()
        {
            IConversorFit conv = new ConversorEveXmlToFitList();

            string fitOriginal = RecursosPrueba.EveXmlTresNaves;

            IEnumerable<eshFitting> lista =
                conv.ToFitList(fitOriginal);

            Assert.IsNotNull(lista);
            Assert.AreEqual(lista.Count(), 3);
            Assert.AreEqual(lista.First().name, "breacher - dual td v1.3");            
        }
    }
}
