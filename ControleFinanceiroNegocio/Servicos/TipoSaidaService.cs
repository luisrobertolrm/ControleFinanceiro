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
    public class TipoSaidaService : ITipoSaidaService
    {
        private readonly ControleFinanceiroContext _contexto;
        private readonly IMapper _mapper;

        public TipoSaidaService(ControleFinanceiroContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public TipoSaidaOutput Get(int id)
        {
            var saidas = this._contexto.TipoSaida.Where(s => s.Id == id).FirstOrDefault();

            return this._mapper.Map<TipoSaidaOutput>(saidas);
        }

        public TipoSaidaOutput SalvarSaida(TipoSaidaInput input)
        {
            TipoSaida saida = null;
            int id = 0;            

            if (input.Id.HasValue && input.Id.Value > 0)
            {
                saida = this._contexto.TipoSaida.Where(s => s.Id == input.Id).FirstOrDefault();
            }
            else
            {
                var aux = input.Nome.Trim().ToUpper();
                var mesmoNome = this._contexto.TipoSaida.Any(s => s.Nome.Trim() == aux);

                if (mesmoNome) throw new ApplicationException("Tipo já cadastrado, selecione o tipo já existente");

                id = this._contexto.TipoSaida.Any() ?this._contexto.TipoSaida.Max(s => s.Id):0;
            }

            if (saida == null)
            {
                saida = this._mapper.Map<TipoSaida>(input);
                saida.Id = ++id;
                this._contexto.TipoSaida.Add(saida);
            }               

            this._contexto.SaveChanges();

            return this._mapper.Map<TipoSaidaOutput>(saida);
        }

        public TipoSaidaOutput ExcluirSaida(TipoSaidaInput input)
        {
            var saida = this._contexto.TipoSaida.Where(s => s.Id == input.Id).FirstOrDefault();

            if (saida == null)
            {
                throw new ApplicationException("Tipo de Saída não encontrada");
            }

            this._contexto.Entry(saida).State = EntityState.Deleted;

            this._contexto.SaveChanges();

            var retorno = this.Get(input.Id.Value);

            return this._mapper.Map<TipoSaidaOutput>(retorno);
        }

        public IEnumerable<TipoSaidaOutput> GetSaidas()
        {
            var saida = this._contexto.TipoSaida.ToList();
            var retorno = this._mapper.Map<List<TipoSaidaOutput>>(saida);

            return retorno;
        }
    }
}
