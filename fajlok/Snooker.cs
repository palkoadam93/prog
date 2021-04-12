using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace snooker
{
    class Program
    {
        static void Main(string[] args)
        {
            //2. feladat
            StreamReader Olvas = new StreamReader("snooker.txt", Encoding.Default);
            List<Jatekos> Snooker = new List<Jatekos>();
            string Fejlec = Olvas.ReadLine();
            while (!Olvas.EndOfStream)
            {
                Snooker.Add(new Jatekos(Olvas.ReadLine()));
            }
            Olvas.Close();
            

            
            Console.WriteLine($"3. feladat: A vilagranglistan {Snooker.Count} versenyzo szerepel");
            

            
            double OsszNyeremeny = 0;
            for (int i = 0; i < Snooker.Count; i++)
            {
                OsszNyeremeny += Snooker[i].Nyeremeny;
            }
            Console.WriteLine($"4. feladat: A versenyzok atlagosan {Math.Round((OsszNyeremeny / Snooker.Count), 2)} fontot kerestek");
            

            
            Console.WriteLine("5. feladat: A legjobban kereso kinai versenyzo:");
            int LegjobbKinai = Snooker[0].Nyeremeny;
            for (int i = 0; i < Snooker.Count; i++)
            {
                if (Snooker[i].Orszag == "Kína" && Snooker[i].Nyeremeny > LegjobbKinai)
                {
                    LegjobbKinai = Snooker[i].Nyeremeny;
                }
            }
            for (int i = 0; i < Snooker.Count; i++)
            {
                if (Snooker[i].Nyeremeny == LegjobbKinai)
                {
                    decimal formatum = Snooker[i].Nyeremeny * 380;
                    string s = formatum.ToString("C0");
                    Console.WriteLine($"\tHelyezes: {Snooker[i].Helyezes}");
                    Console.WriteLine($"\tNev: {Snooker[i].Nev}");
                    Console.WriteLine($"\tOrszag: {Snooker[i].Orszag}");
                    Console.WriteLine($"\tNyeremeny összege: {s}");
                }
            }
            

            
            bool VanENorveg = false;
            for (int i = 0; i < Snooker.Count; i++)
            {
                if (Snooker[i].Orszag == "Norvégia")
                {
                    VanENorveg = true;
                }
            }
            if (VanENorveg == true)
            {
                Console.WriteLine("6. feladat: A versenyzok kozott van norveg versenyzo.");
            }
            else
            {
                Console.WriteLine("6. feladat: A versenyzok kozott nincs norveg versenyzo.");
            }
            

            
            List<string> OrszagLista = new List<string>();
            for (int i = 0; i < Snooker.Count; i++)
            {
                bool SzerepelE = false;
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if (Snooker[i].Orszag == OrszagLista[j])
                    {
                        SzerepelE = true;
                    }
                }
                if (SzerepelE == false)
                {
                    OrszagLista.Add(Snooker[i].Orszag);
                }
            }
            int[] OrszagListaSeged = new int[OrszagLista.Count];
            for (int i = 0; i < Snooker.Count; i++)
            {
                for (int j = 0; j < OrszagLista.Count; j++)
                {
                    if (Snooker[i].Orszag == OrszagLista[j])
                    {
                        OrszagListaSeged[j]++;
                    }
                }
            }
            Console.WriteLine("7. feladat: Statisztika");
            for (int i = 0; i < OrszagListaSeged.Length; i++)
            {
                if (OrszagListaSeged[i] > 4)
                {
                    Console.WriteLine($"\t{OrszagLista[i]} - {OrszagListaSeged[i]} fo");
                }
            }
            
            Console.ReadKey();
        }
    }
    class Jatekos
    {
        public int Helyezes;
        public string Nev;
        public string Orszag;
        public int Nyeremeny;

        public Jatekos(string Adatsor)
        {
            string[] AdatSorElemek = Adatsor.Split(';');
            this.Helyezes = int.Parse(AdatSorElemek[0]);
            this.Nev = AdatSorElemek[1];
            this.Orszag = AdatSorElemek[2];
            this.Nyeremeny = int.Parse(AdatSorElemek[3]);
        }
    }
}
