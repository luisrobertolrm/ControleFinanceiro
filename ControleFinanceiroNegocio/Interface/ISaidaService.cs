using ControleFinanceiro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Interface
{
    public interface ISaidaService
    {
        List<SaidaOutput> GetSaidas(int mes, int ano);
        List<SaidaOutput> SalvarSaida(SaidaInput input);
        List<SaidaOutput> ExcluirSaida(SaidaInput input);
    }
}
