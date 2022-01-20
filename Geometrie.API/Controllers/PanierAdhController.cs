using HuitMortsSixBlesses.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses.API.Controllers
{
    [ApiController]
    [Route("[PanierAdherent]")]
    public class PanierAdhController : Controller
    {
        private IHuitMortsSixBlessesService service;

        public PanierAdhController(IHuitMortsSixBlessesService srv)
        {
            service = srv;
        }


        [HttpGet]
        public IEnumerable<PanierAdh_DTO> GetAllPanierAdh()
        {
            //je transforme mes triangles en triangle DTO
            return service.GetAllPanierAdherent().Select(t => new PanierAdh_DTO()
            {
                ID=t.ID,
                ID_Adherent=t.IDADHERENT,
                LignesGlobales=t.lesLignes,
                LigneEnum=


                //X1 = t[0].X,
                //Y1 = t[0].Y,
                //X2 = t[1].X,
                //Y2 = t[1].Y,
                //X3 = t[2].X,
                //Y3 = t[2].Y,
            }) ;
        }

        [HttpPost]
        public Panier_DTO Insert(Panier_DTO t)
        {
            var t_metier=service.Insert(new Panier_Fournisseur(new Ligne(t.X1, t.Y1), new Ligne(t.X2, t.Y2), new Ligne(t.X3, t.Y3)));
            //Je récupère l'ID
            t.ID = t_metier.ID;
            //je renvoie l'objet DTO
            return t;
        }
    }
}
