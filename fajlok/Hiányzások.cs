using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hianyzasok
{
    class Program
    {
        static string[] naplo = new string[600];
        static int sorszam = 0;
        struct diakrekord
        {
            public string vezeteknev;
            public string keresztnev;
            public int igazolt;
            public int igazolatlan;
            public int hianyzas;
        }
        static int diakszam = 0;
        static diakrekord[] osztaly = new diakrekord[50];
        static void Main(string[] args)
        {
            feladat1();
            feladat2();
            feladat3();
            feladat4();
            feladat5();
            feladat6();
            feladat7();
            Console.ReadKey();
        }
        static void feladat1()
        {
            Console.WriteLine("1. feladat");
            Console.WriteLine("naplo.txt fájl beolvasása");
            FileStream fajlbe = new FileStream("..\\..\\naplo.txt",FileMode.Open);
            StreamReader beolvas = new StreamReader(fajlbe);
            while (!beolvas.EndOfStream)
            {
                naplo[sorszam] = beolvas.ReadLine(); //minden sor beolvasása
                sorszam++;
            }
            beolvas.Close();
            fajlbe.Close();
        }
        static void feladat2()
        {
            int hianyzas = 0;
            for (int i=0; i<sorszam; i++) if (naplo[i][0] != '#') hianyzas++;
            Console.WriteLine("2. feladat");
            Console.WriteLine("A naplóban {0} bejegyzés van.",hianyzas);
        }
        static void feladat3()
        {
            int igazolt = 0;
            int igazolatlan = 0;
            for (int i=0; i<sorszam; i++) if(naplo[i][0]!='#')
            {
                string[] tordelt = naplo[i].Split(' ');
                for (int j=0; j<tordelt[2].Length; j++)
                {
                    if (tordelt[2][j] == 'X') igazolt++;
                    if (tordelt[2][j] == 'I') igazolatlan++;
                }
            }
            Console.WriteLine("3. feladat");
            Console.WriteLine("Az igazolt hiányzások száma {0}, az igazolatlanoké {1}.",igazolt,igazolatlan);
        }
        static void feladat4()
        {
            Console.WriteLine("4. feladat");
            Console.WriteLine("A hetnapja függvény létrehozása.");
        }
        static void feladat5()
        {
            Console.WriteLine("5. feladat");
            Console.Write("A hónap sorszáma: ");
            int honap = Convert.ToInt32(Console.ReadLine());
            Console.Write("A nap sorszáma: ");
            int nap = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Azon a napon {0} volt.",hetnapja(honap,nap));
        }
        static void feladat6()
        {
            Console.WriteLine("6. feladat");
            Console.Write("A nap neve: ");
            string nap = Console.ReadLine();
            Console.Write("Az óra sorszáma: ");
            int hanyadik = Convert.ToInt32(Console.ReadLine());
            int hianyzas = 0;
            for (int i = 0; i < sorszam; i++)
            {
                if (naplo[i][0] == '#')
                {
                    string[] tordelt = naplo[i].Split(' ');
                    int honap = Convert.ToInt32(tordelt[1]);
                    int nap1 = Convert.ToInt32(tordelt[2]);
                    if (hetnapja(honap, nap1) == nap)
                    {
                        i++;
                        while(naplo[i][0]!='#' && i < sorszam)
                        {
                            string[] tordelt1 = naplo[i].Split(' ');
                            if(tordelt1[2][hanyadik-1]=='X' || tordelt1[2][hanyadik - 1] == 'I') hianyzas++;
                            i++;
                        }
                    }
                }
            }
            Console.WriteLine("Ekkor összesen {0} óra hiányzás történt.",hianyzas);
        }
        static void feladat7()
        {
            //diákok kiválogatása
            for(int i = 0; i < sorszam; i++) if(naplo[i][0] != '#')
            {
                string[] tordelt = naplo[i].Split(' ');
                bool van = false;
                for(int j = 0; j < diakszam; j++) if(tordelt[0]==osztaly[j].vezeteknev && tordelt[1] == osztaly[j].keresztnev) van = true;
                if (van == false)
                {
                    osztaly[diakszam].vezeteknev = tordelt[0];
                    osztaly[diakszam].keresztnev = tordelt[1];
                    diakszam++;
                }
            }
            //hiányzások összeszámlálása
            for(int i = 0; i < sorszam; i++)
            {
                if (naplo[i][0] != '#')
                {
                    string[] tordelt = naplo[i].Split(' ');
                    int j = 0;
                    while(tordelt[0]!=osztaly[j].vezeteknev || tordelt[1] != osztaly[j].keresztnev)
                    {
                        j++;
                    }
                    for (int k=0; k < tordelt[2].Length; k++)
                    {
                        if (tordelt[2][k] == 'X')
                        {
                            osztaly[j].igazolt++;
                            osztaly[j].hianyzas++;
                        }
                        if (tordelt[2][k] == 'I')
                        {
                            osztaly[j].igazolatlan++;
                            osztaly[j].hianyzas++;
                        }
                    }
                }
            }
            //legtöbb hiányzás megkeresése
            int max = 0;
            for(int i=0; i<diakszam; i++)
            {
                if (osztaly[i].hianyzas > max)
                {
                    max = osztaly[i].hianyzas;
                }
            }
            Console.WriteLine("7. feladat");
            Console.Write("A legtöbbet hiányzó tanulók: ");
            for (int i=0; i<diakszam; i++)
            {
                if(osztaly[i].hianyzas == max)
                {
                    Console.Write("{0} {1} ",osztaly[i].vezeteknev,osztaly[i].keresztnev);
                }
            }
        }
        static string hetnapja(int honap,int nap)
        {
            string[] napnev = {"vasárnap","hétfő","kedd","szerda","csütörtök","péntek","szombat"};
            int[] napszam = {0,31,59,90,120,151,181,212,243,273,304,335};
            int napsorszam = (napszam[honap - 1] + nap) % 7;
            return napnev[napsorszam];
        }
    }
}
