using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.ViewModels
{
    public class EntradaInput
    {
        public int Id { get; set; }
        public int IdTipoEntrada { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }
    }
}
