using HuitMortsSixBlesses.DTO;
using HuitMortsSixBlesses;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HuitMortsSixBlesses.API.Controllers
{
    [ApiController]
    [Route("panierGlobal")]
    public class PanierGController : Controller
    {
        private IHuitMortsSixBlessesService service;

        public PanierGController(IHuitMortsSixBlessesService srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<PanierGlobal_DTO> GetAllPanier()
        {
            return service.getAll().Select(Panier => new PanierGlobal_DTO()
            {
                ID = Panier.ChopeId,
                created_at = Panier.ChopeLaDate,
                IDPANIER = Panier.ChopeIdPanier,
                NOM = Panier.ChopeNom
            });
        }

        [HttpGet]
        public ActionResult<PanierGlobal_DTO> GetPanier(int id)
        {
            var Panier = service.getByID(id);

            if (Panier == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new PanierGlobal_DTO()
            {

                ID = Panier.ChopeId,
                created_at = Panier.ChopeLaDate,
                IDPANIER = Panier.ChopeIdPanier,
                NOM = Panier.ChopeNom
            };
        }


        [HttpPost]
        public Panier_DTO Insert(PanierGlobal_DTO Panier)
        {
            var Panier_work = service.insert(new Panier(Panier.PanierID, Panier.ChopeLaDate, Panier.PanierPANIER, Panier.PanierNOM));
            //Je récupère l'id Panier
            Panier.IDPanier = Panier_work.ChopeId;
            //je renvoie l'objet DTO
            return Panier;
        }

        [HttpPut]
        public ActionResult<PanierGlobal_DTO> Update(PanierGlobal_DTO Panier, int id)
        {
            Panier.idPanier = id;

            var Panier_work = service.update(new Panier(Panier.PanierID, Panier.ChopeLaDate, Panier.PanierPANIER, Panier.PanierNOM));

            return Panier;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            service.deleteByID(id);
        }

    }
}
