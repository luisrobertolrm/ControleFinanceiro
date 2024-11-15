using AutoMapper;
using ControleFinanceiro.Core.Entity;
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
    public class PeriodoService: IPeriodoService
    {
        private readonly ControleFinanceiroContext _contexto;
        private readonly IMapper _mapper;

        public PeriodoService(ControleFinanceiroContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public PeriodoOutput Get(int ano, int mes)
        {
            var retorno = this._contexto.Periodo.Where(s => s.Ano == ano &&  s.Mes == mes).FirstOrDefault();    

            return this._mapper.Map<PeriodoOutput>(retorno);
        }

        public PeriodoOutput Salvar(PeriodoInput input)
        {
            Periodo periodo = this._contexto.Periodo.Where(s => s.Ano == input.Ano && s.Mes == input.Mes).FirstOrDefault();

            if (periodo == null)
            {
                periodo = this._mapper.Map<Periodo>(input);
                this._contexto.Periodo.Add(periodo);
            }
            else
                periodo.Observacoes = input.Observacoes;

            this._contexto.SaveChanges();

            var retorno = this.Get(input.Ano, input.Mes);
            return retorno;
        }
    }
}
