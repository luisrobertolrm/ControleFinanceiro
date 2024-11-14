using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ControleFinanceiro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EntradaController : ControllerBase
    {
        private readonly IEntradaService _entradaServicio;

        public EntradaController(IEntradaService entradaServicio)
        {
            _entradaServicio = entradaServicio;
        }

        [HttpGet(Name = "GetEntradas/{ano}/{mes}")]
        public IEnumerable<EntradaOutput> Get(int ano, int mes)
        {
            return this._entradaServicio.GetEntradas(ano, mes);
        }
    }
}
