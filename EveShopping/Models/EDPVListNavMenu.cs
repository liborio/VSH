using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDPVListNavMenu
    {
        public EDPVListNavMenu(Enumerados.StepsForPVPList _currentStep)
        {
            CurrentStep = _currentStep;
        }

        public Enumerados.StepsForPVPList CurrentStep
        {
            get;
            set;
        }


    }
}