using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TipoSaidaController : ControllerBase
    {
        private readonly ITipoSaidaService _saidaServicio;

        public TipoSaidaController(ITipoSaidaService entradaServicio)
        {
            _saidaServicio = entradaServicio;
        }

        [HttpGet("GetAll")]
        public IEnumerable<TipoSaidaOutput> GetAll()
        {
            return this._saidaServicio.GetSaidas();
        }

        [HttpGet("Get/{id}")]
        public TipoSaidaOutput Get(int id)
        {
            return this._saidaServicio.Get(id);
        }

        [HttpPost("Salvar")]
        public TipoSaidaOutput Salvar(TipoSaidaInput input)
        {
            return this._saidaServicio.SalvarSaida(input);
        }

        [HttpPost("Excluir")]
        public TipoSaidaOutput Excluir(TipoSaidaInput input)
        {
            return this._saidaServicio.ExcluirSaida(input);
        }
    }
}
