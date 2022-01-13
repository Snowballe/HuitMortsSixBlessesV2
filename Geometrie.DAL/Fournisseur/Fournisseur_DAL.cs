using System;
using System.Data.SqlClient;

namespace HuitMortsSixBlesses.DAL
{
    public class Fournisseur_DAL
    {
        public string NOM { get; set; }
        public int ID_PANIER { get; set; }
        public int ID { get;  set; }

        //public Point_DAL(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //}
        //version abrégée d'un constructeur qui ne fait qu'affecter dans 
        //ses propriétés les paramètres reçus
        public Fournisseur_DAL(string nom) => (NOM) = (nom);
        public Fournisseur_DAL(string nom,int idpanier) => (NOM,ID_PANIER) = (nom,idpanier);

        public Fournisseur_DAL(int id, string nom, int idPanier) 
                => (ID, NOM, ID_PANIER) = (id, nom, idPanier);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Fournisseur(nom,id_panier)"
                                + " values (@nom,@idPanier)";
                commande.Parameters.Add(new SqlParameter("@nom", NOM));
                commande.Parameters.Add(new SqlParameter("@idPanier", ID_PANIER));

                commande.ExecuteNonQuery();
            }
        }
    }
}