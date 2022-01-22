using System.Collections.Generic;

namespace HuitMortsSixBlesses
{
    public interface IHuitMortsSixBlessesService
    {
        

        //------------------------------------------

        public List<Adherent> GetAdherents();
        public Adherent GetAdherentbyID(int id);
        public Adherent UpdateAdherent(Adherent adh);
        public Adherent Insert(Adherent a);
        public void Delete(Adherent a);

        //------------------------------------------

        public Panier_Adherent GetPanierAdhByID(int id);
        public List<Panier_Adherent> GetAllPanierAdherent();
        public Panier_Adherent Insert(Panier_Adherent p);
        public Panier_Adherent Update(Panier_Adherent p);
        public void Delete(Panier_Adherent p);

        //-------------------------------------------

        public List<Fournisseur> GetFournisseurs();
        public Fournisseur GetFournisseursByID(int id);
        public Fournisseur Update(Fournisseur f);
        public Fournisseur Insert(Fournisseur f);
        public void Delete(Fournisseur f);

        //--------------------------------------------

        public Panier_Fournisseur GetPanierFourByID(int id);
        public List<Panier_Fournisseur> GetAllPanierFournisseur();
        public Panier_Fournisseur Insert(Panier_Fournisseur p);
        public Panier_Fournisseur Update(Panier_Fournisseur p);
        public void Delete(Panier_Fournisseur p);

        //----------------------------------------------

        public Panier_Global GetCurrentPaniers();
        public Panier_Global GetPanierGlobalByID(int id);
        public List<Panier_Global> GetAllPanierGlobal();
        public Panier_Global Insert(Panier_Global p);
        public Panier_Global Update(Panier_Global p);
        public void Delete(Panier_Global p);

















    }
}