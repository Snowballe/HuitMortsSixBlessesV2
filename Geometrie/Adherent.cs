using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public class Adherent
    {
        public int ID { get; set; }
        public int IDPANIER { get; set; }
        public string NOM { get; set; }


        public Adherent(int id, int idPanier, string nom)
        {
            ID= id;
            IDPANIER= idPanier;
            NOM= nom;

        }
        public Adherent( int idPanier, string nom)
        {
            IDPANIER = idPanier;
            NOM = nom;

        }
        public override string ToString() => $"[{string.Join(";", this)}]";
    }
}
