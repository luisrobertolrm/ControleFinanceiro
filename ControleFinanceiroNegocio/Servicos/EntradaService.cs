using AutoMapper;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.DataBase;
using ControleFinanceiro.Negocio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Servicos
{
    public class EntradaService: IEntradaService
    {
        private readonly ControleFinanceiroContext _contexto;
        private readonly IMapper _mapper;

        public EntradaService(ControleFinanceiroContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public List<EntradaOutput> GetEntradas(int mes, int ano)
        {
            return this._mapper.Map<List<EntradaOutput>>(this._contexto.Entrada);
        }
    }
}
