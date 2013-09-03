using System;
using System.Collections.Generic;

namespace EveShopping.Modelo
{
    public partial class mapCelestialStatistic
    {
        public int celestialID { get; set; }
        public Nullable<double> temperature { get; set; }
        public string spectralClass { get; set; }
        public Nullable<double> luminosity { get; set; }
        public Nullable<double> age { get; set; }
        public Nullable<double> life { get; set; }
        public Nullable<double> orbitRadius { get; set; }
        public Nullable<double> eccentricity { get; set; }
        public Nullable<double> massDust { get; set; }
        public Nullable<double> massGas { get; set; }
        public Nullable<bool> fragmented { get; set; }
        public Nullable<double> density { get; set; }
        public Nullable<double> surfaceGravity { get; set; }
        public Nullable<double> escapeVelocity { get; set; }
        public Nullable<double> orbitPeriod { get; set; }
        public Nullable<double> rotationRate { get; set; }
        public Nullable<bool> locked { get; set; }
        public Nullable<double> pressure { get; set; }
        public Nullable<double> radius { get; set; }
        public Nullable<double> mass { get; set; }
    }
}
