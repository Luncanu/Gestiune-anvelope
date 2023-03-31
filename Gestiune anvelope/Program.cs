using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestiune_anvelope
{
    class Program
    {
        public static List<Anvelopa> toateAnvelopele = new List<Anvelopa>();
        static void Main()
        {


            Readfromfile(toateAnvelopele);
            Boolean showMenu_ = true;
            while (showMenu_)
            {
                showMenu_ = showMenu();
            }


        }

        public static Boolean showMenu()
        {
            Console.WriteLine("--==MENIU GESTIUNE DEPOZIT ANVELOPE==--");
            Console.WriteLine("1. Afiseaza taote anvelopele");
            Console.WriteLine("2. Adauga anvelopa");
            Console.WriteLine("3. Modifica anvelopa");
            Console.WriteLine("4. Sterge anvelopa");
            Console.WriteLine("5. Cauta anvelopa");
            Console.WriteLine("0.EXIT");
            Console.WriteLine("Alegeti o optiune din meniu: ");


            switch (Console.ReadLine())
            {
                case "0":
                    
                    return false;
                case "1":

                    foreach (Anvelopa anv in toateAnvelopele)
                    {

                        Console.WriteLine(anv.ToString());
                    }
                    return true;

                case "2":
                    Console.WriteLine("Introduceti producatorul");
                    string producator = Console.ReadLine();
                    Console.WriteLine("Introduceti tipul anvelopei (iarna/vara)");
                    string tip = Console.ReadLine();
                    Console.WriteLine("Introduceti latime");
                    int latime = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti inaltime");
                    int inaltime = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti raza ( ex :R16,R18)");
                    string raza = Console.ReadLine();
                    Console.WriteLine("Introduceti nr bucati");
                    int nrBucati = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti pret");
                    float pret = float.Parse(Console.ReadLine());

                    Anvelopa anvelopaNoua = new Anvelopa(producator, tip, latime, inaltime, raza, nrBucati, pret);
                    toateAnvelopele.Add(anvelopaNoua);
                    Writetofile();

                    return true;
                case "3":
                    return true;
                case "4":
                    return true;
                case "5":

                    Console.WriteLine("Introduceti producatorul ( introduceti * daca nu doriti filtrare dupa producator)");
                    string producatorPentruCautare = Console.ReadLine();
                    Console.WriteLine("Introduceti tipul anvelopei (iarna/vara) ( introduceti * daca nu doriti filtrare dupa tip)");
                    string tipPentruCautare = Console.ReadLine();
                    Console.WriteLine("Introduceti latime ( introduceti 0 daca nu doriti filtrare dupa latime)");
                    int latimePentruCautare = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti inaltime ( introduceti 0 daca nu doriti filtrare dupa inaltime)");
                    int inaltimePentruCautare = int.Parse(Console.ReadLine());
                    Console.WriteLine("Introduceti raza ( ex :R16,R18) ( introduceti * daca nu doriti filtrare dupa raza)");
                    string razaPentruCautare = Console.ReadLine();
                    cautaAnvelopa(producatorPentruCautare, tipPentruCautare, inaltimePentruCautare, latimePentruCautare, razaPentruCautare);
                    return true;

                default:
                    Console.WriteLine("Optiune incorecta!!!Alegeti o optiune din meniu: ");
                    return true;
            }

        }
        static void cautaAnvelopa(string producator, string tip, int latime, int inaltime, string raza)
        {
            Boolean gasit = false;
            foreach (Anvelopa anvelopa in toateAnvelopele)
            {
                if ("*".Equals(producator) || anvelopa.Producator.Equals(producator))
                {
                    if ("*".Equals(tip) || anvelopa.Tip.Equals(tip))
                    {
                        if (0 == latime || anvelopa.Latime == (latime))
                        {
                            if (0 == inaltime || anvelopa.Inaltime == (inaltime))
                            {
                                if ("*".Equals(raza) || anvelopa.Raza.Equals(raza))
                                {
                                    Console.WriteLine(anvelopa.ToString());
                                    gasit = true;
                                }
                            }
                        }
                    }
                }
               

            }
            if (!gasit)
            {
                Console.WriteLine("Nu a fost gasit nici o anvelopa dupa criteriile introduse!!");
            }
        }
        static void adaugaAnvelopa(Anvelopa anvelopaDeAdaugat)
        {

        }
        static void Readfromfile(List<Anvelopa> toateAnvelopele)
        {
            string line;
            try
            {

                StreamReader sr = new StreamReader("C:\\Users\\Axellu\\source\\repos\\Gestiune anvelope\\gestiune.txt");

                line = sr.ReadLine();

                while (line != null)
                {


                    string[] result = line.Split(',');
                    toateAnvelopele.Add(new Anvelopa(result[0], result[1], int.Parse(result[2]), int.Parse(result[3]), result[4], int.Parse(result[5]), float.Parse(result[6])));

                    line = sr.ReadLine();
                }

                sr.Close();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);

                return;
            }

        }
        static void Writetofile()
        {
            try
            {

                StreamWriter sw = new StreamWriter("C:\\Users\\Axellu\\source\\repos\\Gestiune anvelope\\gestiune.txt");

                foreach (Anvelopa anv in toateAnvelopele)
                {
                    sw.WriteLine(anv.ToFile());
                }


                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                return;
            }

        }
    }
}
    

        

