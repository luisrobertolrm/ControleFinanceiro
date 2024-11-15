using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public interface IAuditoria
    {
        DateTime DataAlteracao { get; set; }
    }
}
