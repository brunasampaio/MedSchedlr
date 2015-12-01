using System.Linq;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;
using MedSchedlr.Data.Entities;
using System.Web.Mvc;

namespace MedSchedlr.Web.Controllers
{
    public class ConsultaMedicaController : Controller
    {
        IConsultaMedicaService _consultaMedicaService;
        IConsultorioService _consultorioService;
        ConsultaMedica _consultaMedica;

        public ConsultaMedicaController()
        {
            _consultaMedicaService = new ConsultaMedicaService();
            _consultorioService = new ConsultorioService();
            _consultaMedica = new ConsultaMedica();
        }

        public ActionResult NovaConsultaMedica()
        {
            return View();
        }

        [HttpGet]
        public void Insert(ConsultaMedica consultaMedica)
        {
            if (consultaMedica != null)
            {
                _consultaMedicaService.Insert(consultaMedica);
            }
        }

        [HttpGet]
        public void Update(ConsultaMedica consultaMedica)
        {
            if (consultaMedica != null)
            {
                _consultaMedicaService.Update(consultaMedica);
            }
        }

        [HttpGet]
        public void Delete(ConsultaMedica consultaMedica)
        {
            if (consultaMedica != null)
            {
                _consultaMedicaService.Delete(consultaMedica);
            }
        }

        [HttpGet]
        public ConsultaMedica[] GetAll()
        {
            var consultas = _consultaMedicaService.GetAll();

            return consultas.ToArray();
        }

        [HttpGet]
        public ConsultaMedica GetById(int id)
        {
            ConsultaMedica consulta = null; 

            if (id > 0)
            {
                consulta = _consultaMedicaService.GetById(id);
            }
            
            return consulta;
        }
    }
}
