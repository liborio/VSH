using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.Conversion
{
    public class ImportItemListFromAssets
    {
        public IDictionary<string, AssetImported> ImportFrom(string szassets)
        {
            Dictionary<string, AssetImported> diccSalida = new Dictionary<string, AssetImported>();
            string[] assetlist = szassets.Split(new string[]{"\n", "\r\n"}, StringSplitOptions.RemoveEmptyEntries);

            string nombre = null;
            int units = 0;
            foreach (var item in assetlist)
            {
                string [] assetparts = item.Split(new string[]{"\t"}, StringSplitOptions.None);
                nombre =  assetparts[0];
                if (string.IsNullOrEmpty(assetparts[1])){
                    units = 1;
                }
                else{
                    units = int.Parse(assetparts[1].Replace(".", "").Replace(",", ""));
                }

                
                //add to the dictionary or increment the units in it
                if (diccSalida.ContainsKey(nombre)){
                    diccSalida[nombre].Units += units;
                }
                else{
                    AssetImported asset = new AssetImported() { Name = nombre, Units = units };
                    diccSalida.Add(nombre, asset);
                }
            }
            return diccSalida;
        }
    }
}
