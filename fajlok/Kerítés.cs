using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2018_okt
{
    class Adatok
    {
        public int Oldal { get; set; }
        public int Hossz { get; set; }
        public char Szín { get; set; }
        public int Hazszam { get; set; }
        public string Kerites { get; set; }
        public string Szamozas { get; set; }
        public Adatok(int hazszam, int oldal, int hossz, char szín)
        {
            Hazszam = hazszam;
            Oldal = oldal;
            Hossz = hossz;
            Szín = szín;
            for (int i = 1; i <= hossz; i++)
            {
                Kerites += szín;
            }
            string h = hazszam.ToString();
            Szamozas = h;
            for (int i = h.Length; i < hossz; i++)
            {
                Szamozas += ' ';
            }
        }

    }
    class Program
    {
        static List<Adatok> paros = new List<Adatok>();
        static List<Adatok> paratlan = new List<Adatok>();
        static List<int> oldal = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("1.feladat: ");
            Beolvasas();
            Console.WriteLine("2.feladat: ");
            Console.WriteLine("Az eladott telkek száma: {0}", paros.Count + paratlan.Count);
            Console.WriteLine("3.feladat: ");
            Console.WriteLine("A {0} oldalon adták el az utolsó telket", oldal[oldal.Count - 1] == 0 ? "paros" : "paratlan");
            Console.WriteLine("Az utolsó eladott telek házszáma: {0}", oldal[oldal.Count - 1] == 0 ? paros[paros.Count - 1].Hazszam : paratlan[paratlan.Count - 1].Hazszam);
            Console.WriteLine("4.feladat: ");
            Console.WriteLine("A szomszédossal egyezik az előző: {0}", Ugyanolyan());
            Console.WriteLine("5.feladat: ");
            Console.Write("Adjon meg egy házszámot: ");
               int hazszam = int.Parse(Console.ReadLine());
            KeritesFestes(hazszam);
            Console.WriteLine("6.feladat: ");
            Kiír();
            Console.ReadKey();
        }
        private static void Beolvasas()
        {
            StreamReader sr = new StreamReader("kerites.txt");
            int pshsz = 0;
            int pthsz = -1;
            while (!sr.EndOfStream)
            {
                string[] sor = sr.ReadLine().Split(' ');
                if (sor[0] == "0")
                {
                    pshsz += 2;
                    oldal.Add(int.Parse(sor[0]));
                    paros.Add(new Adatok(pshsz, int.Parse(sor[0]), int.Parse(sor[1]), char.Parse(sor[2])));
                }
                else
                {
                    pthsz += 2;
                    oldal.Add(int.Parse(sor[0]));
                    paratlan.Add(new Adatok(pthsz, int.Parse(sor[0]), int.Parse(sor[1]), char.Parse(sor[2])));
                }
            }
            sr.Close();


        }
        static int Ugyanolyan()
        {
            int hsz = 0;
            int i = 0;
            while (i < paratlan.Count - 1 && !Egyezik(paratlan[i].Szín, paratlan[i + 1].Szín))
            {
                i++;
            }
            hsz = paratlan[i].Hazszam;
            return hsz;
        }
        static bool Egyezik(char c1, char c2)
        {
            bool egyezik = false;
            if (c1 == c2 && c1 != '#' && c1 != ':')
            {
                egyezik = true;
            }
            return egyezik;

        }
        static void KeritesFestes(int hsz)
        {
            int i = 0;
            char elotte = ' ';
            char utana = ' ';
            char szín = ' ';
            if (hsz % 2 == 0)
            {
                foreach(Adatok a in paros)
                {
                    if (a.Hazszam == hsz)
                    {
                        szín = a.Szín;
                        elotte = paros[i - 1].Szín;
                        utana = paros[i + 1].Szín;
                        Console.WriteLine("A kerítés színe/állapota: {0}",szín);
                        
                    }
                    i++;
                }
                if (szín == ':')
                {
                    Console.WriteLine("Nincs kerítés");
                }
                else
                {
                    Console.WriteLine("Egy lehetséges festési szín: {0}",Melyikszín(szín,elotte,utana));
                }
            }
            else
            {
                foreach (Adatok a in paratlan)
                {
                    if (a.Hazszam == hsz)
                    {
                        szín = a.Szín;
                        elotte = paratlan[i - 1].Szín;
                        utana = paratlan[i + 1].Szín;
                        Console.WriteLine("A kerítés színe/állapota: {0}", szín);
                    }
                    i++;

                }
                if (szín == ':')
                {
                    Console.WriteLine("Nincs kerítés");
                }
                else
                {
                    Console.WriteLine("Egy lehetséges festési szín: {0}", Melyikszín(szín, elotte, utana));
                }
            }
        }
        static char Melyikszín(char ksz, char elotte, char utana)
        {
            char s = ' ';
            for (s = 'A'; s <= 'Z' && (Egyezik(s, ksz) || Egyezik(s, elotte) || Egyezik(s, utana)); s++)
            {

            }
            return s;
            
        }
        static void Kiír()
        {
            StreamWriter sw = new StreamWriter("utcakep.txt");
            string str1 = "";
            string str2 = "";
            foreach(Adatok a in paratlan)
            {
                str1 += a.Kerites;
                str2 += a.Szamozas;
            }
            sw.WriteLine(str1);
            sw.WriteLine(str2);
            sw.Close();
        }

    }
}
