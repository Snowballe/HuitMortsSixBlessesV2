using System;
using System.Collections.Generic;

namespace HuitMortsSixBlesses.DTO
{
    public class PanierAdh_DTO
    {
        public int ID { get; set; }
        public int ID_Adherent { get; set; }
        public DateTime? created_at { get; set; }
        public List<Ligne> LignesGlobales { get; set; }
        public IEnumerable<Ligne> LigneEnum { get; set; }
    }
}
