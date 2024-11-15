using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class TipoEntrada : IAuditoria
    {
        public TipoEntrada()
        {
            this.Entradas = new HashSet<Entrada>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Entrada> Entradas { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
