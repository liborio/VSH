using EveShopping.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EveShopping.Models
{
    public class EDPVListNavMenu<T>
    {
        public EDPVListNavMenu(T _currentStep)
        {
            CurrentStep = _currentStep;
        }

        public T CurrentStep
        {
            get;
            set;
        }


    }
}