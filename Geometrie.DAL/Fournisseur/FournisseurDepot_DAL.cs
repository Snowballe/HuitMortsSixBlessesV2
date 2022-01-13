using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HuitMortsSixBlesses.DAL
{
    public class FournisseurDepot_DAL : Depot_DAL<Fournisseur_DAL>
    {

        public override void Delete(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Fournisseur where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adhérent d'ID {item.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Fournisseur_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, id_panier from Fournisseur";
            var reader = commande.ExecuteReader();

            var listeDFournisseurs = new List<Fournisseur_DAL>();

            while (reader.Read())
            {
                var a = new Fournisseur_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));


                listeDFournisseurs.Add(a);
            }

            DetruireConnexionEtCommande();

            return listeDFournisseurs;
        }

        public override Fournisseur_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, id_panier from Fournisseur where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();


            Fournisseur_DAL a;
            if (reader.Read())
            {
                a = new Fournisseur_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas d'adhérent dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return a;
        }

        public override Fournisseur_DAL Insert(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Fournisseur(nom, id_panier)"
                                    + " values (@nom, @IdPanier); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@nom", item.NOM));
            commande.Parameters.Add(new SqlParameter("@IdPanier", item.ID_PANIER));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            item.ID = ID;

            DetruireConnexionEtCommande();

            return item;
        }
        public Fournisseur_DAL GetByIDPanier(Fournisseur_DAL Fournisseur)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, id_panier from Fournisseur where id_panier=@IdPanier";
            commande.Parameters.Add(new SqlParameter("@IdPanier", Fournisseur.ID_PANIER));
            var reader = commande.ExecuteReader();


            Fournisseur_DAL a;
            if (reader.Read())
            {
                a = new Fournisseur_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas d'adhérent dans la BDD avec l'ID de panier {Fournisseur.ID_PANIER}");

            DetruireConnexionEtCommande();

            return a;
        }
        public override Fournisseur_DAL Update(Fournisseur_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Fournisseur set nom=@nom,id_panier=@IdPanier)"
                                    + " where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            commande.Parameters.Add(new SqlParameter("@nom", item.NOM));
            commande.Parameters.Add(new SqlParameter("@IdPanier", item.ID_PANIER));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la ligne d'ID {item.ID}");
            }

            DetruireConnexionEtCommande();

            return item;
        }
    }
}