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

        public Panier_Fournisseur(int idfour, List<Ligne> monPanierEnLignes)
            : base(monPanierEnLignes)
        {
            
                for (int i = 0; i < monPanierEnLignes.Count; i++)
                    for (int j = 0; j < monPanierEnLignes.Count; j++)
                        monPanierEnLignes[i].EviterDoublon(monPanierEnLignes[j]);
                

            
            IDFOURNISSEUR = idfour;
            EstValide = true;
        }


        
    }
}
