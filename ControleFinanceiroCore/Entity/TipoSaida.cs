using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class TipoSaida : IAuditoria
    {
        public TipoSaida()
        {
            this.Saidas = new HashSet<Saida>();
        }

        public int Id { get; set; }
        public string Nome {  get; set; }

        public virtual ICollection<Saida> Saidas { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
