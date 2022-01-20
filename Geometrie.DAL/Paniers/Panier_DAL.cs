using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace HuitMortsSixBlesses.DAL
{
    public class Panier_DAL
    {
        public int ID { get; set; }
        public DateTime CREATEDAT { get; set; }

        public List<Ligne_DAL> LIGNES { get; set; }

        //public Polygone_DAL(List<Point_DAL> desPoints)
        //{
        //    Points = desPoints;            
        //}

        public Panier_DAL(IEnumerable<Ligne_DAL> desLignes)
                    => (LIGNES) = (desLignes.ToList());
        public Panier_DAL(int id, IEnumerable<Ligne_DAL> desLignes)
                    => (ID,LIGNES) = (id,desLignes.ToList());
        public Panier_DAL(int id,DateTime datecreation,IEnumerable<Ligne_DAL> desLignes)
                    => (ID, CREATEDAT,LIGNES) = (id, datecreation, desLignes.ToList());

      
    }
}
