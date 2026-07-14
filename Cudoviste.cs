using System;

namespace Igra1
{
    public class Cudoviste
    {
        public string ime { get; set; }
        public int maxHP { get; set; }
        public int trenutanHP { get; set; }
        public int ATK { get; set; }

        public Cudoviste(string ime, int maxHP, int atk)
        {
            this.ime = ime;
            this.maxHP = maxHP;
            this.ATK = atk;

            trenutanHP = maxHP;
        }

        public void PrimiUdarac(int steta)
        {
            trenutanHP -= steta;
            if (trenutanHP < 0) 
                trenutanHP = 0;
        }

        public bool JeZiv()
        {
            return trenutanHP <= 0;
        }

        public void IspisOsnovni()
        {
            Console.WriteLine($"=== {ime} ===");
            Console.WriteLine($"HP: {trenutanHP}/{maxHP}");
            Console.WriteLine($"ATK: {ATK}");
        }

        public void IspisBorba()
        {
            Console.WriteLine($"{ime} (HP: {trenutanHP}/{maxHP})");
        }
    }
}
