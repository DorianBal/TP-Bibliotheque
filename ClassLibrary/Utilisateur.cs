using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Utilisateur
    {
        public string nom { get; set; }
        public string prenom { get; set; }
        public int id { get; set; }
        public bool prenium { get; set; }
        public List<Livre> livresEmpruntes { get; set; }

        public Utilisateur(string nom, string prenom, int id, bool prenium, List<Livre> livresEmpruntes)
        {
            this.nom = nom;
            this.prenom = prenom;
            this.id = id;
            this.prenium = prenium;
            this.livresEmpruntes = livresEmpruntes;
        }

        public void AjoutLivreEmprunte(Livre livre)
        {
            livresEmpruntes.Add(livre);
        }

        public void SuppressionLivreEmprunte(Livre livre)
        {
            livresEmpruntes.Remove(livre);
        }
    }
}
