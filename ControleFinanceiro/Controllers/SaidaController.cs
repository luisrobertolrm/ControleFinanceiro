using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaidaController : ControllerBase
    {
        private readonly ISaidaService _saidaServicio;

        public SaidaController(ISaidaService entradaServicio)
        {
            _saidaServicio = entradaServicio;
        }

        [HttpGet("Get/{ano}/{mes}")]
        public IEnumerable<SaidaOutput> Get(int ano, int mes)
        {
            return this._saidaServicio.GetSaidas(ano, mes);
        }

        [HttpPost("Salvar")]
        public IEnumerable<SaidaOutput> Salvar(SaidaInput input)
        {
            return this._saidaServicio.SalvarSaida(input);
        }

        [HttpPost("Excluir")]
        public IEnumerable<SaidaOutput> Excluir(SaidaInput input)
        {
            return this._saidaServicio.ExcluirSaida(input);
        }
    }
}
