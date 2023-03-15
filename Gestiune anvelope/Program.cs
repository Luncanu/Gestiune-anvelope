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
           
            //initializare lista cu taote anvelopele din fisier
            Readfromfile(toateAnvelopele);
            Boolean showMenu_ = true;
            while(showMenu_)
            {
                showMenu_ = showMenu();
            }
            
            // Writetofile();
        }

        public static Boolean showMenu()
        {
            Console.WriteLine("--==MENIU GESTIUNE DEPOZIT ANVELOPE==--");
            Console.WriteLine("1. Afiseaza taote anvelopele");
            Console.WriteLine("2. Adauga anvelopa");
            Console.WriteLine("3. Modifica anvelopa");
            Console.WriteLine("4. Sterge anvelopa");
            Console.WriteLine("Alegeti o optiune din meniu: ");
            
            
                switch (Console.ReadLine())
                {
                    case "1":

                        foreach (Anvelopa anv in toateAnvelopele)
                        {
                            //afiseaza taote anvelopele din fisier dupa ce au fost convertite in obiecte
                            Console.WriteLine(anv.ToString());
                        }
                        return  true;
                        
                    case "2":
                    Console.WriteLine("Introduceti producatorul");
                    string producator=Console.ReadLine();
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
                default:
                        Console.WriteLine("Optiune incorecta!!!Alegeti o optiune din meniu: ");
                    return true;
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
                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("C:\\Users\\Axellu\\source\\repos\\Gestiune anvelope\\gestiune.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    
                  //convert line from file to objerct Anvelopa
                  string[] result=  line.Split(',');
                    toateAnvelopele.Add(new Anvelopa(result[0], result[1],int.Parse( result[2]),int.Parse( result[3]), result[4],int.Parse( result[5]),float.Parse( result[6])));
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();
                
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        static void Writetofile()
        {
            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw =new StreamWriter("C:\\Users\\Axellu\\source\\repos\\Gestiune anvelope\\gestiune.txt");
                //Write a line of text
                foreach (Anvelopa anv in toateAnvelopele)
                {
                    sw.WriteLine(anv.ToFile());
                }
                
                //Close the file
                sw.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }
        }
}
