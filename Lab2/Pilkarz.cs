using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Pilkarz
    {
        #region Prop
        public string Imie { get; set;}
        public string Nazwisko { get; set; }
        public uint Wiek { get; set; }
        public uint Waga { get; set; }
        #endregion

        #region constr
        public Pilkarz (string imie, string nazwisko, uint wiek, uint waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }
        public Pilkarz(string imie, string nazwisko) : this(imie, nazwisko, 25, 75) { }


        #endregion

        #region methods

        public override string ToString()
        {
            return $"{Nazwisko} {Imie} lat {Wiek} waga: {Waga}";
        }
        public bool isEqual(Pilkarz p)
        {
            if (p.Imie != Imie)
                return false;
            if (p.Nazwisko != Nazwisko)
                return false;
            if (p.Wiek != Wiek)
                return false;
            if (p.Waga != Waga)
                return false;
            return true;
        }

        public void podmien(Pilkarz p)
        {
            Imie = p.Imie;
            Nazwisko = p.Nazwisko;
            Wiek = p.Wiek;
            Waga = p.Waga;
        }

        public string ToFileFormat()
        {
            return $"{Nazwisko},{Imie},{Wiek},{Waga}";
        }

        public static Pilkarz CreateFromString(string stringPilkarz)
        {
            string imie, nazwisko;
            uint wiek, waga;
            var tab = stringPilkarz.Split(',');
            if (tab.Length == 4)
            {
                nazwisko = tab[0];
                imie = tab[1];
                wiek = uint.Parse(tab[2]);
                waga = uint.Parse(tab[3]);
                return new Pilkarz(imie, nazwisko, wiek, waga);
            }
            throw new Exception("Błędny format danych z pliku");
        }

        #endregion 

    }
}
