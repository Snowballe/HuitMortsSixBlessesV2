using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class PanierException : Exception
    {
        public TypesDePaniers Type { get; private set; }

        public PanierException(string message, TypesDePaniers unType)
            :base(message)
        {
            Type = unType;
        }
    }

    public enum TypesDePaniers
    {
        PanierAdherent, PanierFournisseur, Panier, PanierGlobal
    }
}
