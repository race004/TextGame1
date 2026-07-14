using System;
using System.Collections.Generic;
using System.Threading;

namespace Igra1
{
    internal class Igra
    {
        private Igrac igrac;
        private Random rand = new Random();
        private List<Potez> dostupniPotezi = new List<Potez>();

        private Cudoviste igracevoCudoviste;
        private Cudoviste protivnickoCudoviste;

        public void Run()
        {
            InicializujIgru();
            ZapocniIgru();

            bool trenutnoIgra = true;
            while(trenutnoIgra)
            {
                Console.Clear();
                igrac.cudoviste.IspisOsnovni();

                Console.WriteLine("Sta hoces da radis?");
                Console.WriteLine("1. Bori se");
                Console.WriteLine("2. Izadji iz igre");

                Console.Write("Izaberi opciju ");
                string izbor = Console.ReadLine();

                switch (izbor)
                {
                    case "1":
                        Borba();
                        break;
                    case "2":
                        trenutnoIgra = false;
                        Console.WriteLine("Hvala sto ste igrali");
                        break;
                    default:
                        Console.WriteLine("Pokusajte ponovo!");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }

        private void InicializujIgru()
        {
            dostupniPotezi.Add(new Potez("Normalan", 50, 75));
            dostupniPotezi.Add(new Potez("Brz", 39, 95));
            dostupniPotezi.Add(new Potez("Jak", 80, 50));
            dostupniPotezi.Add(new Potez("Preskoci", 0, 100));

            igracevoCudoviste = new Cudoviste("Vuk", 100, 50);
            protivnickoCudoviste = new Cudoviste("Krava", 200, 20);

            Console.Write("Tvoje ime: ");
            string ime = Console.ReadLine();
            igrac = new Igrac(ime,igracevoCudoviste);
        }

        private void ZapocniIgru()
        { 
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("       Dobrodosli        ");
            Console.WriteLine("=========================");
            Console.WriteLine($"Pozdrav {igrac.ime}");
            Console.WriteLine("Pritisni bilo koje dugme da zapocnes...");
            Console.ReadKey();
        }

        private void Borba()
        {
            Console.Clear();
            Console.WriteLine("Borba zapocinje");
            Thread.Sleep(1000);
            igracevoCudoviste.trenutanHP = igracevoCudoviste.maxHP;
            protivnickoCudoviste.trenutanHP = protivnickoCudoviste.maxHP;

            Console.WriteLine($"Pojavilo se cudoviste {protivnickoCudoviste.ime}");
            protivnickoCudoviste.IspisBorba();

            while(protivnickoCudoviste.trenutanHP > 0 && igracevoCudoviste.trenutanHP > 0)
            {
                BorbaPotez(igracevoCudoviste, protivnickoCudoviste);
            }

            if(protivnickoCudoviste.trenutanHP == 0)
            {
                Console.WriteLine("Pobeda");
            }
            else
            {
                Console.WriteLine("Poraz, pokusajte ponovo.");
            }    

                Console.WriteLine("Pritisnite bilo koje dugme da nastavite...");
            Console.ReadKey();
        }

        private void BorbaPotez(Cudoviste prvo, Cudoviste drugo)
        {
            for (int i = 0; i < dostupniPotezi.Count; i++)
            {
                Console.Write(i+1 + ". ");
                dostupniPotezi[i].IspisiPotez();
            }

            Console.Write("\nKako zelite napasti protivnika? ");
            string pokret = Console.ReadLine();

            switch (pokret)
            {
                case "1":
                    IspisNapada(dostupniPotezi[0], igracevoCudoviste, protivnickoCudoviste);
                    break;
                case "2":
                    IspisNapada(dostupniPotezi[1], igracevoCudoviste, protivnickoCudoviste);
                    break;
                case "3":
                    IspisNapada(dostupniPotezi[2], igracevoCudoviste, protivnickoCudoviste);
                    break;
                case "4":
                    IspisNapada(dostupniPotezi[3], igracevoCudoviste, protivnickoCudoviste);
                    break;
            }

            if(!protivnickoCudoviste.JeZiv())
            {
                int protivnickiPokret = rand.Next(4);
                IspisNapada(dostupniPotezi[protivnickiPokret], protivnickoCudoviste, igracevoCudoviste);
            }
        }

        private void IspisNapada(Potez napad, Cudoviste napadac, Cudoviste primac)
        {
            int steta = napad.snaga * napadac.ATK / 100;
            bool pogodak = napad.KoristiPotez();
            if(pogodak)
            {
                primac.PrimiUdarac(steta);
                Console.WriteLine($"{primac.ime} je primio {steta} stete");
            }
            else
            {
                Console.WriteLine("Promasaj");
            }

            primac.IspisBorba();
        }
    }
}
