﻿using EveShopping.Modelo.EntidadesAux;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDPVImportAssetsForDelta
    {
        public IEnumerable<AssetImported> Assets { get; set; }
    }
}