using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReiterSzorzotabla
{
    class Program
    {
        static void Main(string[] args)
        {
            //Futtasd paraméterrel: \Program.exe X - ahol X a szám, ahányas szorzótáblát akarsz kiíratni!

            int number;

            //Ha paraméter nélkül futtatjuk, random szám szorzótábláját írja ki
            if (args.Length == 0)
            {
                Random r = new Random();
                number = r.Next(10);
            }
            //Ha paraméterrel, a paraméter szorzótábláját
            else
            {
                number = int.Parse(args[0]);
            }

            for(int i=1; i<=10; ++i)
            {
                Console.WriteLine("{0} x {1} = {2}", i, number, i * number);
            }

            Console.ReadKey();
        }
    }
}