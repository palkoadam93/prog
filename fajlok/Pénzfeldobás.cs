using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2015_okt
{
    class Program
    {
        public static Random rd = new Random();
        static void Main(string[] args)
        {
            Console.WriteLine("1.feladat: ");
            Console.WriteLine("A penzfeldobas eredmenye: {0}",Feldobas());
            Console.WriteLine("2.feladat: ");
            Console.WriteLine("Adjon meg egy tippet: ");
            char tipp = char.Parse(Console.ReadLine());
            char eredmeny = Feldobas();
            Console.WriteLine("A tipp:{0} A dobás eredménye:{1}",tipp,eredmeny);
            Console.WriteLine(tipp==eredmeny?"Ön eltalálta" : "Nem találta el");
            Console.WriteLine("3.feladat: ");
            Feldolgozas();
            Console.WriteLine("7.feladat:");
            Sorozatok();
            Kiir();

            Console.ReadKey();
        }
        static char Feldobas()
        {
            char ertek = ' ';
            ertek = rd.Next(2) == 0 ? 'F' : 'I';
            return ertek;
        }
        static void Feldolgozas()
        {
            
            int szamlalo = 0;
            int fej = 0;
            int iras = 0;
            int maxfej = 0;
            int maxfejsor = 0;
            int maxfejsorszam = 0;
            int ketfej = 0;
            char elem = ' ';
            StreamReader sr = new StreamReader("kiserlet.txt");
            while (!sr.EndOfStream)
            {
                elem = char.Parse(sr.ReadLine());
                szamlalo++;
                if (elem == 'F')
                {
                    fej++;
                    maxfejsor++;
                }
                else
                {
                    iras++;
                    if (maxfejsor > maxfej)
                    {
                        maxfej = maxfejsor;
                        maxfejsorszam = szamlalo - maxfejsor;
                    }
                    if (maxfejsor == 2)
                    {
                        ketfej++;
                    }
                    maxfejsor = 0;
                }
                

            }
            sr.Close();
           
            Console.WriteLine("A kisérlet {0} dobásból állt.",szamlalo);
            float arany = (float)fej / (float)szamlalo;
            Console.WriteLine("4.feladat: ");
            Console.WriteLine("A kiserlet soran a relativ gyakoriság {0:P2}",arany);
            Console.WriteLine("5.feladat:");
            Console.WriteLine("{0} Db két fejet dobtak.",ketfej );
            Console.WriteLine("6.feladat: ");
            Console.WriteLine("A leghosszabb tisztafej sorozat {0} karakterből áll {1}. dobással kezdődött.",maxfej,maxfejsorszam);
        }
        static void Sorozatok()
        {
            string[] sorozat = new string[1000];
            int db = 4;
            char dobas = ' ';
            string dobasok = "";
            int FFFFdb = 0;
            int FFFIDB = 0;
            for(int i = 0; i < 1000; i++)
            {
                for(int j = 0; j < 4; j++)
                {
                    dobas = Feldobas();
                    dobasok += dobas;
                }
                sorozat[i] = dobasok;
                if (sorozat[i].CompareTo("FFFF") == 0)
                {
                    FFFFdb++;
                }
            }
            for (int i = 0; i < 1000; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    dobas = Feldobas();
                    dobasok += dobas;
                }
                sorozat[i] = dobasok;
                if (sorozat[i].CompareTo("FFFI") == 0)
                {
                    FFFIDB++;
                }
            }
            for(int i=0;i<1000;i++)
            {
                sorozat[i] = FFFFdb;
            }
            
            
        }
        static void Kiir()
        {
            StreamWriter sw = new StreamWriter("dobasok.txt");
            sw.WriteLine("{0}",Sorozat[]);
            sw.Close();
        }
    }
}
