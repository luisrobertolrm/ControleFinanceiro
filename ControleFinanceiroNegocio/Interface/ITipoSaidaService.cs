using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Interface
{
    public interface ITipoSaidaService
    {
        TipoSaidaOutput Get(int id);
        TipoSaidaOutput SalvarSaida(TipoSaidaInput input);
        TipoSaidaOutput ExcluirSaida(TipoSaidaInput input);
        IEnumerable<TipoSaidaOutput> GetSaidas();
    }
}
