using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class Panier_Fournisseur : Panier
    {
        public bool EstValide { get; private set; }
        public int IDFOURNISSEUR { get; set; }

        public Panier_Fournisseur(int idfour, Panier monPanier)
            : base(monPanier.lesLignes)
        {

            monPanier.ArrangerPanier(monPanier.lesLignes);
            IDFOURNISSEUR = idfour;
            EstValide = true;
        }


        public override void SendToGlobalPanier()//todo: 
        {
            var p = new Panier_Global(this);
        }
    }
}
