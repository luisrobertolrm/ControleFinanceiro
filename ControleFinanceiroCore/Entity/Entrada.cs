﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Core.Entity
{
    public class Entrada
    {
        public int Id { get; set; }
        public int IdTipoEntrada { get; set; }
        public string Descricao { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public DateTime Data { get; set; }
        public decimal Valor { get; set; }

        public virtual TipoEntrada TipoEntrada { get; set; }
        public virtual Periodo Periodo { get; set; }
    }
}
