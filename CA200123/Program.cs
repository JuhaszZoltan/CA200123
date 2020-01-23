using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CA200123
{
    struct Kerdes
    {
        public string Feladvany;
        public string[] Valaszlehetosegek;
        public int MegoldasIndex;
    }

    class Program
    {
        static List<Kerdes> teszt;
        static int pontszam;
        static void Main()
        {
            FeladatKiiras();
            Beolvas();
            Teszt();
            Console.ReadKey();
        }

        private static void Teszt()
        {
            foreach (var k in teszt)
            {
                Console.Clear();
                Console.WriteLine(k.Feladvany);

                foreach (var v in k.Valaszlehetosegek)
                {
                    Console.WriteLine($"\t{v}");
                }

                Console.Write($"\nAdja meg a helyes válasz betűjelét: ");
                var betu = Console.ReadLine().ToUpper();

                if(MgInGen(betu) == k.MegoldasIndex)
                {
                    Console.WriteLine("\n\tJó válasz!");
                    pontszam++;
                }
                else Console.WriteLine("\n\tHibás válasz :(");
                Thread.Sleep(3000);
            }

            Console.WriteLine($"eredmény: {pontszam}/{teszt.Count} pont");
        }

        private static void Beolvas()
        {
            teszt = new List<Kerdes>();
            pontszam = 0;
            var srk = new StreamReader(@"..\..\res\teszt.txt", Encoding.UTF8);
            var srm = new StreamReader(@"..\..\res\megoldas.txt", Encoding.UTF8);
            while (!srk.EndOfStream)
            {
                teszt.Add(new Kerdes()
                {
                    Feladvany = srk.ReadLine(),
                    Valaszlehetosegek = new string[]
                    {
                        srk.ReadLine(),
                        srk.ReadLine(),
                        srk.ReadLine(),
                    },
                    MegoldasIndex = MgInGen(srm.ReadLine()),
                });
            }
            srk.Close();
            srm.Close();
        }
        private static int MgInGen(string betu)
        {
            switch(betu)
            {
                case "A": return 0;
                case "B": return 1;
                case "C": return 2;
                default: return -1;
            }
        }
        private static void FeladatKiiras()
        {
            Console.CursorVisible = false;
            var sr = new StreamReader(@"..\..\res\feladat.txt", Encoding.UTF8);
            Console.WriteLine(sr.ReadLine());
            sr.Close();
            Console.WriteLine("\n\nKezdéshez nyomja meg az ENTERT!");
            while (Console.ReadKey().Key != ConsoleKey.Enter)
                Console.Write("\b \b");
            Console.Clear();
        }
    }
}
