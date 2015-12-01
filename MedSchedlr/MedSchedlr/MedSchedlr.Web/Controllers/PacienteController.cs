using System.Linq;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;
using MedSchedlr.Data.Entities;
using System.Web.Mvc;

namespace MedSchedlr.Web.Controllers
{
    public class PacienteController : Controller
    {
        IPacienteService _pacienteService;

        public PacienteController()
        {
            _pacienteService = new PacienteService();
        }

        [HttpGet]
        public void Insert(Paciente paciente)
        {
            _pacienteService.Insert(paciente);
        }

        [HttpGet]
        public void Update(Paciente paciente)
        {
            _pacienteService.Update(paciente);
        }

        [HttpGet]
        public void Delete(Paciente paciente)
        {
            _pacienteService.Delete(paciente);
        }

        [HttpGet]
        public Paciente[] GetAll()
        {
            var paciente = _pacienteService.GetAll();

            return paciente.ToArray();
        }

        [HttpGet]
        public Paciente GetById(int id)
        {
            var paciente = _pacienteService.GetById(id);

            return paciente;
        }
    }
}
