using HuitMortsSixBlesses.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses.DAL
{
    public class PanierDepot_DAL : Depot_DAL<Panier_DAL>
    {
        public override List<Panier_DAL> GetAll()
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID from Panier";
            var reader = commande.ExecuteReader();

            var depotLigne = new LigneDepot_DAL();

            var listePaniers = new List<Panier_DAL>();

            while (reader.Read())
            {
                var lignes = depotLigne.GetAllByIDPanier(reader.GetInt32(0));

                var p = new Panier_DAL(reader.GetInt32(0),
                    lignes);
                listePaniers.Add(p);
            }

            DetruireConnexionEtCommande();

            return listePaniers;
        }

        public override Panier_DAL GetByID(int ID)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "select ID, dateCreation, dateModification from Polygones where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", ID));
            var reader = commande.ExecuteReader();

            var depotPoint = new LigneDepot_DAL();

            Panier_DAL p;

            if (reader.Read())
            {
                var points = depotPoint.GetAllByIDPanier(reader.GetInt32(0));

                p = new Panier_DAL(reader.GetInt32(0),
                                        points);
            }
            else
            {
                throw new Exception($"Pas de panier avec l'ID {ID}");
            }

            DetruireConnexionEtCommande();

            return p;
        }

        public override Panier_DAL Insert(Panier_DAL panier)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "insert into Panier(created_at)"
                                    + " values (GetDate()); select scope_identity()";
            var ID = Convert.ToInt32((decimal)commande.ExecuteScalar());

            panier.CREATEDAT = GetByID(ID).CREATEDAT;

            DetruireConnexionEtCommande();

            var depotPanier = new LigneDepot_DAL();
            foreach (var item in panier.LIGNES)
            {
                item.ID_PANIER = ID;
                depotPanier.Insert(item);
            }

            return panier;
        }
        #region Fonction Update non implémenté car inutile (pas de updated_at)


        //public override Panier_DAL Update(Panier_DAL panier)
        //{
        //    CreerConnexionEtCommande();

        //    commande.CommandText = "update Panier set dateModification=getDate() where ID=@ID";
        //    commande.Parameters.Add(new SqlParameter("@ID", poly.ID));

        //    var nbLignes = (int)commande.ExecuteNonQuery();

        //    if (nbLignes != 1)
        //    {
        //        throw new Exception($"Impossible de mettre à jour le polygone d'ID {poly.ID}");
        //    }

        //    poly.DateModification = GetByID(poly.ID).DateModification;

        //    DetruireConnexionEtCommande();

        //    var depotPoint = new LigneDepot_DAL();
        //    foreach (var item in poly.Points)
        //    {
        //        depotPoint.Update(item);
        //    }

        //    return poly;
        //}
        #endregion
        public override void Delete(Panier_DAL poly)
        {
            CreerConnexionEtCommande();

            commande.CommandText = "delete from Panier where ID=@ID";
            commande.Parameters.Add(new SqlParameter("@ID", poly.ID));

            var nbLignes = (int)commande.ExecuteNonQuery();

            if (nbLignes != 1)
            {
                throw new Exception($"Impossible de supprimer le panier d'ID {poly.ID}");
            }

            DetruireConnexionEtCommande();
        }


    }
}
