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

        public List<Panier_Adherent> GetAllPanierAdherent()
        {
            var paniersIDAdh = depotAdh.GetAllPanierIDs();
            var paniersAdh = depotAdh.GetAll();
            List<Panier_Adherent> paniers=new List<Panier_Adherent>();


            foreach (var item in paniersAdh)
            {
                var p = depotP.GetAll()
                    .Where(p => p.ID.Equals(item)) ;

                paniers.Add(p);
            }
            return paniers;

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
