using System;

namespace Denombrements
{
    /// <summary>
    /// Classe principale du programme de dénombrements.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Méthode pour afficher le menu du programme et demander le choix de l'utilisateur en controlant la saisie.
        /// </summary>
        /// <returns>Le choix de l'utilisateur.</returns>
        static int AfficherMenu()
        {
            // initialisation des variables
            int choix;

            // boucle pour afficher le menu et demander le choix de l'utilisateur jusqu'à ce qu'il saisisse un choix valide
            do
            {
                Console.WriteLine("Permutation ...................... 1");
                Console.WriteLine("Arrangement ...................... 2");
                Console.WriteLine("Combinaison ...................... 3");
                Console.WriteLine("Quitter .......................... 0");
                Console.Write("Choix :                            ");

                if (!int.TryParse(Console.ReadLine(), out choix))
                {
                    Console.WriteLine("Saisissez un nombre entier (entre 0 et 3).");
                    choix = -1; // pour forcer la boucle à continuer
                }

                else if (choix < 0 || choix > 3)
                {
                    Console.WriteLine("Saisissez un nombre entier (entre 0 et 3).");
                }

            } while (choix < 0 || choix > 3);

            return choix;
        }

        /// <summary>
        /// Demande le nombre total d'éléments et le nombre d'éléments du sous-ensemble avec vérification de saisie.
        /// </summary>
        /// <param name="nbElements">Nombre total d'éléments.</param>
        /// <param name="nb">Nombre d'éléments du sous-ensemble.</param>
        static void DemandeElements(out int nbElements, out int nb)
        {
            // saisie des variables avec vérification
            Console.Write("Nombre total d'éléments à gérer = ");

            while (!int.TryParse(Console.ReadLine(), out nbElements) || nbElements < 0)
            {
                Console.WriteLine("Saisissez un entier positif.");
                Console.Write("Nombre total d'éléments à gérer = ");
            }

            do
            {

                Console.Write("Nombre d'éléments dans le sous ensemble (le nombre doit être inférieur ou égal au nombre total d'éléments) = ");

                while (!int.TryParse(Console.ReadLine(), out nb) || nb < 0)
                {
                    Console.WriteLine("Saisissez un entier positif.");
                    Console.Write("Nombre d'éléments dans le sous ensemble (le nombre doit être inférieur ou égal au nombre total d'éléments) = ");
                }
                if (nb > nbElements)
                {
                    Console.WriteLine("Le nombre d'éléments dans le sous ensemble doit être inférieur ou égal au nombre total d'éléments.");
                }
            } while (nb > nbElements);

        }

        ///<summary>
        /// Point d'entrée du programme. 
        /// </summary>
        /// <param name="args">Arguments de la ligne de commande.</param>
        static void Main(string[] args)
        {
            int choix;

            do
            {
                choix = AfficherMenu();

                switch (choix)
                {
                    case 1:
                        {
                            int nb;
                                // demande du nombre d'éléments à gérer
                                Console.Write("nombre total d'éléments à gérer = ");

                                while (!int.TryParse(Console.ReadLine(), out nb) || nb < 0)
                                {
                                    Console.WriteLine("Saisissez un entier positif.");
                                    Console.Write("Nombre total d'éléments à gérer = ");
                                }

                            // calcul de r
                            long r = 1;
                            for (int k = 1; k <= nb; k++)
                            {
                                r *= k;
                            }
                            Console.WriteLine(nb + "! = " + r);
                            break;

                        }

                    case 2:
                        {
                            // lancement de la fonction pour demander les variables
                            DemandeElements(out int nbElements, out int nb);

                            // calcul de r
                            long r = 1;
                            for (int k = (nbElements - nb + 1); k <= nbElements; k++)
                            {
                                r *= k;
                            }
                            Console.WriteLine("A(" + nbElements + "/" + nb + ") = " + r);
                            break;
                        }
                    case 3:
                        {
                            DemandeElements(out int nbElements, out int nb);
                            long r1 = 1;
                            for (int k = (nbElements - nb + 1); k <= nbElements; k++)
                            {
                                r1 *= k;
                            }
                            long r2 = 1;
                            for (int k = 1; k <= nb; k++)
                            {
                                r2 *= k;
                            }
                            Console.WriteLine("C(" + nbElements + "/" + nb + ") = " + (r1 / r2));
                            break;
                        }
                    case 0:
                        {
                            break;
                        }
                }
            } while (choix != 0);
            Console.ReadLine();
        }
    }
}
