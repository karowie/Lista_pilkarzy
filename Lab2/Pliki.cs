using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lab2
{
    static class Pliki
    {
        public static void ZapisPilkarzyDoPliku(string plik, Pilkarz[] lista)
        {
            using (StreamWriter stream = new StreamWriter(plik))
            {
                foreach (var p in lista)
                    stream.WriteLine(p.ToFileFormat());
                stream.Close();
            }
        }

        public static Pilkarz[] CzytajPilkarzyZPliku(string plik)
        {
            Pilkarz[] p = null;
            if (File.Exists(plik))
            {
                var sPilkarze = File.ReadAllLines(plik);
                var n = sPilkarze.Length;
                if (n > 0)
                {
                    p = new Pilkarz[n];
                    for (int i = 0; i < n; i++)
                        p[i] = Pilkarz.CreateFromString(sPilkarze[i]);
                    return p;
                }
            }
            return p;
        }


    }
}
