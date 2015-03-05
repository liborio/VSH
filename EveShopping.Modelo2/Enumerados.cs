﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveShopping.Modelo
{
    public class Enumerados
    {
        public enum TipoFormatoFitOriginal
        {
            EveXml = 0,
            EFT = 1
        }

        public enum TipoSlot
        {
            Ship = 0,
            High = 1,
            Medium = 2,
            Low = 3,
            Rigs = 4,
            DroneBay = 5,
            Cargo = 6
        }

        public enum StepsForPVPList
        {
            AddFits,
            ImportItems,
            AddMarketItems,
            MyAssets,
            Summary            
        }

        public enum StepsForGroupList
        {
            AddLists,            
            MyAssets,
            Summary
        }
    }

}
