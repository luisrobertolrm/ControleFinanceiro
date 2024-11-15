using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Interface
{
    public interface IPeriodoService
    {
        PeriodoOutput Get(int ano, int mes);
        PeriodoOutput Salvar(PeriodoInput input);
    }
}
