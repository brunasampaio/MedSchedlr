using System.Web.Http;
using System.Linq;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;
using MedSchedlr.Data.Entities;

namespace MedSchedlr.Web.Api.Controllers
{
    public class ConsultaMedicaController : ApiController
    {
        IConsultaMedicaService _consultaMedicaService;

        public ConsultaMedicaController()
        {
            _consultaMedicaService = new ConsultaMedicaService();
        }

        [HttpGet]
        public void Insert(ConsultaMedica consultaMedica)
        {
            _consultaMedicaService.Insert(consultaMedica);
        }

        [HttpGet]
        public void Update(ConsultaMedica consultaMedica)
        {
            _consultaMedicaService.Update(consultaMedica);
        }

        [HttpGet]
        public void Delete(ConsultaMedica consultaMedica)
        {
            _consultaMedicaService.Delete(consultaMedica);
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
            var consulta = _consultaMedicaService.GetById(id);

            return consulta;
        }
    }
}
