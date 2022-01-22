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

        public Panier_Adherent(int idadh, List<Ligne> mesLignesAdherent)
            : base(mesLignesAdherent)
        {

            for (int i = 0; i < mesLignesAdherent.Count; i++)
                for (int j = 0; j < mesLignesAdherent.Count; j++)
                    mesLignesAdherent[i].EviterDoublon(mesLignesAdherent[j]);



            IDADHERENT = idadh;
            EstValide = true;
        }
        public Panier_Adherent(int idadh, Panier Monpanier)
            : base(Monpanier.lesLignes)
        {

            Monpanier.ArrangerPanier(Monpanier.lesLignes);



            IDADHERENT = idadh;
            EstValide = true;
        }


        
    }
}
