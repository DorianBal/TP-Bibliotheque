namespace ClassLibrary
{
    public class Livre
    {
        public string titre { get; set; }
        public string auteur { get; set; }
        public int anneePublication { get; set; }
        public int isbn { get; set; }
        public bool estEmprunte { get; set; }

        public Livre(string titre, string auteur, int anneePublication, int isbn, bool estEmprunte)
        {
            this.titre = titre;
            this.auteur = auteur;
            this.anneePublication = anneePublication;
            this.isbn = isbn;
            this.estEmprunte = estEmprunte;
        }
    }
}
