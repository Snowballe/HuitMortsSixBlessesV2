using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class Panier_Adherent : Panier
    {
        public bool EstValide { get; private set; }
        public int IDADHERENT { get; set; }

        public Panier_Adherent(int idadh, Panier monPanier)
            :base(monPanier.lesLignes)
        {
            monPanier.ArrangerPanier(monPanier.lesLignes);
            EstValide = true;
            IDADHERENT = idadh;
        }


        public override void SendToGlobalPanier()//todo
        {
            var p = new Panier_Global(this);
        }
    }
}
