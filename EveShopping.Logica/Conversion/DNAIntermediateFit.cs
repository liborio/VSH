using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Logica.Conversion
{
    public class DNAIntermediateFit
    {
        public class DNAItem
        {
            public int ID { get; set; }
            public short Units { get; set; }

            public static DNAItem Parse(string szitem)
            {
                if (string.IsNullOrEmpty(szitem)) return null;

                string[] rawMod = szitem.Split(';');
                
                if (rawMod == null || rawMod.Length != 2) throw new FittingFormatNotRecognisedException(Messages.err_notRecognisedDNAFormat);

                DNAItem item = new DNAItem();
                item.ID = int.Parse(rawMod[0]);
                item.Units = short.Parse(rawMod[1]);
                return item;
            }
        }

        public string Name { get; set; }

        public int ShipID { get; set; }

        public IList<DNAItem> Items { get; set; }

        public DNAIntermediateFit()
        {
            Items = new List<DNAItem>();
        }

    }
}


