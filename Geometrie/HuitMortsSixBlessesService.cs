using HuitMortsSixBlesses.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class HuitMortsSixBlessesService : IHuitMortsSixBlessesService
    {
        private PanierDepot_DAL depotP = new PanierDepot_DAL();
        private LigneDepot_DAL depotL=new LigneDepot_DAL();
        private AdherentDepot_DAL depotAdh= new AdherentDepot_DAL();
        private FournisseurDepot_DAL depotFour = new FournisseurDepot_DAL();
        
        public List<Adherent> GetAdherents()
        {
            var Adherents = new List<Adherent>();
            foreach (var item in depotAdh.GetAll())
            {
                Adherents.Add(new Adherent(item.ID, item.ID_PANIER, item.NOM));
            }
            return Adherents;
        }

        public List<Fournisseur> GetFournisseurs()
        {
            var Fournisseurs=new List<Fournisseur>();
            foreach (var item in depotFour.GetAll())
            {
                Fournisseurs.Add(new Fournisseur(item.ID, item.ID_PANIER, item.NOM));
            }
            return Fournisseurs;
        }

        public Panier_Adherent GetPanierAdhByID(int id)
        {
            //var p = depotP.GetByID(id);
            var padh = depotAdh.GetByIDPanier(id);
            
            if (padh == null)
                throw new PanierException($"Le panier avec l'id {id} n'est pas un panier adhérent ou n'existe pas.",TypesDePaniers.PanierAdherent);

            var p = depotP.GetByID(id);
            return new Panier_Adherent(p.ID, p.LIGNES);
        
        }

        public List<Panier_Adherent> GetAllPanierAdherent()//LA GALERE
        {
            var adh = new List<Panier_Adherent>();
            var paniers= new List<Panier>();
            
            var paniersIDAdh = depotAdh.GetAllPanierIDs();
            var paniersAdh = depotAdh.GetAll();
            foreach (var item in paniersIDAdh)
            {
               var v= depotP.GetByID(item);

            }
            
     

        }
        public Panier_Adherent Insert(Panier_Adherent p)
        {
            var panier = new Panier_DAL(p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Insert(panier);
            p.ID=panier.ID;
            return p;
        }

        public Panier_Adherent Update(Panier_Adherent p)
        {
            var panier=new Panier_DAL(p.ID,null,p.Select(p=>new Ligne_DAL(p.QUANTITE,p.REFERENCE,p.MARQUE)));
            depotP.Update(panier);
            return p;
        }

        public void Delete(Panier_Adherent p)
        {
            var panier = new Panier_DAL(p.ID, null, p.Select(p => new Ligne_DAL(p.QUANTITE, p.REFERENCE, p.MARQUE)));
            depotP.Delete(panier);
        }

        public List<Panier> GetAllPanierFournisseur()
        {
            throw new NotImplementedException();
        }

        public List<Panier> GetAllPaniers()
        {
            throw new NotImplementedException();
        }

        public List<Panier> GetCurrentPaniers()
        {
            throw new NotImplementedException();
        }
    }
}
