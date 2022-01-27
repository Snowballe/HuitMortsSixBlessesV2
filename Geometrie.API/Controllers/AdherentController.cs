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
    [Route("adherent")]
    public class AdherentController : Controller
    {
        private IHuitMortsSixBlessesService service;

        public AdherentController(IHuitMortsSixBlessesService srv)
        {
            service = srv;
        }
        
        [HttpGet]
        public IEnumerable<Adherent_DTO> GetAllAdherent()
        {
            return service.getAll().Select(Adherent => new Adherent_DTO()
            {
                ID = Adherent.ChopeId,
                IDPANIER = Adherent.ChopeIdPanier,
                NOM = Adherent.ChopeNom
            });
        }

        [HttpGet]
        public ActionResult<Adherent_DTO> GetAdherent(int id)
        {
            var Adherent = service.getByID(id);

            if (Adherent == null)
            {
                //Error 404 (not found)
                return NotFound();
            }

            return new Adherent_DTO()
            {

                ID =Adherent.ChopeId,
                IDPANIER =Adherent.ChopeIdPanier,
                NOM =Adherent.ChopeNom
            };
        }


        [HttpPost]
        public Panier_DTO Insert(Adherent_DTO Adherent)
        {
            var Adherent_work = service.insert(new Adherent(Adherent.AdherentID, Adherent.AdherentPANIER, Adherent.AdherentNOM));
            //Je récupère l'id adherent
            Adherent.IDAdherent = Adherent_work.ChopeId;
            //je renvoie l'objet DTO
            return Adherent;
        }

        [HttpPut]
        public ActionResult<Adherent_DTO> Update(Adherent_DTO Adherent, int id)
        {
            Adherent.idAdherent = id;

            var Adherent_work = service.update(new Adherent(Adherent.AdherentID, Adherent.AdherentPANIER, Adherent.AdherentNOM));

            return Adherent;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            service.deleteByID(id);
        }

    }
}
