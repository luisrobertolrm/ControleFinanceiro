using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.ViewModels
{
    public class SaidaItemOutput
    {
        public SaidaItemOutput()
        {
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
        public int IdTipoSaida { get; set; }
    }
}
