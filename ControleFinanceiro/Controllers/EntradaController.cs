using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.Negocio.Interface;
using Microsoft.AspNetCore.Mvc;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Attributes;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControleFinanceiro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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

        [HttpPost("Salvar")]
        public IActionResult SalvarEntrada(EntradaInput input)
        {
            return Ok(this._entradaServicio.SalvarEntrada(input));
        }
    }
}
