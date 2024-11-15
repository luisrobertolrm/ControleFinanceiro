using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class Saida
    {
        public Saida()
        {
            this.SaidasItem = new HashSet<SaidaItem>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int IdTipoSaida { get; set; }

        public virtual TipoSaida TipoSaida { get; set; }
        public virtual Periodo Periodo { get; set; }
        public virtual ICollection<SaidaItem> SaidasItem { get; set; }
    }
}
