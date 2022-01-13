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
    public class Panier_Global
    {
        public List<Panier_Adherent> TouslesPaniersAdherent { get; set; }
        public List<Panier_Fournisseur> TouslesPaniersFournisseurs { get; set; }
        public Panier_Global(List<Panier_Adherent> malisteAdherent, List<Panier_Fournisseur> malisteFournisseur)
        {
            TouslesPaniersAdherent = malisteAdherent;
            TouslesPaniersFournisseurs = malisteFournisseur;
        }

        

    }
}
