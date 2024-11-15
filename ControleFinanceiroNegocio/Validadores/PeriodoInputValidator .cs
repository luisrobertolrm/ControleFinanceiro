using ControleFinanceiro.Core.ViewModels;
using ControleFinanceiro.DataBase;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Negocio.Validadores
{
    public class PeriodoInputValidator : AbstractValidator<PeriodoInput>
    {
        #region exemplo contexto banco de dados
        //private readonly ControleFinanceiroContext _contexto;

        //public EntradaInputValidator(ControleFinanceiroContext contexto)
        //{
        //    _contexto = contexto;
        //}
        #endregion

        public PeriodoInputValidator()
        {
            RuleFor(x => x.Ano)
                .NotNull().WithMessage("O ano é obrigatório")
                .GreaterThan(DateTime.Now.Year - 1).WithMessage("Valor deve ser maior que o ano atual menos 1");

            RuleFor(x => x.Mes)
                .NotNull().WithMessage("O Mês é obrigatório")
                .GreaterThan(0).WithMessage("Valor deve ser maior que zero")
                .LessThan(13).WithMessage("Valor não deve ser maior que doze");
        }
    }
}
