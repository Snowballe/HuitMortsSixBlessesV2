using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses
{
    public interface IHuitMortsSixBlessesService
    {
        public List<Panier> GetAllPaniers();
        public List<Panier> GetCurrentPaniers();

        public List<Panier> GetAllPanierAdherent();
        public List<Panier> GetAllPanierFournisseur();






    }
}
