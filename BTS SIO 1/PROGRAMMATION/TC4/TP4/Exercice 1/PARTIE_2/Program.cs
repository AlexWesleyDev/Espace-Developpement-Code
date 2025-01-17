using System;
using System.Collections.Generic;

namespace TP4{
    internal class Program{
        static List<string> listeCourses = new List<string> { "pomme","sucre en poudre", "baguette", "tomate" };
        static string Rep, aliment;

        //###################""""""""""""""" PARTIE II """"""""""""""""#########################//
        
        // 1 - Quelle solution proposez-vous pour la quantité ?
        // Créer une liste d'entiers nommée "Quantite" qui contiendra les quantités de chaque aliment existant dans la liste de courses actuelle,
        // en fonction de l'indice de position dans les 2 tabeaux avant de demander ensuite la saisie de ces quantités à l'utilisateur.
        static List<int> Quantite = new List<int>();
        static string inputQté; static int qté;

        static void SaisieQté()
        {
                Console.WriteLine("Saisir les quantités voulues pour chaque aliment de la liste :");
                for(int i=0;i<listeCourses.Count;i++){
                        Console.Write("- " + listeCourses[i] + " : ");
                        inputQté=Console.ReadLine();
                        TestSaisieQté();
                        Quantite.Add(qté);
                }
        }
        // # Gestion de la bonne saisie d'une quantité.
        static void TestSaisieQté(){
                while(string.IsNullOrEmpty(inputQté) || !int.TryParse(inputQté, out qté) || qté<0){
                        Console.Write("Erreur de saisie, quantité positif non vide, recommencer : ");
                        inputQté=Console.ReadLine();
                }}

        // 2 - Affichage de la liste avec pour chaque élément la quantité voulue.
        static void AffichageSimple()
        {
            Console.WriteLine("Liste de mes courses :");
            for(int i=1;i<=listeCourses.Count;i++){
                Console.WriteLine(i+" - "+listeCourses[i-1]);
            }
        }

        static void AfficheQté()
        {
                Console.WriteLine("Liste de mes courses :");
                for(int i=1;i<=listeCourses.Count;i++){
                        Console.WriteLine(i+" - "+listeCourses[i-1]+" : "+Quantite[i-1]);
                }
        }

        // 3- Modifier l’ajout d’un élément de la liste avec la quantité associée.
        static void AjoutAliment()
        {
                Console.Write("Souhaitez-vous ajouter un autre aliment o/n: "); Rep=Console.ReadLine();
                SaisieRepCorrecte();
                if(Rep=="o")
                {
                        // - Gestion de la bonne saisie de l'aliment.
                        do{
                                Console.Write("Saisir un aliment : ");  aliment=Console.ReadLine();
                        }while(string.IsNullOrEmpty(aliment));

                        // - Test de présence et ajout de l'aliment s'il est absent de la liste
                        //   ou +1 sur la quantité s'il est présent.
                        if(listeCourses.Contains(aliment))
                        {
                                Console.WriteLine("L'aliment " + aliment +" est présent dans la liste.");
                                for(int i=0;i<listeCourses.Count;i++){
                                        if(listeCourses[i]==aliment){
                                                Quantite[i]+=1;
                                        }
                                }
                        }
                        else{
                                Console.WriteLine("L'aliment " + aliment +" n'est pas présent dans la liste.");
                                Console.Write("Saisir la quantité : "); inputQté=Console.ReadLine();
                                TestSaisieQté(); Quantite.Add(qté); listeCourses.Add(aliment);
                        }
                }
        }

        // 4 - Gestion de la suppression d'aliment de l'aliment.
        static void SuppAliment()
        {
                Console.Write("Voulez vous retirer un aliment de la liste o/n: ");
                Rep=Console.ReadLine();  SaisieRepCorrecte();
                if(Rep=="o"){
                        // - Bonne saisie de l'aliment non vide qui est à retirer.
                        do{
                                Console.Write("Saisir l'aliment à retirer : "); aliment=Console.ReadLine();
                        }while(string.IsNullOrEmpty(aliment));

                        // - Test de présence et suppression de l'aliment dans la liste.
                        if(listeCourses.Contains(aliment)){
                                for(int i=0;i<listeCourses.Count;i++){
                                        if(listeCourses[i]==aliment){listeCourses.RemoveAt(i);}
                                }
                        }
                        else{Console.WriteLine("Aliment à retirer non présent dans la liste !");}
                }
        }

        // # Gestion de la bonne saisie d'une réponse attendue conforme.
        static void SaisieRepCorrecte(){
            while(string.IsNullOrEmpty(Rep) || (Rep!="o" && Rep!="n")){
                Console.Write("Erreur de saisie, répondez par o/n : ");
                Rep=Console.ReadLine();}
        }

        static void Main(string[] args){
                AffichageSimple(); // #-2
                SaisieQté(); // #-1
                AfficheQté();// #-2
                AjoutAliment(); // #-3
                AfficheQté(); // Affichage après chaque action.
        }
    }
}