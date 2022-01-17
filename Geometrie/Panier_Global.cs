using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    /// <summary>
    /// Représente un <see cref="Panier_Global"/> dans un repère à 2 dimensions
    /// </summary>
    public class Panier_Global : Panier
    {
        public List<Ligne> ListeGlobale { get; set; }

        public bool EstValide { get; set; }
       
        
        public Panier_Global(List<Ligne> maListe)
            :base(maListe)
        {
            for (int i = 0; i < maListe.Count; i++)
                for (int j = 0; j < maListe.Count; j++)
                    maListe[i].EviterDoublon(maListe[j]);



            ListeGlobale = maListe;

            EstValide = true;
        }

    

    }
}
