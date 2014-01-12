using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EveShopping.Logica.Conversion;
using System.Collections.Generic;
using EveShopping.Modelo.EntidadesAux;

namespace EveShopping.Logica.UnitTest
{
    [TestClass]
    public class ImportAssetsTest
    {
        [TestMethod]
        public void TestImportFrom()
        {
            ImportItemListFromAssets importer = new ImportItemListFromAssets();
            IDictionary<string, AssetImported> assets = importer.ImportFrom(RecursosPrueba.assets1);
            Assert.IsNull(assets);
        }
    }
}
