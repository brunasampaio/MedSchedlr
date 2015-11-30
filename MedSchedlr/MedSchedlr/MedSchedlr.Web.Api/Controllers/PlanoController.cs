using System.Web.Http;
using System.Linq;
using MedSchedlr.Service;
using MedSchedlr.Service.Interfaces;
using MedSchedlr.Data.Entities;

namespace MedSchedlr.Web.Api.Controllers
{
    public class PlanoController : ApiController
    {
        IPlanoService _planoService;

        public PlanoController()
        {
            _planoService = new PlanoService();
        }

        [HttpGet]
        public void Insert(Plano plano)
        {
            _planoService.Insert(plano);
        }

        [HttpGet]
        public void Update(Plano plano)
        {
            _planoService.Update(plano);
        }

        [HttpGet]
        public void Delete(Plano plano)
        {
            _planoService.Delete(plano);
        }

        [HttpGet]
        public Plano[] GetAll()
        {
            var plano = _planoService.GetAll();

            return plano.ToArray();
        }

        [HttpGet]
        public Plano GetById(int id)
        {
            var plano = _planoService.GetById(id);

            return plano;
        }
    }
}
