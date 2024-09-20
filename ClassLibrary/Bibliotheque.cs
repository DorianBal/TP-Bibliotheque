﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Bibliotheque
    {
        public List<Livre> livres { get; set; }
        public List<Utilisateur> utilisateurs { get; set; }

        public Bibliotheque(List<Livre> livres, List<Utilisateur> utilisateurs)
        {
            this.livres = livres;
            this.utilisateurs = utilisateurs;
        }

        public bool AjoutLivre(Livre livre)
        {
            if (!livres.Contains(livre))
            {
                livres.Add(livre);
                return true;
            }
            else
            {
                Console.WriteLine("Le livre existe déjà dans la bibliothèque.");
                return false;
            }
        }

        public bool SuppressionLivre(int idLivre)
        {
            foreach (Livre livre in livres)
            {
                if(livre.isbn == idLivre && !livre.estEmprunte)
                {
                    livres.Remove(livre);
                    return true;
                }
            }
            return false;
        }

        public bool AjoutUtilisateur(Utilisateur utilisateur)
        {
            if (!utilisateurs.Contains(utilisateur))
            {
                utilisateurs.Add(utilisateur);
                return true;
            }
            else
            {
                Console.WriteLine("L'utilisateur existe déjà.");
                return false;
            }
        }

        public bool SuppressionUtilisateur(int idUser)
        {
            foreach (Utilisateur user in utilisateurs)
            {
                if (user.id == idUser)
                {
                    utilisateurs.Remove(user);
                    return true;
                }
            }
            return false;
        }

        public int GetLastIsbnLivre()
        {
            int isbnMax = 1;
            foreach(Livre livre in livres)
            {
                if(livre.isbn > isbnMax)
                    isbnMax = livre.isbn;
            }
            return isbnMax + 1;
        }

        public int GetLastIdUser()
        {
            int idMax = 1;
            foreach (Utilisateur user in utilisateurs)
            {
                if (user.id > idMax)
                    idMax = user.id;
            }
            return idMax + 1;
        }

        public bool AjoutLivreUtilisateur(int idLivre, int idUser)
        {
            foreach (Livre livre in livres)
            {
                if(livre.isbn == idLivre)
                {
                    livre.estEmprunte = true;

                    foreach (Utilisateur user in utilisateurs)
                    {
                        if(idUser == user.id)
                        {
                            user.AjoutLivreEmprunte(livre);
                        }
                    }

                    livres.Remove(livre);
                    return true;
                }
            }
            return false;
        }

        public bool RetournerLivreUtilisateur(int idLivre, int idUser)
        {
            foreach (Livre livre in livres)
            {
                Console.WriteLine("ici");

                Console.WriteLine();

                if (livre.isbn == idLivre)
                {
                    Console.WriteLine("la");
                    //livre.estEmprunte = false;
                    //livres.Add(livre);

                    foreach (Utilisateur user in utilisateurs)
                    {
                        Console.WriteLine("oco");
                        if (idUser == user.id)
                        {
                            Console.WriteLine("test");
                            user.SuppressionLivreEmprunte(livre);
                            Console.WriteLine("pas là");
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}
