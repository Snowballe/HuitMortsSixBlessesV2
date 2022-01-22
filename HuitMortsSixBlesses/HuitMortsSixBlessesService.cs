using HuitMortsSixBlesses.DAL;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class HuitMortsSixBlessesService : IHuitMortsSixBlessesService
    {
        private PanierDepot_DAL depotP = new PanierDepot_DAL();
        private LigneDepot_DAL depotL = new LigneDepot_DAL();
        private AdherentDepot_DAL depotAdh = new AdherentDepot_DAL();
        private FournisseurDepot_DAL depotFour = new FournisseurDepot_DAL();

        #region Service Adhérent 
        public List<Adherent> GetAdherents()
        {
            var Adherents = new List<Adherent>();
            foreach (var item in depotAdh.GetAll())
            {
                Adherents.Add(new Adherent(item.ID, item.ID_PANIER, item.NOM));
            }
            return Adherents;
        }

        public Adherent GetAdherentbyID(int id)
        {
            var adh = depotAdh.GetByID(id);

            return new Adherent(adh.ID, adh.ID_PANIER, adh.NOM);
        }

        public Adherent UpdateAdherent(Adherent adh)
        {
            var adhDAL = new Adherent_DAL(adh.ID, adh.NOM, adh.IDPANIER);
            var newadh = depotAdh.Update(adhDAL);
            Adherent adherent = new Adherent(adh.ID, newadh.ID_PANIER, newadh.NOM);
            return adherent;
        }

        public Adherent Insert(Adherent a)
        {
            var adhDAL = new Adherent_DAL(a.NOM, a.IDPANIER);
            depotAdh.Insert(adhDAL);
            a.ID = adhDAL.ID;
            return a;
        }

        public void Delete(Adherent a)
        {
            var adhDAL = new Adherent_DAL(a.ID, a.NOM, a.IDPANIER);
            depotAdh.Delete(adhDAL);
        }
        #endregion

        #region Panier Adhérent
        public Panier_Adherent GetPanierAdhByID(int id)
        {
            var padh = depotAdh.GetByIDPanier(id);//on vérifie que l'id du panier appartient bien à un adhérent

            if (padh == null)
                throw new PanierException($"Le panier avec l'id {id} n'est pas un panier adhérent ou n'existe pas.", TypesDePaniers.PanierAdherent);

            var templistL = new List<Ligne>();
            var p = depotP.GetByID(id);

            foreach (var ligne in p.LIGNES)
            {
                var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                templistL.Add(l);
            }
            return new Panier_Adherent(p.ID, templistL);

        }

        public List<Panier_Adherent> GetAllPanierAdherent()
        {
            var ladh = new List<Panier_Adherent>();
            var templlist = new List<Ligne>();


            var paniersIDAdh = depotAdh.GetAllPanierIDs();
            foreach (var item in paniersIDAdh)
            {
                var v = depotP.GetByID(item);
                foreach (var ligne in v.LIGNES)
                {
                    var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                    templlist.Add(l);
                }
                var adh = new Panier_Adherent(item, templlist);
                ladh.Add(adh);
            }
            return ladh;



        }
        public Panier_Adherent Insert(Panier_Adherent p)
        {
            var panier = new Panier_DAL(p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Insert(panier);
            p.ID = panier.ID;
            return p;
        }

        public Panier_Adherent Update(Panier_Adherent p)
        {
            var panier = new Panier_DAL(p.ID, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Update(panier);
            return p;
        }

        public void Delete(Panier_Adherent p)
        {
            var panier = new Panier_DAL(p.ID, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Delete(panier);
        }

        #endregion


        #region Service Fournisseur
        public List<Fournisseur> GetFournisseurs()
        {
            var Fournisseurs = new List<Fournisseur>();
            foreach (var item in depotFour.GetAll())
            {
                Fournisseurs.Add(new Fournisseur(item.ID, item.ID_PANIER, item.NOM));
            }
            return Fournisseurs;
        }

        public Fournisseur GetFournisseursByID(int id)
        {
            var four = depotFour.GetByID(id);
            return new Fournisseur(four.ID, four.ID_PANIER, four.NOM);
        }

        public Fournisseur Update(Fournisseur f)
        {
            var fourDAL = new Fournisseur_DAL(f.ID, f.NOM, f.IDPANIER);
            var newFour = depotFour.Update(fourDAL);
            return f;
        }
        public Fournisseur Insert(Fournisseur f)
        {
            var fourDAL = new Fournisseur_DAL(f.ID, f.NOM, f.IDPANIER);
            depotFour.Insert(fourDAL);
            f.ID = fourDAL.ID;
            return f;
        }
        public void Delete(Fournisseur f)
        {
            var fourDAL = new Fournisseur_DAL(f.ID, f.NOM, f.IDPANIER);
            depotFour.Delete(fourDAL);
        }
        #endregion


        #region Panier Fournisseur
        public Panier_Fournisseur GetPanierFourByID(int id)
        {
            var padh = depotAdh.GetByIDPanier(id);//on vérifie que l'id du panier appartient bien à un adhérent

            if (padh == null)
                throw new PanierException($"Le panier avec l'id {id} n'est pas un panier adhérent ou n'existe pas.", TypesDePaniers.PanierFournisseur);

            var templistL = new List<Ligne>();
            var p = depotP.GetByID(id);

            foreach (var ligne in p.LIGNES)
            {
                var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                templistL.Add(l);
            }
            return new Panier_Fournisseur(p.ID, templistL);

        }

        public List<Panier_Fournisseur> GetAllPanierFournisseur()
        {
            var ladh = new List<Panier_Fournisseur>();
            var templlist = new List<Ligne>();


            var paniersIDAdh = depotAdh.GetAllPanierIDs();
            foreach (var item in paniersIDAdh)
            {
                var v = depotP.GetByID(item);
                foreach (var ligne in v.LIGNES)
                {
                    var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                    templlist.Add(l);
                }
                var adh = new Panier_Fournisseur(item, templlist);
                ladh.Add(adh);
            }
            return ladh;



        }
        public Panier_Fournisseur Insert(Panier_Fournisseur p)
        {
            var panier = new Panier_DAL(p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Insert(panier);
            p.ID = panier.ID;
            return p;
        }

        public Panier_Fournisseur Update(Panier_Fournisseur p)
        {
            var panier = new Panier_DAL(p.ID, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Update(panier);
            return p;
        }

        public void Delete(Panier_Fournisseur p)
        {
            var panier = new Panier_DAL(p.ID, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Delete(panier);
        }
        #endregion


        #region Panier Global
        public Panier_Global GetPanierGlobalByID(int id)
        {

            var padh = depotAdh.GetByIDPanier(id);
            var pfour = depotFour.GetByIDPanier(id);//on regarde si ça appartient à un fournisseur ou un adh

            if (padh != null || pfour != null)
            {
                    throw new PanierException($"Le panier avec l'id {id} n'est pas un panier global.", TypesDePaniers.PanierGlobal);
            }

            var templistL = new List<Ligne>();
            var p = depotP.GetByID(id);

            foreach (var ligne in p.LIGNES)
            {
                var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                templistL.Add(l);
            }
            return new Panier_Global(templistL);

        }

        public List<Panier_Global> GetAllPanierGlobal()
        //J'ai besoin de trier les id qui appartiennent aux fournisseurs et adh, et de dire que ce n'est pas ce qu'on veut, car le reste c'est des paniers globaux
        {

            var lpglobal = new List<Panier_Global>();
            var templlist = new List<Ligne>();

            var listIDpanierAdh = depotAdh.GetAllPanierIDs();
            var listIDPanierFour = depotFour.GetAllPanierIDs();
            
            List<int> Bannedlist= (List<int>)listIDpanierAdh.Concat(listIDPanierFour);//On mets tous les ids de paniers qu'on ne veut pas ici
            var p = depotP.GetAll();//Et ensuite je vais venir comparer avec le getall, pour virer tous ceux que j'ai dans ma liste


            List<int> GoodIDs=new List<int>();
            
            foreach (var BannedID in Bannedlist)
            {
                for (int i = 0; i < p.Count; i++)
                {
                    if (BannedID != p[i].ID)
                    {
                        GoodIDs.Add(p[i].ID);
                    }
                }
                }

            foreach (var item in GoodIDs)
            {
                var pid = depotP.GetByID(item);

                foreach (var ligne in pid.LIGNES)
                {
                    var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                    templlist.Add(l);
                }
                var globalP = new Panier_Global(templlist);
                lpglobal.Add(globalP);
            }
            return lpglobal;

        }

        
        public Panier_Global Insert(Panier_Global p)
        {
            var panier = new Panier_DAL(p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Insert(panier);
            p.ID = panier.ID;

            return p;
        }

        public Panier_Global Update(Panier_Global p)
        {
            var panier = new Panier_DAL(p.ID, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Update(panier);
            return p;
        }

        public void Delete(Panier_Global p)
        {
            var panier = new Panier_DAL(p.ID, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Delete(panier);
        }
        public Panier_Global GetCurrentPaniers()
        {//Je veux prendre les paniers qui sont dans la semaine ou l'on est présentement
            var templlist = new List<Ligne>();

            var dt = DateTime.Now;
            Calendar cal = new CultureInfo("fr-FR").Calendar;
            int Currentweek = cal.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

            var Paniers = depotP.GetAll();
            foreach (var item in Paniers)
            {
                int weekToCompare = cal.GetWeekOfYear(item.CREATEDAT, CalendarWeekRule.FirstDay, DayOfWeek.Monday);

                if (Currentweek == weekToCompare)
                {
                    foreach (var ligne in item.LIGNES)
                    {
                        var l = new Ligne(ligne.QUANTITE, ligne.ID_PANIER, ligne.REFERENCE, ligne.MARQUE);
                        templlist.Add(l);
                    }



                }
            }
            var p = new Panier_Global(templlist);
            return p;
        }

        


        #endregion
    }
}
