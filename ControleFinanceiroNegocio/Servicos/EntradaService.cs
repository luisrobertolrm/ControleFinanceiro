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
    public class EntradaService: IEntradaService
    {
        private readonly ControleFinanceiroContext _contexto;
        private readonly IMapper _mapper;

        public EntradaService(ControleFinanceiroContext contexto, IMapper mapper)
        {
            _contexto = contexto;
            _mapper = mapper;
        }

        public List<EntradaOutput> GetEntradas(int ano, int mes)
        {
            var entradas = this._contexto.Entrada.Include(s => s.TipoEntrada).Where(s => s.Ano == ano && s.Mes == mes).ToList();

            return this._mapper.Map<List<EntradaOutput>>(entradas);
        }

        public List<EntradaOutput> SalvarEntrada(EntradaInput input)
        {
            var entrada = this._contexto.Entrada.Where(s => s.Ano == input.Ano && s.Mes == input.Mes).FirstOrDefault();

            if (entrada == null) 
            {
                entrada = this._mapper.Map<Entrada>(input);
                this._contexto.Entrada.Add(entrada);
            }
            else
                this._mapper.Map<EntradaInput, Entrada>(input, entrada);

            this._contexto.SaveChanges();

            return this.GetEntradas(input.Ano, input.Mes);
        }

        public List<EntradaOutput> ExcluirEntrada(EntradaInput input)
        {
            var entrada = this._contexto.Entrada.Where(s => s.Ano == input.Ano && s.Mes == input.Mes).FirstOrDefault();

            if (entrada == null)
            {
                throw new ApplicationException("Entrada não encontrada");
            }
            else
                this._mapper.Map<EntradaInput, Entrada>(input, entrada);

            this._contexto.SaveChanges();

            return this.GetEntradas(input.Ano, input.Mes);
        }
    }
}
