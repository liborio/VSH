using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveShopping.Logica.Conversion;
using System.Collections.Generic;
using EveShopping.Modelo;
using System.Linq;
using EveShopping.Modelo.EntidadesAux;

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

            IEnumerable<FittingAnalyzed> lista =
                conv.ToFitList(fitOriginal);

            Assert.IsNotNull(lista);
            Assert.AreEqual(lista.Count(), 3);
            Assert.AreEqual(lista.First().Name, "breacher - dual td v1.3");   
            Assert.AreEqual(lista.First().Items.Count, 21);
        }
    }
}
