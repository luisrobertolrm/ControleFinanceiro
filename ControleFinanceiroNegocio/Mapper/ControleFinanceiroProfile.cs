using AutoMapper;
using ControleFinanceiro.Core.Entity;
using ControleFinanceiro.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Mapper
{
    public class ControleFinanceiroProfile: Profile
    {
        public ControleFinanceiroProfile()
        {
            this.CreateMap<string, string>().ConvertUsing<StringToStringTypeConverter>();

            this.CreateMap<EntradaInput, Entrada>();
            this.CreateMap<Entrada, EntradaOutput>()
                .ForMember(s => s.Nome, cfg => cfg.MapFrom(src => src.TipoEntrada.Nome));

            this.CreateMap<Periodo, PeriodoOutput>();
            this.CreateMap<PeriodoInput, Periodo>();

            this.CreateMap<SaidaInput, Saida>();
            this.CreateMap<Saida, SaidaOutput>();

            this.CreateMap<TipoSaidaInput, TipoSaida>();
            this.CreateMap<TipoSaida, TipoSaidaOutput>();


        }


        public class StringToStringTypeConverter : ITypeConverter<string, string>
        {
            public string Convert(string source, string destination, ResolutionContext context)
            {
                if (string.IsNullOrEmpty(source)) return null;

                return source.Trim().ToUpper();
            }
        }
    }
}
