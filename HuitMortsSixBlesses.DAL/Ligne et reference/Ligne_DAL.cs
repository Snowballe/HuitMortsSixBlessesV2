using System;
using System.Data.SqlClient;

namespace HuitMortsSixBlesses.DAL
{
    public class Ligne_DAL
    {
        public int QUANTITE { get; private set; }

        public int ID_PANIER { get; set; }
        public int ID { get;  set; }

        public string REFERENCE { get; set; }
        public string MARQUE { get; set; }

        //public Point_DAL(int x, int y)
        //{
        //    X = x;
        //    Y = y;
        //}
        //version abrégée d'un constructeur qui ne fait qu'affecter dans 
        //ses propriétés les paramètres reçus
        public Ligne_DAL(int quantite, string reference, string marque) => (QUANTITE, REFERENCE, MARQUE) = (quantite,reference,marque);

        public Ligne_DAL(int id, int quantite, string Reference, string marque, int idPanier) 
                => (ID, QUANTITE, REFERENCE,MARQUE, ID_PANIER) = (id, quantite, Reference,marque, idPanier);

        internal void Insert(SqlConnection connexion)
        {
            using (var commande = new SqlCommand())
            {
                commande.Connection = connexion;
                commande.CommandText = "insert into Ligne(quantité,id_panier,reference,marque)"
                                + " values (@quantite, @idPanier,@reference,@marque)";
                commande.Parameters.Add(new SqlParameter("@quantite", QUANTITE));
                commande.Parameters.Add(new SqlParameter("@idPanier", ID_PANIER));
                commande.Parameters.Add(new SqlParameter("@reference", REFERENCE));
                commande.Parameters.Add(new SqlParameter("@marque", MARQUE));

                commande.ExecuteNonQuery();
            }
        }
    }
}