using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace rendrelamonnaie
{
    class Program
    {
        static void Main(string[] args)
        {   //Conversion UTF8 des caractères
            Console.OutputEncoding = Encoding.UTF8;
            
            //Déclaration du montant à payer, montant à saisir, montant à rendre
            decimal mtapayer;
            string mtsaisir;
            decimal mtarendre;
            while (true)
            {
                
                //Génération de nombre aléatoire entre [1 ; 200] d'un décimal en utilisant Nexdouble de 0;1 à 0 à 200 + 0.01
                decimal m = (decimal)(new Random().NextDouble() * 200 + 0.01);
                //Arrondi après 2 chiffres après la virgule
                mtapayer = Math.Round((decimal)m, 2);

                //Affiche de tiret pour l'esthétique du programme
                Console.WriteLine("|---------------------------------------------------------------|");
                Console.WriteLine("|---------------------------------------------------------------|");
                //Affiche le montant à régler qui est généré aléatoirement entre [1 ; 200]
                Console.WriteLine($"|Montant à régler : {mtapayer:C}");
                //Boucle tant que c'est vrai continue ou break/sort;
                while (true)
                {
                    //Saisie du montant au choix
                    Console.Write("|Saisir le montant réglé, saisir (0) pour quitter : ");
                    //Donne la possibilité de rentrer un montant du type choisi tel que String
                    mtsaisir = Console.ReadLine();
                    //Remplace le montant saisie par une virgule ou un point
                    mtsaisir = mtsaisir.Replace('.', ',');
                    //Type booléen si la valeur peut être convertie de string en décimal alors on déclare une nouvelle valeur qui est allouée à cette conversion
                    bool siConvertie = decimal.TryParse(mtsaisir, out decimal mtsaisirConvertie);

                    //Si la tentative de conversion est fausse alors affiche erreur + continue; et invite à recommencer dans la boucle de saisie
                    if (siConvertie == false)
                    {
                        Console.WriteLine($"|Valeur saisie incorrecte, veuillez recommencer !");
                        Console.WriteLine("|---------------------------------------------------------------|");
                        continue;
                    }
                    //Déclaration du montant à rendre en fonction montant décimal convertie - le montant imposé
                    mtarendre = mtsaisirConvertie - mtapayer;
                    decimal rien = 0;
                    //Compare le résultat obtenue entre montant à rendre et rien qui est = 0
                    int resultat = Decimal.Compare(mtarendre, rien);
                    
                    //Si le montant convertie est sup ou égal au montant à payer et le mt à rendre différent de 0 alors le mtarendre s'affiche
                    if (mtsaisirConvertie >= mtapayer && mtarendre != 0)
                    {
                        Console.WriteLine("|---------------------------------------------------------------|");
                        Console.WriteLine($"|Montant à rendre : {mtarendre:C}");
                        Console.WriteLine("|---------------------------------------------------------------|");
                    }
                    //Si le montant réglé = 0 le programme s'arrête
                    if (mtsaisirConvertie == 0)
                    {
                        return;
                    }
                    //Si le montant réglé est inférieur au montant à régler alors, recommencer jusqu'à ce que la valeur soit bonne + affiche que la valeur ne peut être inférieur
                    if (mtsaisirConvertie < mtapayer)
                    {
                        Console.WriteLine($"|Le montant réglé ne peut être inférieur à {mtapayer:C} !");
                        Console.WriteLine("|---------------------------------------------------------------|");
                        continue;
                    }
                    //Si le resultat = 0 entre le montant à rendre et rien alors, affiche qu'il n'y a rien à payer
                    if (resultat == 0)
                    {
                        Console.WriteLine("|---------------------------------------------------------------|");
                        Console.WriteLine("|Vous n'avez rien à payer !");
                    }

                    //Déclaration de chaques valeurs de billets et de pièces / Égal compteur de billets et de pièces!
                    int b20 = 0;
                    int b10 = 0;
                    int b5 = 0;

                    int p2 = 0;
                    int p1 = 0;

                    decimal p050 = 0;
                    decimal p020 = 0;
                    decimal p010 = 0;
                    decimal p005 = 0;
                    decimal p002 = 0;
                    decimal p001 = 0;

                    //Si le montant à rendre est < au montant réglé alors, il peut prélever un type de billet ou pièce sur le montant à rendre
                    if (mtarendre < mtsaisirConvertie)
                    {
                        //Si le resultat est différent de 0 alors, il affiche le détail de la monnaie à rendre
                        if (resultat != 0)
                        {
                            Console.WriteLine("|Détail de votre monnaie : ");
                        }
                        
                        //Tant que le montant à rendre est supérieur au type de billet/pièces 20,10,5/0.01, 0.02 etc... alors +1 au compteur et - le type de billets/ pièces au montant à rendre 
                        while (mtarendre >= 20)
                        {
                            b20++;
                            mtarendre = mtarendre - 20;
                        }
                        while (mtarendre >= 10)
                        {
                            b10++;
                            mtarendre = mtarendre - 10;
                        }
                        while (mtarendre >= 5)
                        {
                            b5++;
                            mtarendre = mtarendre - 5;
                        }
                        while (mtarendre >= 2)
                        {
                            p2++;
                            mtarendre = mtarendre - 2;
                        }
                        while (mtarendre >= 1)
                        {
                            p1++;
                            mtarendre = mtarendre - 1;
                        }
                        //Convertie en decimal pour les doubles
                        while (mtarendre >= (decimal)0.50)
                        {
                            p050++;
                            mtarendre = mtarendre - (decimal)0.50;
                        }
                        while (mtarendre >= (decimal)0.20)
                        {
                            p020++;
                            mtarendre = mtarendre - (decimal)0.20;
                        }
                        while (mtarendre >= (decimal)0.10)
                        {
                            p010++;
                            mtarendre = mtarendre - (decimal)0.10;
                        }
                        while (mtarendre >= (decimal)0.05)
                        {
                            p005++;
                            mtarendre = mtarendre - (decimal)0.05;
                        }
                        while (mtarendre >= (decimal)0.02)
                        {
                            p002++;
                            mtarendre = mtarendre - (decimal)0.02;
                        }
                        while (mtarendre >= (decimal)0.01)
                        {
                            p001++;
                            mtarendre = mtarendre - (decimal)0.01;
                        }
                        //Affiche le type de billets/ pièces  comptabilisés sur la console s'il est différent de 0, sinon il ne s'affiche pas
                        //Attention si l'affichage est dans un while alors les valeurs vont défiler en nb de billets/pièces de 20 en colonnes
                        
                        if (b20 != 0)
                        {
                            Console.WriteLine($"|{b20} Billet{'s'} de 20 euros");
                        }
                        if (b10 != 0)
                        {
                            Console.WriteLine($"|{b10} Billet{'s'} de 10 euros");
                        }
                        if (b5 != 0)
                        {
                            Console.WriteLine($"|{b5} Billet{'s'} de 5 euros");
                        }
                        if (p2 != 0)
                        {
                            Console.WriteLine($"|{p2} Pièce{'s'} de 2 euros");
                        }
                        if (p1 != 0)
                        {
                            Console.WriteLine($"|{p1} Pièce{'s'} de 1 euro");
                        }
                        if (p050 != 0)
                        {
                            Console.WriteLine($"|{p050} Pièce{'s'} de 50 centimes");
                        }
                        if (p020 != 0)
                        {
                            Console.WriteLine($"|{p020} Pièce{'s'} de 20 centimes");
                        }
                        if (p010 != 0)
                        {
                            Console.WriteLine($"|{p010} Pièce{'s'} de 10 centimes");
                        }
                        if (p005 != 0)
                        {
                            Console.WriteLine($"|{p005} Pièce{'s'} de 5 centimes");
                        }
                        if (p002 != 0)
                        {
                            Console.WriteLine($"|{p002} Pièce{'s'} de 2 centimes");
                        }
                        if (p001 != 0)
                        {
                            Console.WriteLine($"|{p001} Pièce{'s'} de 1 centime");
                        }
                        //Sort de la boucle si tout les if précédents sont bien exécutés donc si toutes les conditions sont respectées alors on peut reprendre la boucle principale qui relance tout en remettant à nouveau un montant à régler aléatoirement
                        break;
                    }//Grosse migraine, après l'effort le réconfort
                }
            }
        }
    }
}
