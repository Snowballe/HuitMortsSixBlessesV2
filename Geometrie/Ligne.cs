using System;
using HuitMortsSixBlesses.DAL;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    
    public class Ligne
    {
        #region champs et accesseurs
        //champ
        private int quantite;
        private string reference { get; set; }
        private string marque { get; set; }
        private int idPanier { get; set; }
        //Accesseur (ou propriété)
        /// <summary>
        /// Quantité du produit
        /// </summary>
        public int QUANTITE
        {
            get { return quantite; }
            private set { quantite = value; }
        }
       public string REFERENCE
        {
            get { return reference; }
            private set { reference = value; }
        }
        public string MARQUE
        {
            get { return marque; }
            private set { marque = value; }
        }
        public int IDPANIER { 
            get { return idPanier; }
            private set { idPanier = value; }
        }


        /// <summary>
        /// ID de la ligne dans la BDD
        /// </summary>
        public int ID { get; set; }


        #endregion

        #region constructeur

        /// <summary>
        /// Construit un point
        /// </summary>
        /// <param name="quantite">la quantite du produit le la ligne par rapport à la référence</param>
        public Ligne(int quantite, int id_panier,string reference, string marque)
        {
            IDPANIER = id_panier;
            REFERENCE = reference;
            MARQUE = marque;
            QUANTITE = quantite;
        }

        public Ligne(int id, int quantite,int id_panier, string reference, string marque)
            :this(quantite,id_panier,reference,marque)
        {
            ID = id;
        }
        #endregion

        #region Méthodes

        /// <summary>
        /// Retourne une représentation sous forme de <see cref="string"/> du <see cref="Ligne"/>
        /// </summary>
        /// <returns>la chaine de caractères</returns>
        public override string ToString()
        {
            return $"({QUANTITE},{MARQUE},{REFERENCE})";
        }
        //comme ça ne fait qu'un return quelque fois
        //vous le verrez comme ça
        //public override string ToString() => $"({X};{Y})";

        public bool EviterDoublon(Ligne autreLigne)
        {
            var maligne = new Ligne_DAL(this.QUANTITE, this.REFERENCE, this.MARQUE);
            var maLigneASupprimer = new Ligne_DAL(autreLigne.QUANTITE, autreLigne.REFERENCE, autreLigne.MARQUE);

            var depotLigne = new LigneDepot_DAL();
            if (maligne == maLigneASupprimer)
            {
                depotLigne.IncrementQuantity(maligne);
                depotLigne.Delete(maLigneASupprimer);

                //Si on a bien additionné les lignes entre elles, on renvoie true (j'aurais pu mettre void sinon)
                return true;
            }
            else
            {
                return false;

            }
        }
       
        #endregion
    }
}