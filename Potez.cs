using System;

namespace Igra1
{
    public class Potez
    {
        public string ime { get; set; }
        public int snaga { get; set; }
        public int preciznost { get; set; }
        public Random rand = new Random();

        public Potez(string ime,  int snaga, int preciznost)
        {
            this.ime = ime;
            this.snaga = snaga;
            this.preciznost = preciznost;
        }

        public bool KoristiPotez()
        {  
            if(rand.Next(100) >= preciznost)
                return false;

            return true;
        } 

        public void IspisiPotez()
        {
            Console.WriteLine($"{ime} (Snaga: {snaga}, Preciznost: {preciznost})");
        }
    }
}
