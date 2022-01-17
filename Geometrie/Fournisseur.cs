using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class Fournisseur
    {
        public int ID { get; set; }
        public int IDPANIER { get; set; }
        public string NOM { get; set; }

        public Fournisseur(int id, int idPanier, string nom)
        {
            ID= id;
            IDPANIER= idPanier;
            NOM= nom;

        }
        public override string ToString() => $"[{string.Join(";", this)}]";
    }
}
