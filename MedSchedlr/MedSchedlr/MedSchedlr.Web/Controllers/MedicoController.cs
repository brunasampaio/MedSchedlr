using System.Linq;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;
using MedSchedlr.Data.Entities;
using System.Web.Mvc;

namespace MedSchedlr.Web.Controllers
{
    public class MedicoController : Controller
    {
        IMedicoService _medicoService;

        public MedicoController()
        {
            _medicoService = new MedicoService();
        }

        [HttpGet]
        public void Insert(Medico medico)
        {
            _medicoService.Insert(medico);
        }

        [HttpGet]
        public void Update(Medico medico)
        {
            _medicoService.Update(medico);
        }

        [HttpGet]
        public void Delete(Medico medico)
        {
            _medicoService.Delete(medico);
        }

        [HttpGet]
        public Medico[] GetAll()
        {
            var medico = _medicoService.GetAll();

            return medico.ToArray();
        }

        [HttpGet]
        public Medico GetById(int id)
        {
            var medico = _medicoService.GetById(id);

            return medico;
        }
    }
}
