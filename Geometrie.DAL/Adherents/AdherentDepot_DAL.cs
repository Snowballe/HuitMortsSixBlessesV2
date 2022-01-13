using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace HuitMortsSixBlesses.DAL
{
    public class AdherentDepot_DAL : Depot_DAL<Adherent_DAL>
    {

        public override void Delete(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Adherent where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", item.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer l'adhérent d'ID {item.ID}");
            }

            DetruireConnexionEtCommande();
        }

        public override List<Adherent_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, id_panier from Adherent";
            var reader = commande.ExecuteReader();

            var listeDAdherents = new List<Adherent_DAL>();

            while (reader.Read())
            {
                var a = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));


                listeDAdherents.Add(a);
            }

            DetruireConnexionEtCommande();

            return listeDAdherents;
        }
        public List<int> GetAllPanierIDs()
        {
            CreerConnexionEtCommande();
            commande.CommandText = "select id_panier from Adherent";
            var reader=commande.ExecuteReader();
            var ids = new List<int>();
            while (reader.Read())
            {
                var id = reader.GetInt32(0);
                ids.Add(id);
            }
            return ids;
        }

        public override Adherent_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, id_panier from Adherent where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();


            Adherent_DAL a;
            if (reader.Read())
            {
                a = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas d'adhérent dans la BDD avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return a;
        }

        public override Adherent_DAL Insert(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Adherent(nom, id_panier)"
                                    + " values (@nom, @IdPanier); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@nom", item.NOM));
            commande.Parameters.Add(new SqlParameter("@IdPanier", item.ID_PANIER));

            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            item.ID = ID;

            DetruireConnexionEtCommande();

            return item;
        }
        public Adherent_DAL GetByIDPanier(Adherent_DAL adherent)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, nom, id_panier from Adherent where id_panier=@IdPanier";
            commande.Parameters.Add(new SqlParameter("@IdPanier", adherent.ID_PANIER));
            var reader = commande.ExecuteReader();


            Adherent_DAL a;
            if (reader.Read())
            {
                a = new Adherent_DAL(reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetInt32(2));
            }
            else
                throw new Exception($"Pas d'adhérent dans la BDD avec l'ID de panier {adherent.ID_PANIER}");

            DetruireConnexionEtCommande();

            return a;
        }
        public override Adherent_DAL Update(Adherent_DAL item)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Adherent set nom=@nom,id_panier=@IdPanier)"
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