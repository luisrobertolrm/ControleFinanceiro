using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class SaidaItem
    {
        public int Id { get; set; }
        public int IdSaida { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int IdTipoSaida { get; set; }

        public virtual Saida Saida { get; set; }
    }
}
