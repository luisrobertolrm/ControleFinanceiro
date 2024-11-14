using ControleFinanceiro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Interface
{
    public interface IEntradaService
    {
        List<EntradaOutput> GetEntradas(int mes, int ano);
    }
}
