using AutoMapper;
using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.DataBase;
using ControleFinanceiro.Negocio.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Servicos
{
    public class SaidaService : ISaidaService
    {
        private readonly ControleFinanceiroContext _contexto;
        private readonly IMapper _mapper;

        public SaidaService(ControleFinanceiroContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public List<SaidaOutput> GetSaidas(int mes, int ano)
        {
            var saidas = this._contexto.Saida.Include(s => s.TipoSaida).Where(s => s.Ano == ano && s.Mes == mes).ToList();

            return this._mapper.Map<List<SaidaOutput>>(saidas);
        }

        public List<SaidaOutput> SalvarSaida(SaidaInput input)
        {
            var saida = this._contexto.Saida.Where(s => s.Id == input.Id).FirstOrDefault();

            if(saida == null)
            {
                saida = this._mapper.Map<Saida>(input);
                this._contexto.Saida.Add(saida);
            }

            this._contexto.SaveChanges();

            var retorno = this.GetSaidas(input.Ano.Value, input.Mes.Value);

            return this._mapper.Map<List<SaidaOutput>>(retorno);
        }

        public List<SaidaOutput> ExcluirSaida(SaidaInput input)
        {
            var saida = this._contexto.Saida.Where(s => s.Id == input.Id).FirstOrDefault();

            if (saida == null)
            {
                throw new ApplicationException("Saída não encontrada");
            }

            saida = this._mapper.Map<Saida>(input);
            this._contexto.Entry(saida).State = EntityState.Deleted;

            this._contexto.SaveChanges();

            var retorno = this.GetSaidas(input.Ano.Value, input.Mes.Value);

            return this._mapper.Map<List<SaidaOutput>>(retorno);
        }
    }
}
