using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionNombresArabeVersRomain
{
    class Program
    {
        const string msgUtilisation = "Veuillez saisir un nombre...\n";
        static void Main(string[] args)
        {
            GererSaisie();
        }

        static void GererSaisie()
        {
            Console.Write(msgUtilisation);
            string nbConsole = Console.ReadLine();
            int nbSaisi = 0;

            if (!(int.TryParse(nbConsole, out nbSaisi)))
            {
                GererSaisie();
            }
            else
            {
                string s = ConvertirNombreEnRomain(nbSaisi);
                Console.Write(s + "\n");
                GererSaisie();
            }
        }

        static string ConvertirNombreEnRomain(int nb)
        {
            string nombreRomain = "";
            const int nbSymboles = 7;
            string[] symbolesRomains = new String[nbSymboles];
            int[] nombres = new int[nbSymboles];
            symbolesRomains[0] = "I";
            symbolesRomains[1] = "V";
            symbolesRomains[2] = "X";
            symbolesRomains[3] = "L";
            symbolesRomains[4] = "C";
            symbolesRomains[5] = "D";
            symbolesRomains[6] = "M";
            nombres[0] = 1;
            nombres[1] = 5;
            nombres[2] = 10;
            nombres[3] = 50;
            nombres[4] = 100;
            nombres[5] = 500;
            nombres[6] = 1000;
            bool test = nb > 0;
            int valeur = nb;
            while (test)
            {
                for (int ii = nbSymboles - 1; ii >= 0; ii--)
                {
                    while (valeur >= nombres[ii])
                    {
                        nombreRomain += symbolesRomains[ii];
                        valeur -= nombres[ii];
                    }
                    if (ii > 1)
                    {
                        if (valeur >= nombres[ii] - nombres[ii - 2])
                        {
                            nombreRomain += symbolesRomains[ii - 2] + symbolesRomains[ii];
                            valeur -= nombres[ii] - nombres[ii - 2];
                        }
                    }
                    if (ii > 0)
                    {
                        if ((valeur >= nombres[ii] - nombres[ii - 1]) && (nombres[ii] - nombres[ii - 1] != nombres[ii - 1]))
                        {
                            nombreRomain += symbolesRomains[ii - 1] + symbolesRomains[ii];
                            valeur -= nombres[ii] - nombres[ii - 1];
                        }
                    }
                }
                test = valeur > 0;
            }
            return nombreRomain;
        }
    }
}
