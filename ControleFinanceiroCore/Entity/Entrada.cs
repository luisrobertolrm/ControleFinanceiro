using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class Entrada: IAuditoria
    {
        public int Id { get; set; }
        public int IdTipoEntrada { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        /// <summary>
        /// O valor ainda vai estar disponível
        /// </summary>
        public DateTime? DataProjetada { get; set; }

        public virtual TipoEntrada TipoEntrada { get; set; }
        public virtual Periodo Periodo { get; set; }

        public DateTime DataAlteracao { get; set; }
    }
}
