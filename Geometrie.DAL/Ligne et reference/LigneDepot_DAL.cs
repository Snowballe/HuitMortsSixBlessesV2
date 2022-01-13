using HuitMortsSixBlesses.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses.DAL
{
    public class LigneDepot_DAL : Depot_DAL<Ligne_DAL>
    {
        public override List<Ligne_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select id, quantité, reference, marque,id_panier from Ligne";
            var reader = commande.ExecuteReader();

            var listeDeLignes = new List<Ligne_DAL>();

            while (reader.Read())
            {
                var p = new Ligne_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetString(4),
                                        reader.GetInt32(3));
                                        

                listeDeLignes.Add(p);
            }

            DetruireConnexionEtCommande();

            return listeDeLignes;
        }

        public List<Ligne_DAL>GetByid_panier(int ID)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "select * from Ligne where id_panier=@id_panier";
            commande.Parameters.Add(new SqlParameter("@id_panier", ID));
            var reader = commande.ExecuteReader();
            var ListeDeLignes=new List<Ligne_DAL>();
            while (reader.Read())
            {
                var l = new Ligne_DAL(reader.GetInt32(0),
                    reader.GetInt32(1), 
                    reader.GetString(2), 
                    reader.GetString(3), 
                    reader.GetInt32(4));

                ListeDeLignes.Add(l);
            }
            DetruireConnexionEtCommande();
            return ListeDeLignes;
        }

        public override Ligne_DAL GetByID(int ID) { 
            CreerConnexionEtCommande();

            commande.CommandText = "select id, quantité, reference,marque, id_panier from Ligne where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));

            var reader = commande.ExecuteReader();

            Ligne_DAL p;
            if (reader.Read())
            {
                p = new Ligne_DAL(reader.GetInt32(0),
                                        reader.GetInt32(1),
                                        reader.GetString(2),
                                        reader.GetString(4),
                                        reader.GetInt32(3));

            }
            else
                throw new Exception($"Pas le ligne avec l'ID {ID}");

            DetruireConnexionEtCommande();

            return p;
        }
        
        public override Ligne_DAL Insert(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Ligne(quantité, reference,marque, id_panier)"
                                    + " values (@quantite, @reference,@marque, @id_panier); select scope_identity()";
            commande.Parameters.Add(new SqlParameter("@quantite", ligne.QUANTITE));
            commande.Parameters.Add(new SqlParameter("@reference", ligne.REFERENCE));
            commande.Parameters.Add(new SqlParameter("@marque", ligne.MARQUE));
            commande.Parameters.Add(new SqlParameter("@id_panier", ligne.ID_PANIER));
            
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            ligne.ID = ID;

            DetruireConnexionEtCommande();

            return ligne;
        }

        public override Ligne_DAL Update(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "update Ligne set quantité=@quantite, reference=@reference, marque=@marque id_panier=@id_panier)"
                                    + " where id=@ID";
            commande.Parameters.Add(new SqlParameter("@quantite", ligne.QUANTITE));
            commande.Parameters.Add(new SqlParameter("@marque", ligne.MARQUE));
            commande.Parameters.Add(new SqlParameter("@reference", ligne.REFERENCE));
            commande.Parameters.Add(new SqlParameter("@id_panier", ligne.ID_PANIER));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees!=1)
            {
                throw new Exception($"Impossible de mettre à jour la ligne d'ID {ligne.ID}");
            }

            DetruireConnexionEtCommande();

            return ligne;
        }
        public Ligne_DAL IncrementQuantity(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();
            commande.CommandText = "update Ligne set quantité=quantité+1 where id=@id";
            commande.Parameters.Add(new SqlParameter("@id", ligne.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();
            
            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de mettre à jour la ligne d'ID {ligne.ID}");
            }

            DetruireConnexionEtCommande();
            return ligne;
        }

        public override void Delete(Ligne_DAL ligne)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Ligne where id=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ligne.ID));
            var nombreDeLignesAffectees = (int)commande.ExecuteNonQuery();

            if (nombreDeLignesAffectees != 1)
            {
                throw new Exception($"Impossible de supprimer la ligne d'ID {ligne.ID}");
            }

            DetruireConnexionEtCommande();
        }


    }
}
