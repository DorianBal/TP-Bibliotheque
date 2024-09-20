using System.Collections.Generic;
using ClassLibrary;

List<Livre> livres = new List<Livre>
{
    new Livre("Les Misérables", "Victor Hugo", 1862, 1, false),
    new Livre("L'Alchimiste", "Paulo Coelho", 1988, 2, false),
    new Livre("Le Petit Prince", "Antoine de Saint-Exupéry", 1943, 3, false),
    new Livre("1984", "George Orwell", 1949, 4, false),
    new Livre("Crime et Châtiment", "Fiodor Dostoïevski", 1866, 5, false),
    new Livre("L'Étranger", "Albert Camus", 1942, 6, false),
    new Livre("Le Comte de Monte-Cristo", "Alexandre Dumas", 1844, 7, false),
    new Livre("La Peste", "Albert Camus", 1947, 8, false),
    new Livre("Germinal", "Émile Zola", 1885, 9, false),
    new Livre("Don Quichotte", "Miguel de Cervantes", 1605, 10, false),
    new Livre("Moby Dick", "Herman Melville", 1851, 11, false),
    new Livre("Madame Bovary", "Gustave Flaubert", 1857, 12, false),
    new Livre("Les Fleurs du mal", "Charles Baudelaire", 1857, 13, false),
    new Livre("Anna Karénine", "Léon Tolstoï", 1877, 14, false),
    new Livre("L'Odyssée", "Homère", -800, 15, false),
    new Livre("Le Seigneur des Anneaux", "J.R.R. Tolkien", 1954, 16, false),
    new Livre("Harry Potter à l'école des sorciers", "J.K. Rowling", 1997, 17, false),
    new Livre("Le Rouge et le Noir", "Stendhal", 1830, 18, false),
    new Livre("Bel-Ami", "Guy de Maupassant", 1885, 19, false),
    new Livre("L'Iliade", "Homère", -750, 20, false),
};

List<Utilisateur> utilisateurs = new List<Utilisateur>
{
    new Utilisateur("bob", "marley", 1, false, new List<Livre>()),
    new Utilisateur("john", "lenon", 2, false, new List<Livre>()),
    new Utilisateur("elvis", "presley", 3, true, new List<Livre>())
};

Bibliotheque biblio = new Bibliotheque(livres, utilisateurs);

bool continuer = true;

while (continuer)
{
    //Console.Clear();
    Console.WriteLine("Bienvenue à la bibliothèque, veuillez choisir une option");
    Console.WriteLine("1 : Voir tous les livres");
    Console.WriteLine("2 : Voir tous les utilisateurs");
    Console.WriteLine("3 : Voir les emprunts");
    Console.WriteLine("4 : Quitter\n");

    string choix = Console.ReadLine();
    Console.WriteLine("");

    switch (choix)
    {
        // -------------------- Visualisation des livres --------------------

        case "1":
            //Console.Clear();
            Console.WriteLine("Livres :");
            foreach (Livre livre in biblio.livres)
            {
                Console.Write(livre.isbn + " - " + livre.titre + ", par " + livre.auteur + ", publié en " + livre.anneePublication + ", ");
                Console.WriteLine(livre.estEmprunte ? "Emprunté" : "Disponible");
            }

            Console.WriteLine("\nVeuillez choisir une option");
            Console.WriteLine("1 : Ajouter un livre");
            Console.WriteLine("2 : Supprimer un livre");
            Console.WriteLine("3 : Retour\n");

            choix = Console.ReadLine();
            Console.WriteLine("");

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Veuillez entrer les informations du livre, comme dans l'exemple : ");
                    Console.WriteLine("titre, auteur, 2023");
                    string livreDetails = Console.ReadLine();

                    string[] detailsLivre = livreDetails.Split(',');

                    string titre = detailsLivre[0].Trim();
                    string auteur = detailsLivre[1].Trim();
                    int annee = Int32.Parse(detailsLivre[2].Trim());

                    Livre livreAAjouter = new Livre(titre, auteur, annee, biblio.GetLastIsbnLivre(), false);

                    if (biblio.AjoutLivre(livreAAjouter))
                        Console.WriteLine("Livre ajouté !");
                    else
                        Console.WriteLine("Erreur");

                    break;

                case "2":
                    Console.WriteLine("Veuillez entrer l'id du livre à supprimer: \n");
                    int livreASupprimer = Int32.Parse(Console.ReadLine());

                    if (biblio.SuppressionLivre(livreASupprimer))
                        Console.WriteLine("Livre supprimé !");
                    else
                        Console.WriteLine("Erreur");

                    break;
                case "3":
                    break;
                default:
                    break;
            }
            break;

        // -------------------- Visualisation des utilisateurs --------------------

        case "2":
            //Console.Clear();
            Console.WriteLine("Utilisateurs :");
            foreach (Utilisateur utilisateur in biblio.utilisateurs)
            {
                Console.Write(utilisateur.id + " - " + utilisateur.prenom + " " + utilisateur.nom + ", ");
                if (utilisateur.prenium)
                    Console.Write("Prenium");
                else
                    Console.Write("Non-Prenium");
                Console.WriteLine();
            }

            Console.WriteLine("\nVeuillez choisir une option");
            Console.WriteLine("1 : Ajouter un utilisateur");
            Console.WriteLine("2 : Supprimer un utilisateur");
            Console.WriteLine("3 : Retour\n");

            choix = Console.ReadLine();
            Console.WriteLine("");


            switch (choix)
            {
                case "1":
                    Console.WriteLine("Veuillez entrer les informations de l'utilisateur, comme dans l'exemple : (avec false = est pas prenium, true = est prenium)");
                    Console.WriteLine("nom, prenom, false");
                    string utilisateurDetails = Console.ReadLine();

                    string[] detailsUtilisateur = utilisateurDetails.Split(',');

                    string nom = detailsUtilisateur[0].Trim();
                    string prenom = detailsUtilisateur[1].Trim();
                    bool estPrenium = bool.Parse(detailsUtilisateur[2].Trim());

                    Utilisateur utilisateurAAjouter = new Utilisateur(nom, prenom, biblio.GetLastIdUser(), estPrenium, new List<Livre>());

                    if (biblio.AjoutUtilisateur(utilisateurAAjouter))
                        Console.WriteLine("Utilisateur ajouté !");
                    else
                        Console.WriteLine("Erreur");

                    break;

                case "2":
                    Console.WriteLine("Veuillez entrer l'id de l'utilisateur à supprimer: \n");
                    int utilisateurASupprimer = Int32.Parse(Console.ReadLine());

                    if (biblio.SuppressionUtilisateur(utilisateurASupprimer))
                        Console.WriteLine("Utilisateur supprimé !");
                    else
                        Console.WriteLine("Erreur");

                    break;
                case "3":
                    break;
                default:
                    break;
            }
            break;




        // -------------------- Visualisation des emprunts --------------------

        case "3":
            //Un utilisateur peut emprunter un ou plusieurs livres,
            //et chaque emprunt est limité à 3 livres par utilisateur.
            //Sauf pour le client premium qui peut emprunter jusqu'à 5 livres.

            //On doit pouvoir emprunter un livre,
            //retourner un livre, et
            //lister les emprunts en cours.

            //Console.Clear();
            Console.WriteLine("Emprunts :");
            foreach (Utilisateur utilisateur in biblio.utilisateurs)
            {
                if (utilisateur.livresEmpruntes.Count > 0)
                {
                    Console.Write(utilisateur.nom + " " +  utilisateur.prenom + " (" + utilisateur.id + ") - ");
                
                    foreach (Livre livreEmpruntee in utilisateur.livresEmpruntes)
                    {
                        Console.WriteLine(livreEmpruntee.titre + " (" + livreEmpruntee.isbn + ")");
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine("\nVeuillez choisir une option");
            Console.WriteLine("1 : Emprunter un livre");
            Console.WriteLine("2 : Retourner un livre");
            Console.WriteLine("3 : Retour\n");

            choix = Console.ReadLine();
            Console.WriteLine("");


            switch (choix)
            {
                case "1":
                    Console.WriteLine("Veuillez entrer l'id de l'utilisateur, et l'id du livre à emprunter, comme avec l'exemple :");
                    Console.WriteLine("2, 15");
                    string utilisateurDetails = Console.ReadLine();

                    string[] detailsUtilisateur = utilisateurDetails.Split(',');

                    int idUser = Int32.Parse(detailsUtilisateur[0].Trim());
                    int idLivre = Int32.Parse(detailsUtilisateur[1].Trim());

                    if (biblio.AjoutLivreUtilisateur(idLivre, idUser))
                        Console.WriteLine("Livre emprunté !");
                    else
                        Console.WriteLine("Erreur");

                    break;


                case "2":
                    Console.WriteLine("Veuillez entrer l'id de l'utilisateur, et l'id du livre à retourner, comme avec l'exemple :");
                    Console.WriteLine("2, 15");
                    string utilisateurDetails2 = Console.ReadLine();

                    string[] detailsUtilisateur2 = utilisateurDetails2.Split(',');

                    int idUser2 = Int32.Parse(detailsUtilisateur2[0].Trim());
                    int idLivre2 = Int32.Parse(detailsUtilisateur2[1].Trim());

                    if (biblio.RetournerLivreUtilisateur(idLivre2, idUser2))
                        Console.WriteLine("Livre retourné !");
                    else
                        Console.WriteLine("Erreur");

                    break;


                case "3":
                    break;
                default:
                    break;
            }
            break;

        case "4":
            continuer = false;
            break;

        default:
            Console.WriteLine("Option invalide. Veuillez réessayer.");
            break;
    }

    Console.WriteLine(); // Ajout d'une ligne vide pour espacer les menus
}
