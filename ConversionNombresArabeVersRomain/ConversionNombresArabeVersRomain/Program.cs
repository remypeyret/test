using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConversionNombresArabeVersRomain
{
    class Program
    {
        const string msgUtilisation = "Veuillez saisir un nombre entier positif...\n";
        static void Main(string[] args)
        {
            // fonctionnement en boucle infinie : la fonction demande un nombre, le converti et en demande un autre
            GererSaisie();
        }

        static void GererSaisie()
        {
            Console.Write(msgUtilisation);
            string nbConsole = Console.ReadLine();
            int nbSaisi = 0;

            if (!(int.TryParse(nbConsole, out nbSaisi)))
            {
                // la saisie est invalide, on demande un nouveau nombre
                GererSaisie();
            }
            else
            {
                string s = ConvertirNombreEnRomain(nbSaisi);
                Console.Write(s + "\n");
                // on demande un nouveau nombre
                GererSaisie();
            }
        }

        static string ConvertirNombreEnRomain(int nb)
        {
            string nombreRomain = ""; // chaine qui sera renvoyée - vide si nombre négatif
            const int nbSymboles = 7;
            string[] symbolesRomains = new String[nbSymboles]; // tableau des symboles roamins
            int[] nombres = new int[nbSymboles]; // tabeau des nombres corresponant aux symboles romains !les indices doivent correspondre
            // initialisation des tableaux
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
                                   
            
            int valeur = nb;
            bool test = valeur > 0;
            // boucle tant que la valeur est supérieure à 0         
            while (test)
            {
                // pour chaque nombre correspondant à un symbole romain, du plus grand au plus petit,
                for (int ii = nbSymboles - 1; ii >= 0; ii--)
                {
                    //  tant que la valeur est supérieure à ce nombre, le nombre est enlevé de la valeur et le symbole est ajouté dans la chaine de sortie
                    while (valeur >= nombres[ii])
                    {
                        nombreRomain += symbolesRomains[ii];
                        valeur -= nombres[ii];
                    }
                    // Gestion du 9
                    // si l'indice est supérieur à un et si la valeur est supérieure au nombre en cours moins le second plus petit (ex X et I)
                    // le nombre en cours est enlevé de la valeur et l'autre est ajouté; les symboles - plus petit puis plus grand - sont ajoutés dans la chaine de sortie
                    if (ii > 1)
                    {
                        if (valeur >= nombres[ii] - nombres[ii - 2])
                        {
                            nombreRomain += symbolesRomains[ii - 2] + symbolesRomains[ii];
                            valeur -= nombres[ii] - nombres[ii - 2];
                        }
                    }
                    // Gestion du 4
                    // si l'indice est supérieur à un et si la valeur est supérieure au nombre en cours moins le suivant plus petit (ex V et I)
                    // le nombre en cours est enlevé de la valeur et l'autre est ajouté; les symboles - plus petit puis plus grand - sont ajoutés dans la chaine de sortie
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
