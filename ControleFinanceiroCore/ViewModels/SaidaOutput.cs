using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.ViewModels
{
    public class SaidaOutput
    {
        public SaidaOutput()
        {
            this.Itens = new List<SaidaItemOutput>();
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int IdTipoSaida { get; set; }

        /// <summary>
        /// O valor ainda vai estar disponível
        /// </summary>
        public DateTime? DataProjetada { get; set; }


        public List<SaidaItemOutput> Itens { get; set; }
    }

    public class ControleMensal
    {
        public int Ano { get; set; }
        public int Mes { get; set; }

        public decimal TotalSaida { get; set; }
        public decimal TotalEntrada { get; set; }
        public decimal Consolidado { get; set; }

        public decimal ValorProjetado { get; set; }
        public decimal ConsolidadoProjetado { get; set; }

        public List<SaidaOutput> Itens { get; set; }
    }
}
