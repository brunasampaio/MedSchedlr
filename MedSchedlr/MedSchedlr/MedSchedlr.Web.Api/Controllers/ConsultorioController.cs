using System.Web.Http;
using System.Linq;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;
using MedSchedlr.Data.Entities;

namespace MedSchedlr.Web.Api.Controllers
{
    public class ConsultorioController : ApiController
    {
        IConsultorioService _consultorioService;

        public ConsultorioController()
        {
            _consultorioService = new ConsultorioService();
        }

        [HttpGet]
        public void Insert(Consultorio consultorio)
        {
            _consultorioService.Insert(consultorio);
        }

        [HttpGet]
        public void Update(Consultorio consultorio)
        {
            _consultorioService.Update(consultorio);
        }

        [HttpGet]
        public void Delete(Consultorio consultorio)
        {
            _consultorioService.Delete(consultorio);
        }

        [HttpGet]
        public Consultorio[] GetAll()
        {
            var consultorio = _consultorioService.GetAll();

            return consultorio.ToArray();
        }

        [HttpGet]
        public Consultorio GetById(int id)
        {
            var consultorio = _consultorioService.GetById(id);

            return consultorio;
        }
    }
}
