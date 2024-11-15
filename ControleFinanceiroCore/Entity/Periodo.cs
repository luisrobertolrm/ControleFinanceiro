using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class Periodo
    {
        public Periodo()
        {
            this.Entradas = new HashSet<Entrada>();
            this.Saidas = new HashSet<Saida>();
        }

        public int Ano { get; set; }
        public int Mes { get; set; }
        public string Observacoes { get; set; }

        public virtual ICollection<Entrada> Entradas { get; set; }
        public virtual ICollection<Saida> Saidas { get; set; }
    }
}
