using System;
using System.Collections.Generic;

namespace Igra1
{
    internal class Igrac
    {
        public string ime { get; set; }
        public Cudoviste cudoviste { get; set; }

        public Igrac(string ime, Cudoviste cudoviste)
        {
            this.ime = ime;
            this.cudoviste = cudoviste;
        }

        public void OporaviCudoviste()
        {
            this.cudoviste.trenutanHP = this.cudoviste.maxHP;
        }
    }
}
