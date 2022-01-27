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
    [Route("fournisseurs")]
    public class FournisseursController : Controller
    {
        private IHuitMortsSixBlessesService service;

        public FournisseursController(IHuitMortsSixBlessesService srv)
        {
            service = srv;
        }

        [HttpGet]
        public IEnumerable<Fournisseur_DTO> GetAllFournisseurs()
        {
            return service.getAll().Select(Fournisseurs => new Fournisseur_DTO()
            {
                ID = Fournisseurs.ChopeId,
                IDPANIER = Fournisseurs.ChopeIdPanier,
                NOM = Fournisseurs.ChopeNom
            });
        }

        [HttpGet]
        public ActionResult<Fournisseur_DTO> GetFournisseurs(int id)
        {
            var Fournisseurs = service.getByID(id);

            if (Fournisseurs == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new Fournisseurs_DTO()
            {

                ID = Fournisseurs.ChopeId,
                IDPANIER = Fournisseurs.ChopeIdPanier,
                NOM = Fournisseurs.ChopeNom
            };
        }


        [HttpPost]
        public Panier_DTO Insert(Fournisseur_DTO Fournisseurs)
        {
            var Fournisseurs_work = service.insert(new Fournisseurs(Fournisseurs.FournisseursID, Fournisseurs.FournisseursPANIER, Fournisseurs.FournisseursNOM));
            //Je récupère l'id Fournisseurs
            Fournisseurs.IDFournisseurs = Fournisseurs_work.ChopeId;
            //je renvoie l'objet DTO
            return Fournisseurs;
        }

        [HttpPut]
        public ActionResult<Fournisseur_DTO> Update(Fournisseur_DTO Fournisseurs, int id)
        {
            Fournisseurs.idFournisseurs = id;

            var Fournisseurs_work = service.update(new Fournisseurs(Fournisseurs.FournisseursID, Fournisseurs.FournisseursPANIER, Fournisseurs.FournisseursNOM));

            return Fournisseurs;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            service.deleteByID(id);
        }

    }
}
