using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.Negocio.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleFinanceiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeriodoController : ControllerBase
    {
        private readonly IPeriodoService _service;

        public PeriodoController(IPeriodoService service)
        {
            _service = service;
        }

        [HttpGet("PeriodoOutput/{ano}/{mes}")]
        public PeriodoOutput Get(int ano, int mes)
        {
            var retorno = this._service.Get(ano, mes);
            return retorno;
        }

        [HttpPost]
        public PeriodoOutput Salvar(PeriodoInput input)
        {
            var retorno = this._service.Salvar(input);
            return retorno;
        }
    }
}
